using System.ComponentModel.Design;
using BCnEncoder.Decoder;
using BCnEncoder.ImageSharp;
using LibSkydra;
using SixLabors.ImageSharp.PixelFormats;

namespace SkydraLite
{
    public partial class Form1 : Form
    {
        IGZ igz;
        TreeNode nodeFixups = new TreeNode();
        TreeNode nodeObjects = new TreeNode();
        TreeNode nodeSearchObjects = new TreeNode();
        igObject? selectedObject;
        Dictionary<uint, byte[]> changes = new Dictionary<uint, byte[]>();
        List<string> treeNodePaths = new List<string>();
        uint bytesSelectionIndex;

        public Form1(string[] args)
        {
            InitializeComponent();
            OnResize(null, null);

            // uhhhhhhhhhhhhhhhhhh
            tree.AfterExpand += OnNodeExpand;

            if (args.Length != 0)
            {
                FileStream fs = File.Open(args[0], FileMode.Open);
                OpenIGZFile(fs);
                this.Text = $"SkydraHeavy | {Path.GetFileName(args[0])}";
            }
        }

        public void OpenIGZFile(Stream stream)
        {
            igz = new IGZ(stream, null, false);

            nodeFixups.Text = "Fixups";
            nodeObjects.Text = "Objects";
            nodeSearchObjects.Text = "Objects";

            tree.Nodes.Add(nodeFixups);
            tree.Nodes.Add(nodeObjects);

            if (igz.stringList.Count != 0)
            {
                TreeNode tstr = new TreeNode("String Table (TSTR)");
                for (int i = 0; i < igz.stringList.Count; i++)
                {
                    tstr.Nodes.Add(igz.stringList[i]);
                }
                nodeFixups.Nodes.Add(tstr);
            }
            if (igz.exnm.count != 0)
            {
                TreeNode exnm = new TreeNode("External Named Handles");
                for (int i = 0; i < igz.exnm.count; i++)
                {
                    // exnm.Nodes.Add($"{igz.han[igz.exnm.objectNames[i]]} : {igz.tstr.strings[igz.exnm.dependancyNames[i]]}");
                }
                nodeFixups.Nodes.Add(exnm);
            }
            if (igz.memoryHandles.Count != 0)
            {
                TreeNode tmhn = new TreeNode("Memory Handles (TMHN)");
                for (int i = 0; i < igz.memoryHandles.Count; i++)
                {
                    tmhn.Nodes.Add($"Memory Handle {i}");
                }
                nodeFixups.Nodes.Add(tmhn);
            }

            for (int i = 0; i < igz.objectList.tdata.Count; i++)
            {
                string name = string.Empty;
                if (igz.nameList != null)
                {
                    name = igz.nameList.tdata[i].name;
                }
                if (igz.objectList.tdata[i].GetType().GetField("name") != null)
                {
                    name += $"{(name == string.Empty ? string.Empty : " or ")}{(igz.objectList.tdata[i].GetType().GetField("name").GetValue(igz.objectList.tdata[i]))}";
                }

                nodeObjects.Nodes.Add($"{GetObjectIndex(igz.objectList.tdata[i]).ToString("X04")}: {igz.typeNames[(int)igz.objectList.tdata[i].typeIndex]}{(name == string.Empty ? string.Empty : " : " + name)}");
                PopulateObjectNode(nodeObjects.Nodes.Cast<TreeNode>().Last(), igz.objectList.tdata[i]);
            }
        }

        private void OnNodeExpand(object sender, TreeViewEventArgs e)
        {
            TreeNode node = e.Node;

            // only load children when needed
            if (node.Nodes.Count == 1 && node.Nodes[0].Text == "CHILD PLACEHOLDER!!")
            {
                node.Nodes.Clear(); // remove the placeholder

                // find the igObject and load its children
                int index = int.Parse(node.Text.Split(':')[0], System.Globalization.NumberStyles.HexNumber);
                igObject currentObject = igz.objects.Values.ElementAt(index);

                PopulateObjectNode(node, currentObject);
            }
        }

        public igObject[] PredictChildren(igObject obj)
        {
            List<igObject> children = new List<igObject>();

            int objIndex = Array.IndexOf<ulong>(igz.objects.Keys.ToArray(), obj.offset);
            uint endOffset = obj.offset + obj.fakeSize;

            for (int i = 0; i < igz.runtimeOffsets.Length; i++)
            {
                if (obj.offset <= igz.runtimeOffsets[i] && endOffset > igz.runtimeOffsets[i])
                {
                    igz.sh.Seek(igz.runtimeOffsets[i]);
                    ulong offset = igz.ReadOffset();
                    if (igz.objects.Keys.Any(x => x == offset))
                    {
                        if (!igz.objectList.tdata.Any(x => x == igz.objects[offset]))
                        {
                            children.Add(igz.objects[offset]);
                        }
                    }
                }
            }
            return children.ToArray();
        }

