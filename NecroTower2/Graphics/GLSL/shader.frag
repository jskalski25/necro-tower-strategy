#version 130
in vec2 texCoord;

out vec4 FragColor;

uniform sampler2D texture0;

void main() {
	FragColor = texture(texture0, texCoord);
	if (FragColor.a == 0f) discard;
}