Shader "Custom/RainbowRoad" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Colour ("Transparency (A only)", Color) = (1, 1, 1, 1)
		_SpecColor ("Specular Color", Color) = (0.5, 0.5, 0.5, 1)
		_Shininess ("Shininess", Range (0.01, 1)) = 0.078125
		_ReflectColor ("Reflection Color", Color) = (1,1,1,0.5)
		_Cube ("Reflection Cubemap", Cube) = "black" { TexGen CubeReflect }
	}
	SubShader {
		Tags {
			"Queue"="Transparent"
			"IgnoreProjector"="True"
			"RenderType"="Transparent"
		}
		LOD 300
		
		CGPROGRAM
			#pragma surface surf BlinnPhong decal:add nolightmap
			
			sampler2D _MainTex;
			samplerCUBE _Cube;
			fixed4 _Colour;
			fixed4 _ReflectColor;
			half _Shininess;
			
			struct Input {
				float3 worldRefl;
				float2 uv_MainTex;
            	float3 viewDir; 
			};
			
			void surf (Input IN, inout SurfaceOutput o) {
				half4 c = tex2D (_MainTex, IN.uv_MainTex);
            	o.Albedo = c.rgb;
            	o.Alpha = _Colour;
				o.Gloss = 1;
				o.Specular = _Shininess;
				
				fixed4 reflcol = texCUBE (_Cube, IN.worldRefl);
				o.Emission = reflcol.rgb * _ReflectColor.rgb;
				o.Alpha = reflcol.a * _ReflectColor.a;
			}
		ENDCG
	}
	FallBack "Transparent/VertexLit"
}