        public void PopulateObjectNode(TreeNode currentNode, igObject currentObject)
        {
            igObject[] children = PredictChildren(currentObject);

            foreach (var child in children)
            {
                string name = child.GetType().GetField("name")?.GetValue(child)?.ToString() ?? string.Empty;
                TreeNode childNode = new TreeNode($"{GetObjectIndex(child):X04}: {igz.typeNames[(int)child.typeIndex]}{(name != string.Empty ? " : " + name : name)}");

                // add a dummy node to show it has children
                if (PredictChildren(child).Length > 0)
                {
                    childNode.Nodes.Add(new TreeNode("CHILD PLACEHOLDER!!"));
                }

                currentNode.Nodes.Add(childNode);
            }
        }

        public int GetObjectIndex(igObject obj)
        {
            return Array.FindIndex<KeyValuePair<ulong, igObject>>(igz.objects.ToArray(), x => x.Value == obj);
        }

        public void OnSelectNode(object sender, TreeViewEventArgs e)
        {
            if (tree.SelectedNode.FullPath.StartsWith("Objects") && tree.SelectedNode != nodeObjects)
            {
                string selectedObjectIndexString = new string(tree.SelectedNode.Text.TakeWhile(x => x != ':').ToArray());
                int selectedObjectIndex = int.Parse(selectedObjectIndexString, System.Globalization.NumberStyles.HexNumber);
                selectedObject = igz.objects.ToArray()[selectedObjectIndex].Value;
                TickInspector();
            }
            else
            {
                selectedObject = null;
                DepopulateInspector();
            }

            if (tree.SelectedNode.FullPath.StartsWith("Fixups") && tree.SelectedNode != nodeFixups)
            {
                if (tree.SelectedNode.FullPath.Contains("Memory Handles (TMHN)") && !nodeFixups.Nodes.Contains(tree.SelectedNode))
                {
                    Console.WriteLine($"Memory Handle {tree.SelectedNode.Text.Substring(14)} Selected");
                }
            }
        }

        public void TickInspector(bool resetHighlight = true)
        {
            byte[] objectBytes;
            if (!changes.ContainsKey(selectedObject.offset))
            {
                objectBytes = selectedObject.GetRawBytes(true);
            }
            else
            {
                objectBytes = changes[selectedObject.offset];
            }

            string rawHexDump = Convert.ToHexString(objectBytes);
            string finalHexDump = string.Empty;
            for (int i = 0; i < rawHexDump.Length; i += 8)
            {
                finalHexDump +=
                    rawHexDump.Substring(i + 0, 2) + " " +
                    rawHexDump.Substring(i + 2, 2) + " " +
                    rawHexDump.Substring(i + 4, 2) + " " +
                    rawHexDump.Substring(i + 6, 2) + (i % 16 == 8 ? "\n" : "   ");
            }
            rtObjectHex.Text = finalHexDump;
            if (!resetHighlight)
            {
                int blockIndex = (int)bytesSelectionIndex / 4;
                rtObjectHex.SelectionStart = (blockIndex / 2) * 26 + (blockIndex % 2) * 14;
                rtObjectHex.SelectionLength = 11;
                rtObjectHex.SelectionColor = Color.Red;
            }
        }

        public void DepopulateInspector()
        {
            rtObjectHex.Text = string.Empty;
        }

        public void OnResize(object sender, EventArgs e)
        {
            tree.Size = new Size(Width / 2 - 18, Height - 133);

            //rtObjectHex.Location = new Point(Width / 2 + 6, 40);
            //rtObjectHex.Size = new Size(Width / 2 - 36, Height / 2 - 46);

            //txtIntEditor.Location = new Point(rtObjectHex.Location.X, rtObjectHex.Location.Y + rtObjectHex.Size.Height + 12 + txtFloatEditor.Height);
            //txtFloatEditor.Location = new Point(rtObjectHex.Location.X + rtObjectHex.Size.Width / 2, rtObjectHex.Location.Y + rtObjectHex.Size.Height + 12 + txtFloatEditor.Height);
            // all of this shit isnt really needed tbh
            txtSearch.Location = new Point(tree.Location.X, tree.Location.Y + tree.Size.Height + 6);
            txtSearch.Size = new Size(tree.Size.Width, 23);
        }

