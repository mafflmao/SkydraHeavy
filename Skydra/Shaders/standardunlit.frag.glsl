#version 330 core

out vec4 colour;

in vec2 UVs;

uniform sampler2D albedo;
uniform bool useTexture;

void main()
{
	if(useTexture)
	{
		colour = texture(albedo, UVs);
		if(colour.a == 0) discard;
	}
	else
	{
		colour = vec4(1.0, 0.0, 1.0, 1.0);
	}
}