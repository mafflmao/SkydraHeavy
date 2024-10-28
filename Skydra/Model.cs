namespace Skydra
{
	public class Model
	{
		int[] VBOs;
		int[] VAOs;
		int[] EBOs;

		public Shader[] materials;
		int[] indexCounts;

		public static uint drawcalls;		//This is for debugging

		/*public Model( model)
		{
			VBOs = new int[model.meshCount];
			VAOs = new int[model.meshCount];
			EBOs = new int[model.meshCount];
			materials = new Material[model.meshCount];
			indexCounts = new int[model.meshCount];

			GL.GenBuffers(model.meshCount, VBOs);
			GL.GenVertexArrays(model.meshCount, VAOs);
			GL.GenBuffers(model.meshCount, EBOs);

			for(int i = 0; i < model.meshCount; i++)
			{
				float[] vertices = model.ReadVertexBuffer(i);
				uint[] indices = model.ReadIndexBuffer(i);

				try
				{
					Shader shader = AssetManager.shaderGroup.GetShaderFromTuid(model.GetShaderTuid(i));
					uint albedoTuid = 0;
					for(int j = 0; j < shader.textureTuidCount; j++)
					{
						albedoTuid = shader.GetTextureTuid(j);
						if(albedoTuid == 0) continue;
						if(AssetManager.textureGroup.FindTexture(albedoTuid) < 0) continue;
						break;
					}
					materials[i] = new Material(MaterialManager.shaders["standard.vert;standardunlit.frag"], AssetManager.LoadTexture(albedoTuid));		//Temporary
				}
				catch(NullReferenceException)
				{
					materials[i] = new Material(MaterialManager.shaders["standard.vert;standardunlit.frag"], null);
				}

				indexCounts[i] = indices.Length;

				GL.BindBuffer(BufferTarget.ArrayBuffer, VBOs[i]);
				GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

				GL.BindVertexArray(VAOs[i]);
				GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 5 * sizeof(float), 0);					//Position data
				GL.EnableVertexAttribArray(0);

				GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, 5 * sizeof(float), 3 * sizeof(float));	//UV data
				GL.EnableVertexAttribArray(1);

				GL.BindBuffer(BufferTarget.ElementArrayBuffer, EBOs[i]);
				GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.StaticDraw);
			}
		}*/

		public Model(float[] vertices, uint[] indices)
		{
			VBOs = new int[1];
			VAOs = new int[1];
			EBOs = new int[1];
			materials = new Shader[1];
			indexCounts = new int[1];

			GL.GenBuffers(1, VBOs);
			GL.GenVertexArrays(1, VAOs);
			GL.GenBuffers(1, EBOs);

			materials[0] = new Shader(ShaderManager.shaders["standard;standardunlit"], null);		//Temporary
			materials[0].drawType = PrimitiveType.Triangles;
			indexCounts[0] = indices.Length;

			GL.BindBuffer(BufferTarget.ArrayBuffer, VBOs[0]);
			GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

			GL.BindVertexArray(VAOs[0]);
			GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 8 * sizeof(float), 0);
			GL.EnableVertexAttribArray(0);

			GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, 8 * sizeof(float), 3 * sizeof(float));
			GL.EnableVertexAttribArray(1);

			GL.BindBuffer(BufferTarget.ElementArrayBuffer, EBOs[0]);
			GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.StaticDraw);
		}
		public Model(float[][] vertices, uint[][] indices)
		{
			VBOs = new int[vertices.Length];
			VAOs = new int[vertices.Length];
			EBOs = new int[vertices.Length];
			materials = new Shader[vertices.Length];
			indexCounts = new int[vertices.Length];

			GL.GenBuffers(vertices.Length, VBOs);
			GL.GenVertexArrays(vertices.Length, VAOs);
			GL.GenBuffers(vertices.Length, EBOs);

			for(int i = 0; i < vertices.Length; i++)
			{
				materials[i] = new Shader(ShaderManager.shaders["standard;standardunlit"], null);		//Temporary
				materials[i].drawType = PrimitiveType.Triangles;
				indexCounts[i] = indices[i].Length;

				GL.BindBuffer(BufferTarget.ArrayBuffer, VBOs[i]);
				GL.BufferData(BufferTarget.ArrayBuffer, vertices[i].Length * sizeof(float), vertices[i], BufferUsageHint.StaticDraw);

				GL.BindVertexArray(VAOs[i]);
				GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 8 * sizeof(float), 0);
				GL.EnableVertexAttribArray(0);

				GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, 8 * sizeof(float), 3 * sizeof(float));
				GL.EnableVertexAttribArray(1);

				GL.BindBuffer(BufferTarget.ElementArrayBuffer, EBOs[i]);
				GL.BufferData(BufferTarget.ElementArrayBuffer, indices[i].Length * sizeof(uint), indices[i], BufferUsageHint.StaticDraw);
			}
		}

		public void Render(Transform transform)
		{
			for(int i = 0; i < VBOs.Length; i++)
			{
				drawcalls++;
				materials[i].Use();
				
				materials[i].SetMatrix4x4("world", transform.GetLocalToWorldMatrix() * Camera.WorldToView * Camera.ViewToClip);

				GL.BindVertexArray(VAOs[i]);
				GL.DrawElements(materials[i].drawType, indexCounts[i], DrawElementsType.UnsignedInt, 0);
			}
		}
		public void Dispose()
		{
			materials[0].Dispose();		//Temp
		}
	}
}