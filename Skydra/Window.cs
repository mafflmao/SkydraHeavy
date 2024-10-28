using LibSkydra.IO;
using OpenTK.ImGui;
using ImGuiNET;

namespace Skydra
{
	public class Window : GameWindow
	{
		IGZ igz;
		Transform transform;
		Vector2 freecamLocal;

		ImGuiController controller;

		List<Model> models = new List<Model>();
		List<string> names = new List<string>();

		public Window(GameWindowSettings gws, NativeWindowSettings nws, string level) : base(gws, nws)
		{
			if(level.Count(x => x == ':') > 1)
			{
				igz = igObjectPool.LoadIGZ(level);
				return;
			}
			try
			{
				igz = new IGZ(File.Open(level, FileMode.Open, FileAccess.Read));
			}
			catch(Exception)
			{
				LibSkydra.Archive.igArchive iga = new LibSkydra.Archive.igArchive(level);
				FileStream fs = new FileStream("out.dat", FileMode.Create);
				iga.ExtractFile(0x5214C691, fs);
				fs.Close();
				return;
			}
		}

		protected override async void OnLoad()
		{
			base.OnLoad();

			ShaderManager.LoadShader("standard;standardunlit", "Shaders/standard.vert.glsl", "Shaders/standardunlit.frag.glsl");

			controller = new ImGuiController(ClientSize.X, ClientSize.Y);

			GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
			GL.Enable(EnableCap.DepthTest);
			GL.Enable(EnableCap.Texture2D);
			GL.PointSize(5);

			uint[][] indices = null;
			float[][] vertices = null;

			if(igz.version == 0x07)
			{
				igGroup sceneGraph = ((igz.objectList.tdata[0] as igSceneInfo).sceneGraph);
				CMaterialHandleTableInfo materialhandle = ((igz.objectList.tdata[1] as CMaterialHandleTableInfo));
				Console.WriteLine($"{igz.runtimeHandles[0].ToString("X08")}");
				if(sceneGraph is igTransform)
				{
					((sceneGraph.childList.tdata[0] as igFxMaterialNode).childList.tdata[0] as igGeometry).ExtractGeometry(out indices, out vertices);
				}
				else if (sceneGraph is igFxMaterialNode)
				{
					(sceneGraph.childList.tdata[0] as igGeometry).ExtractGeometry(out indices, out vertices);
				}
				else
				{
					throw new Exception("Model unaccounted for");
				}
				models.Add(new Model(vertices, indices));
			}
			else if(igz.version == 0x08)
			{

			}
			else throw new NotImplementedException($"loading of IGZ version {igz.version} not implemented");
			//Console.WriteLine((((igz.objectList.tdata[0] as igSceneInfo).sceneGraph.childList.tdata[0] as igFxMaterialNode).childList.tdata[0] as igGeometry).attributes.tdata[0].GetType());

			transform = new Transform(Vector3.Zero, Vector3.Zero, Vector3.One);
			Camera.CreatePerspective(MathHelper.PiOver2);
		}

		protected override void OnRenderFrame(FrameEventArgs args)
		{
			base.OnRenderFrame(args);

			GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

			foreach(Model model in models)
			{
				model.Render(transform);
			}

			//controller.Update(this, (float)args.Time);

			//ImGui.ShowDemoWindow();
			//ImGui.Begin("Skydra");
			//int current = 0;
			//ImGui.ListBox("Sprites", ref current, names.ToArray(), names.Count);
			//ImGui.Text("Test");
			//ImGui.End();

			//controller.Render();

			SwapBuffers();
		}

		protected override void OnUpdateFrame(FrameEventArgs args)
		{
			if(KeyboardState.IsKeyDown(Keys.Escape)) Close();

			float moveSpeed = 20;
			float sensitivity = 0.01f;

			if(KeyboardState.IsKeyDown(Keys.LeftShift)) moveSpeed *= 10;

			if(KeyboardState.IsKeyDown(Keys.W)) Camera.transform.Position += Camera.transform.Forward * (float)args.Time * moveSpeed;
			if(KeyboardState.IsKeyDown(Keys.A)) Camera.transform.Position += Camera.transform.Right * (float)args.Time * moveSpeed;
			if(KeyboardState.IsKeyDown(Keys.S)) Camera.transform.Position -= Camera.transform.Forward * (float)args.Time * moveSpeed;
			if(KeyboardState.IsKeyDown(Keys.D)) Camera.transform.Position -= Camera.transform.Right * (float)args.Time * moveSpeed;

			freecamLocal += MouseState.Delta.Yx * sensitivity;

			freecamLocal.X = MathHelper.Clamp(freecamLocal.X, -MathHelper.PiOver2 + 0.0001f, MathHelper.PiOver2 - 0.0001f);

			Camera.transform.Rotation = Quaternion.FromAxisAngle(Vector3.UnitX, freecamLocal.X) * Quaternion.FromAxisAngle(Vector3.UnitY, freecamLocal.Y);

			base.OnUpdateFrame(args);
		}

		protected override void OnTextInput(TextInputEventArgs e)
		{
			base.OnTextInput(e);

			controller.PressChar((char)e.Unicode);
		}

		protected override void OnMouseWheel(MouseWheelEventArgs e)
		{
			base.OnMouseWheel(e);

			controller.MouseScroll(e.Offset);
		}

		protected override void OnClosed()
		{
			igz.sh.Close();

			base.OnClosed();
		}
	}
}