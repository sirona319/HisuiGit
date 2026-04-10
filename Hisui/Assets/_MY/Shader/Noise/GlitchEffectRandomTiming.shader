//https://toconakis.tech/unity-glitchnoise/

Shader "Custom/GlitchEffectRandomTiming" {
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
        _BlockSize ("Block Size", Range(1, 100)) = 20
        _GlitchAmount ("Glitch Amount", Range(0, 1)) = 0.1
        _GlitchFrequency ("Glitch Frequency", Range(0.1, 2.0)) = 1
        _GlitchDuration ("Glitch Duration", Range(0.1, 2.0)) = 0.5
    }
    SubShader {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        LOD 100

        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off
        AlphaToMask Off

        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float _BlockSize;
            float _GlitchAmount;
            float _GlitchFrequency;
            float _GlitchDuration;

            v2f vert (appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            float random(float2 uv) {
                return frac(sin(dot(uv, float2(12.9898, 78.233))) * 43758.5453);
            }

            fixed4 frag (v2f i) : SV_Target {
                float2 uv = i.uv;
                float glitchTime = floor(_Time.y / _GlitchFrequency) * _GlitchFrequency;
                float glitchActive = step(glitchTime, _Time.y) * step(_Time.y, glitchTime + _GlitchDuration);

                float2 block = floor(uv * _BlockSize) / _BlockSize;
                float offset = random(float2(block.y, glitchTime)) * _GlitchAmount * glitchActive;

                fixed4 color = tex2D(_MainTex, uv + float2(offset, 0));
                return color;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}