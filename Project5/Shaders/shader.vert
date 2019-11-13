#version 130

in vec2 aPosition;

uniform mat4 uProjectionMatrix;
uniform mat4 uModelviewMatrix;

void main()
{	
	gl_Position = uProjectionMatrix * uModelviewMatrix * vec4(aPosition, 0.0, 1.0);
}