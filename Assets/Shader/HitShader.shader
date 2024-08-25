Shader "Custom/HitShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _HitColor ("HitColor", Color) = (1, 0, 0, 1)
        _OriginalColor ("OriginalColor", Color) = (1, 1, 1, 1)
        _ShakeOffset ("ShakeOffset", Vector) = (0, 0, 0, 0)
        _EffectTime ("EffectTime", Float) = 0.0
    }
    SubShader
    {
        Tags {"Queue"="Transparent"}
        Blend SrcAlpha OneMinusSrcAlpha
        Lighting Off
        ZWrite Off
        Cull Off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            sampler2D _MainTex;
            float4 _HitColor;
            float4 _OriginalColor;
            float4 _ShakeOffset;
            float _EffectTime;

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
            };

            struct v2f
            {
                float2 texcoord : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert(appdata_t v)
            {
                v2f o;

                v.vertex.xy += _ShakeOffset.xy;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.texcoord = v.texcoord;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.texcoord);

                float effectProgress = _EffectTime * 2.0f;
                if (effectProgress > 1.0f) effectProgress = 2.0f - effectProgress;
                col.rgb = lerp(_OriginalColor.rgb, _HitColor.rgb, effectProgress);
                return col;
            }

            ENDCG
        }
    }
}
