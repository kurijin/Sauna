Shader "Custom/BurnOutShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _NoiseTex ("Noise Texture", 2D) = "white" {}
        _BurnAmount ("Burn Amount", Range(0, 1)) = 0.0
        _BurnColorRed ("Burn Color Red", Color) = (1, 0, 0, 1)
        _BurnColorOrange ("Burn Color Orange", Color) = (1, 0.5, 0, 1)
        _EdgeColor ("Edge Color", Color) = (1, 0.5, 0, 1)
        _EdgeWidth ("Edge Width", Range(0.01, 0.1)) = 0.05
        _EmissionColor ("Emission Color", Color) = (1, 0.5, 0, 1)
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
            sampler2D _NoiseTex;
            float _BurnAmount;
            fixed4 _BurnColorRed;
            fixed4 _BurnColorOrange;
            fixed4 _EdgeColor;
            float _EdgeWidth;
            fixed4 _EmissionColor;

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
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.texcoord = v.texcoord;
                return o;
            }

       fixed4 frag(v2f i) : SV_Target
        {
            fixed4 col = tex2D(_MainTex, i.texcoord);
            if(_BurnAmount == 0)   return col;

            float noiseValue = tex2D(_NoiseTex, i.texcoord).r;

            if (noiseValue + 1 - _BurnAmount > 1.1){
                return col;
            }

            float edgeFactor = smoothstep(_BurnAmount - _EdgeWidth, _BurnAmount, noiseValue);
            float orangeFactor = smoothstep(_BurnAmount, _BurnAmount + _EdgeWidth, noiseValue);

            // 赤からオレンジへの色の遷移
            col.rgb = lerp(_BurnColorRed.rgb, _BurnColorOrange.rgb, orangeFactor);

            // エミッションの適用
            if (noiseValue >= _BurnAmount && noiseValue < _BurnAmount + _EdgeWidth)
            {
                col.rgb += _EmissionColor.rgb * orangeFactor;
            }

            // 燃え尽きた部分の透明化
            if (noiseValue < _BurnAmount)
            {
                col.a = 0;
            }

            return col;
        }

            ENDCG
        }
    }
}
