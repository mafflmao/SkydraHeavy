namespace SkydraLite
{

    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tree = new TreeView();
            rtObjectHex = new ExRichTextBox();
            txtFloatEditor = new TextBox();
            txtIntEditor = new TextBox();
            txtSearch = new TextBox();
            msMain = new MenuStrip();
            tsmiFile = new ToolStripMenuItem();
            tsmiOpen = new ToolStripMenuItem();
            tsmiSave = new ToolStripMenuItem();
            igObjectsToolStripMenuItem = new ToolStripMenuItem();
            expandAllToolStripMenuItem = new ToolStripMenuItem();
            condenseAllToolStripMenuItem = new ToolStripMenuItem();
            sortByToolStripMenuItem = new ToolStripMenuItem();
            toolStripComboBox1 = new ToolStripComboBox();
            msMain.SuspendLayout();
            SuspendLayout();
            // 
            // tree
            // 
            tree.Location = new Point(12, 40);
            tree.Name = "tree";
            tree.Size = new Size(622, 668);
            tree.TabIndex = 1;
            tree.AfterSelect += OnSelectNode;
            // 
            // rtObjectHex
            // 
            rtObjectHex.Anchor = AnchorStyles.Right;
            rtObjectHex.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            rtObjectHex.Location = new Point(646, 69);
            rtObjectHex.Name = "rtObjectHex";
            rtObjectHex.ReadOnly = true;
            rtObjectHex.Selectable = false;
            rtObjectHex.Size = new Size(622, 638);
            rtObjectHex.TabIndex = 1;
            rtObjectHex.Text = "";
            rtObjectHex.MouseClick += OnClickHexDump;
            // 
            // txtFloatEditor
            // 
            txtFloatEditor.Anchor = AnchorStyles.Right;
            txtFloatEditor.Location = new Point(1068, 40);
            txtFloatEditor.Name = "txtFloatEditor";
            txtFloatEditor.Size = new Size(200, 23);
            txtFloatEditor.TabIndex = 1;
            txtFloatEditor.TextChanged += OnEditFloat;
            // 
            // txtIntEditor
            // 
            txtIntEditor.Anchor = AnchorStyles.Right;
            txtIntEditor.Location = new Point(646, 40);
            txtIntEditor.Name = "txtIntEditor";
            txtIntEditor.Size = new Size(200, 23);
            txtIntEditor.TabIndex = 1;
            txtIntEditor.TextChanged += OnEditInt;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(12, 684);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(628, 23);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += OnSearch;
            // 
            // msMain
            // 
            msMain.Items.AddRange(new ToolStripItem[] { tsmiFile, igObjectsToolStripMenuItem, sortByToolStripMenuItem });
            msMain.Location = new Point(0, 0);
            msMain.Name = "msMain";
            msMain.RenderMode = ToolStripRenderMode.Professional;
            msMain.Size = new Size(1280, 24);
            msMain.TabIndex = 2;
            msMain.Text = "msMain";
            // 
            // tsmiFile
            // 
            tsmiFile.DropDownItems.AddRange(new ToolStripItem[] { tsmiOpen, tsmiSave });
            tsmiFile.Name = "tsmiFile";
            tsmiFile.Size = new Size(37, 20);
            tsmiFile.Text = "File";
            // 
            // tsmiOpen
            // 
            tsmiOpen.Name = "tsmiOpen";
            tsmiOpen.ShortcutKeys = Keys.Control | Keys.O;
            tsmiOpen.Size = new Size(167, 22);
            tsmiOpen.Text = "Open File";
            tsmiOpen.Click += OpenFile;
            // 
            // tsmiSave
            // 
            tsmiSave.Name = "tsmiSave";
            tsmiSave.ShortcutKeys = Keys.Control | Keys.S;
            tsmiSave.Size = new Size(167, 22);
            tsmiSave.Text = "Save File";
            tsmiSave.Click += SaveFile;
            // 
            // igObjectsToolStripMenuItem
            // 
            igObjectsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { expandAllToolStripMenuItem, condenseAllToolStripMenuItem });
            igObjectsToolStripMenuItem.Name = "igObjectsToolStripMenuItem";
            igObjectsToolStripMenuItem.Size = new Size(59, 20);
            igObjectsToolStripMenuItem.Text = "Objects";
            // 
            // expandAllToolStripMenuItem
            // 
            expandAllToolStripMenuItem.Name = "expandAllToolStripMenuItem";
            expandAllToolStripMenuItem.Size = new Size(144, 22);
            expandAllToolStripMenuItem.Text = "Expand All";
            expandAllToolStripMenuItem.Click += expandAllToolStripMenuItem_Click;
            // 
            // condenseAllToolStripMenuItem
            // 
            condenseAllToolStripMenuItem.Name = "condenseAllToolStripMenuItem";
            condenseAllToolStripMenuItem.Size = new Size(144, 22);
            condenseAllToolStripMenuItem.Text = "Condense All";
            condenseAllToolStripMenuItem.Click += condenseAllToolStripMenuItem_Click;
            // 
            // sortByToolStripMenuItem
            // 
            sortByToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripComboBox1 });
            sortByToolStripMenuItem.Name = "sortByToolStripMenuItem";
            sortByToolStripMenuItem.Size = new Size(56, 20);
            sortByToolStripMenuItem.Text = "Sort By";
            // 
            // toolStripComboBox1
            // 
            toolStripComboBox1.Items.AddRange(new object[] { "Normal", "Alphabetical" });
            toolStripComboBox1.Name = "toolStripComboBox1";
            toolStripComboBox1.Size = new Size(121, 23);
            toolStripComboBox1.Text = "Normal";
            toolStripComboBox1.SelectedIndexChanged += toolStripComboBox1_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1280, 720);
            Controls.Add(tree);
            Controls.Add(rtObjectHex);
            Controls.Add(txtFloatEditor);
            Controls.Add(txtIntEditor);
            Controls.Add(txtSearch);
            Controls.Add(msMain);
            MainMenuStrip = msMain;
            Name = "Form1";
            Text = "SkydraHeavy";
            WindowState = FormWindowState.Maximized;
            FormClosing += OnClosingForm;
            Resize += OnResize;
            msMain.ResumeLayout(false);
            msMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public System.Windows.Forms.TreeView tree;
        public SkydraLite.ExRichTextBox rtObjectHex;
        public System.Windows.Forms.TextBox txtFloatEditor;
        public System.Windows.Forms.TextBox txtIntEditor;
        public System.Windows.Forms.TextBox txtSearch;
        public System.Windows.Forms.MenuStrip msMain;
        public System.Windows.Forms.ToolStripMenuItem tsmiFile;
        public System.Windows.Forms.ToolStripMenuItem tsmiOpen;
        public System.Windows.Forms.ToolStripMenuItem tsmiSave;
        private ToolStripMenuItem igObjectsToolStripMenuItem;
        private ToolStripMenuItem expandAllToolStripMenuItem;
        private ToolStripMenuItem condenseAllToolStripMenuItem;
        private ToolStripMenuItem sortByToolStripMenuItem;
        public ToolStripComboBox toolStripComboBox1;
    }
}