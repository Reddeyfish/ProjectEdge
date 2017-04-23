Shader "Unlit/Drain"
{
	Properties
	{
		_MainTex ("Mask", 2D) = "white" {}
        _NoiseTex ("Noise", 2D) = "white" {}
        _Color0("Color", Color) = (0, 0, 0, 1)
        _Color1("Color", Color) = (0, 0, 0, 1)
        _MainOffset("Main Offset", Vector) = (1, 0, 2, 0)
        _NoiseOffset("Noise Offset", Vector) = (1, 1, 2, -1)
        _PreMulAlpha("Premultiplicated Alpha Multiplier", Float) = 1.2
	}
	SubShader
	{
		Tags { "RenderType" = "Transparent" "Queue" = "Transparent" "IgnoreProjector" = "True" "PreviewType"="Plane" }
    	LOD 100

		Pass
		{
            Blend One OneMinusSrcAlpha
			
            CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"


			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
                float4 color    : COLOR;
			};

			struct v2f
			{
				float2 mainUV0 : TEXCOORD0;
				float2 mainUV1 : TEXCOORD1;
                float2 noiseUV0 : TEXCOORD2;
				float4 vertex : SV_POSITION;
                float4 color : COLOR0;
			};

			sampler2D _MainTex;
            float4 _MainTex_ST;
            sampler2D _NoiseTex;
            float4 _NoiseTex_ST;
            half4 _Color0;
            half4 _Color1;
            float4 _MainOffset;
            float4 _NoiseOffset;
            half _PreMulAlpha;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
                o.mainUV0 = TRANSFORM_TEX(v.uv, _MainTex) + _Time.yy * _MainOffset.xy;
                o.mainUV1 = TRANSFORM_TEX(v.uv, _MainTex) + _Time.yy * _MainOffset.zw;
				o.noiseUV0 = TRANSFORM_TEX(v.uv, _NoiseTex) + _Time.yy * _NoiseOffset.xy;
                o.color = v.color;
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				half col = tex2D(_MainTex, i.mainUV0).r + tex2D(_MainTex, i.mainUV1).r;
				half noise = tex2D(_NoiseTex, i.noiseUV0).r;
                half alpha = col * noise * _Color0.a * i.color.a;
                half3 color = lerp(_Color0, _Color1, alpha) * i.color.rgb;
				return fixed4(color * alpha * _PreMulAlpha, alpha);
			}
			ENDCG
		}
	}
}
