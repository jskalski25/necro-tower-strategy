#version 130

in vec2 aPosition;

uniform mat4 uModelviewMatrix;
uniform mat4 uProjectionMatrix;

void main()
{
	gl_Position = uProjectionMatrix * uModelviewMatrix * vec4(aPosition, 0.0f, 1.0f);
}