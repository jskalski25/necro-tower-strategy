#version 130

uniform sampler2D texture0;

in vec2 texCoord;

out vec4 fragColor;

void main()
{
	fragColor = texture(texture0, texCoord);

	if (fragColor.a == 0)
	{
		discard;
	}
}