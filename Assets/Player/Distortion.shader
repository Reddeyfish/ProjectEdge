Shader "Custom/Distortion"
{
	Properties
	{
		_MainTex("Main Texture", 2D) = "white"
		[PerRendererData] _DistortionStrength ("DistortionStrength", Float) = 0.1
	}
	SubShader
	{
		Tags { "Queue"="Transparent" "PreviewType"="Plane"}
		LOD 100

		GrabPass { "_GrabTexture"}

		Pass
		{
			ZWrite Off
			Blend One Zero
			Lighting Off
			Fog { Mode Off }
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			
			struct appdata
			{
				half2 uv : TEXCOORD0;
				float4 vertex : POSITION;
			};

			struct v2f
			{
				half2 uv : TEXCOORD0;
				float4 uv_grab : TEXCOORD1;
				float4 vertex : SV_POSITION;
			};

			sampler2D _GrabTexture;
			sampler2D _MainTex;
			half _DistortionStrength;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.uv = v.uv;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv_grab = ComputeGrabScreenPos(o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : COLOR
			{
            	float2 distortion = tex2D(_MainTex, i.uv).rg;

                //convert from [0..1] to [-1..1];
                distortion *= 2;
                distortion -= 1;

				float2 distortionVector = _DistortionStrength * distortion;
				float4 distortedGrabUVs = i.uv_grab;
				distortedGrabUVs.xy -= distortionVector;
				fixed4 col = tex2Dproj(_GrabTexture, UNITY_PROJ_COORD(distortedGrabUVs));

				return col;
			}
			ENDCG
		}
	}
}