        public void OnClickHexDump(object sender, MouseEventArgs e)
        {
            if (rtObjectHex.Text == string.Empty) return;

            int blockIndex = (rtObjectHex.GetCharIndexFromPosition(e.Location) / 13);
            Console.WriteLine(blockIndex);

            rtObjectHex.SelectAll();
            rtObjectHex.SelectionColor = Color.Black;

            rtObjectHex.SelectionStart = (blockIndex / 2) * 26 + (blockIndex % 2) * 14;
            rtObjectHex.SelectionLength = 11;
            rtObjectHex.SelectionColor = Color.Red;
            bytesSelectionIndex = (uint)blockIndex * 4;

            byte[] selected = Convert.FromHexString(rtObjectHex.SelectedText.Replace(" ", string.Empty).Replace("\n", string.Empty));
            if (igz.sh._endianness == LibSkydra.IO.StreamHelper.Endianness.Big) Array.Reverse(selected);

            txtFloatEditor.Text = BitConverter.ToSingle(selected).ToString();
            txtIntEditor.Text = BitConverter.ToUInt32(selected).ToString();
        }
        public void OnEditFloat(object sender, EventArgs e)
        {
            if (float.TryParse(txtFloatEditor.Text, out float final))
            {
                OnEdit(BitConverter.GetBytes(final), true);
            }
        }
        public void OnEditInt(object sender, EventArgs e)
        {
            if (int.TryParse(txtIntEditor.Text, out int final))
            {
                OnEdit(BitConverter.GetBytes(final), true);
            }
        }
        public void OnEdit(byte[] edits, bool isEndianSwapNeeded)
        {
            if (isEndianSwapNeeded && igz.sh._endianness == LibSkydra.IO.StreamHelper.Endianness.Big)
            {
                Array.Reverse(edits);
            }
            if (!changes.ContainsKey(selectedObject.offset))
            {
                changes.Add(selectedObject.offset, selectedObject.GetRawBytes(true));
            }
            Array.Copy(edits, 0x00, changes[selectedObject.offset], bytesSelectionIndex, edits.Length);
            TickInspector(false);
        }

        public void OnSearch(object sender, EventArgs e)
        {
            if (txtSearch.Text == string.Empty)
            {
                tree.Nodes.Clear();
                tree.Nodes.Add(nodeFixups);
                tree.Nodes.Add(nodeObjects);
            }
            else
            {
                nodeSearchObjects.Nodes.Clear();
                treeNodePaths.Clear();
                PopulateTreePaths(nodeObjects);

                tree.Nodes.Clear();
                tree.Nodes.Add(nodeFixups);

                for (int i = 0; i < treeNodePaths.Count; i++)
                {
                    if (treeNodePaths[i].Contains(txtSearch.Text))
                    {
                        Console.WriteLine($"Match Found {i}/{treeNodePaths.Count}");
                        nodeSearchObjects.Nodes.Add(treeNodePaths[i].Replace('\\', ';'));
                    }
                }

                tree.Nodes.Add(nodeSearchObjects);
            }
        }
        public void OnImageExtractPressed(object sender, EventArgs e)
        {
            return;
        }

        void PopulateTreePaths(TreeNode parent)
        {
            if (parent.TreeView == null) return;
            treeNodePaths.Add(parent.FullPath);
            Console.WriteLine(treeNodePaths.Last());

            for (int i = 0; i < parent.Nodes.Count; i++)
            {
                PopulateTreePaths(parent.Nodes[i]);
            }
        }

        public void OpenFile(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "IGZ File|*.igz;*.pak;*.lang;level.bld|All Files (*.*)|*.*";
                ofd.FilterIndex = 0;
                ofd.RestoreDirectory = true;
                ofd.Multiselect = false;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (igz != null)
                    {
                        igz.sh.BaseStream.Close();
                        DepopulateInspector();
                        nodeFixups.Nodes.Clear();
                        nodeObjects.Nodes.Clear();
                        tree.Nodes.Clear();
                        changes.Clear();
                    }

                    FileStream fs = File.Open(ofd.FileName, FileMode.Open);
                    OpenIGZFile(fs);
                    this.Text = $"SkydraHeavy | {Path.GetFileName(ofd.FileName)}"; //  new name!!!
                }
            }
        }
        public void SaveFile(object sender, EventArgs e)
        {
            foreach (KeyValuePair<uint, byte[]> change in changes)
            {
                igz.objects[change.Key].DirectSerialize(change.Value);
            }
        }

        public void OnClosingForm(object sender, FormClosingEventArgs e)
        {
            if (igz != null)
            {
                igz.sh.BaseStream.Close();
            }
        }

        private void expandAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tree.ExpandAll();
        }

        private void condenseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tree.CollapseAll();
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sortingMode = toolStripComboBox1.SelectedItem.ToString();
            SortTreeNodes(nodeObjects.Nodes, sortingMode);
            tree.Refresh();
        }

        private void SortTreeNodes(TreeNodeCollection nodes, string sortingMode)
        {
            var sortedNodes = nodes.Cast<TreeNode>()
                .OrderBy(node =>
                {
                    string[] parts = node.Text.Split(new[] { ':' }, 2);
                    return sortingMode == "Alphabetical" && parts.Length > 1 ? parts[1].Trim() : parts[0].Trim();
                })
                .ToList();

            nodes.Clear();
            foreach (var node in sortedNodes)
            {
                nodes.Add(node);
                if (node.Nodes.Count > 0)
                {
                    SortTreeNodes(node.Nodes, sortingMode);
                }
            }
        }

    }
}