Shader "Custom/FogEffectWithNoise"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _FogColor ("Fog Color", Color) = (0.5, 0.5, 0.5, 1)
        _FogDensity ("Fog Density", Range(0.0, 1.0)) = 0.1
        _NoiseTex ("Noise Texture", 2D) = "white" {}
        _NoiseScale ("Noise Scale", Range(0.1, 1.0)) = 1.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _FogColor;
            float _FogDensity;
            sampler2D _NoiseTex;
            float _NoiseScale;
            float2 _NoiseOffset;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                const float log2e = 1.442695;

                fixed4 col = tex2D(_MainTex, i.uv);
                
                float2 noiseUV = frac(i.uv * _NoiseScale + _NoiseOffset); 
                float noise = tex2D(_NoiseTex, noiseUV).r;

                float depth = i.vertex.z / i.vertex.w;
                
                float fogFactor = exp2(-(_FogDensity * noise) * depth *log2e);
                fogFactor = clamp(fogFactor, 0.0, 1.0);
                
                return lerp(_FogColor, col, fogFactor);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
