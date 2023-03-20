// Copied from https://www.youtube.com/watch?v=b4utgRuIekk by Sam Wronski
Shader "Custom/TorchShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
        _LightDirection("Light Direction", Vector) = (0,0,0,0)
		_LightPosition("Light Position", Vector) = (0,0,0,0)
		_LightAngle("Light Angle", Range(0,180)) = 0
        _ScaleStrength("Strength", Float) = 50
    }
    SubShader
    {
        Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }
        Blend SrcAlpha OneMinusSrcAlpha
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows alpha:fade

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
            float3 worldPos;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;
        float3 _LightDirection;
		float3 _LightPosition;
		float _LightAngle;
        float _ScaleStrength;



        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Calculate the vector from the light to the material
            float3 direction = (_LightPosition - IN.worldPos);
            // Calculate the difference between this and the direction of the light
			float strength = dot(normalize(direction), _LightDirection);
            // add the angle of the beam (half its light angle as we are working with the light direction) to account for it
			strength = strength - cos(_LightAngle / 2.0f);
            // make sure that the value is between 0 and 1 for the alpha (strength determins the roll off of the invisibility)
			strength = min(max(strength * _ScaleStrength, 0), 1);

            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            if(length(direction) > 1.5)
                o.Alpha = 0;
            else{
                o.Alpha = c.a * strength;
            }
            
        }
        ENDCG
    }
    FallBack "Diffuse"
}
