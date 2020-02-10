#version 130
in vec2 aPosition;
in vec2 aTexCoord;

out vec2 texCoord;

uniform mat4 uProjectionMatrix;
uniform mat4 uModelviewMatrix;

void main()
{
	texCoord = aTexCoord;
	gl_Position = uProjectionMatrix * uModelviewMatrix * vec4(aPosition, 0.0f, 1.0f);
}