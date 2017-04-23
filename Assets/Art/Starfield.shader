Shader "Unlit/Starfield"
{
	Properties
	{
		_MainTex ("Mask", 2D) = "white" {}
        _Scale("Scale", Float) = 0.1
	}
	SubShader
	{
		Tags { "RenderType" = "Transparent" "Queue" = "Transparent" "IgnoreProjector" = "True" "PreviewType"="Plane" }
    	LOD 100

		Pass
		{
            Blend SrcAlpha OneMinusSrcAlpha
			
            CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"


			struct appdata
			{
				float4 vertex : POSITION;
			};

			struct v2f
			{
				float2 mainUV : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
            float _Scale;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
                float2 worldPosition = mul(unity_ObjectToWorld, float4(v.vertex.xyz, 1.0)).xy;
                o.mainUV = worldPosition * _Scale;
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
                return tex2D(_MainTex, i.mainUV);
			}
			ENDCG
		}
	}
}
