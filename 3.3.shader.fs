#version 330 core
out vec4 FragColor;

in vec3 ourColor;
in vec2 fragUV;

uniform float time;

void main()
{
    // Center UV around (0.0, 0.0)
    vec2 uv = fragUV - vec2(0.5);
    float dist = length(uv);

    // Polar swirl effect
    float angle = atan(uv.y, uv.x);
    float swirl = sin(10.0 * dist - time * 2.0 + angle * 3.0);

    // RGB swirl
    vec3 color = vec3(
          0.5 + 0.5 * sin(swirl + 0.0), // Red
          0.5 + 0.5 * sin(swirl + 2.0), // Green
          0.5 + 0.5 * sin(swirl + 4.0)  // Blue
    );

    FragColor = vec4(color, 1.0);
}
