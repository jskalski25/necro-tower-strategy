#version 130

out vec4 outputColor;

in vec2 texCoord;

uniform sampler2D texture0;

void main()
{
	outputColor = texture(texture0, texCoord);

	if (outputColor.a == 0) discard;
}