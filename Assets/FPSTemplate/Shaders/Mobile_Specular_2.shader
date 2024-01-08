Shader "AliyerEdon/Mobile_Specular_2.0" 
{
	Properties {
		_Power("Diffuse Power",Float) = 1
		_MainTex ("Base (RGB) Gloss (A)", 2D) = "white" {}
		_SpecColor ("Specular Color", Color) = (0.5, 0.5, 0.5, 1)
		_Shininess ("Shininess", Range (0.01, 1)) = 0.078125
		_GlossTex ("_GlossTex", 2D) = "white" {}
		_ReflectPower("_ReflectPower",Float) = 1
		_Cube ("Cubemap", CUBE) = "" {}
	}

	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf BlinnPhong //vertex:vert

		sampler2D _MainTex;
		half _Shininess;
		sampler2D _GlossTex;
	    float _ReflectPower;
	    samplerCUBE _Cube;
	    float _Power;

		struct Input {
			float2 uv_MainTex;
			float2 uv_GlossTex;
		    float3 worldRefl;
		};

		void surf (Input IN, inout SurfaceOutput o)
		{
			fixed4 tex = tex2D(_MainTex, IN.uv_MainTex);
			fixed4  d_tex = tex2D(_GlossTex, IN.uv_MainTex);
			
			o.Albedo = tex.rgb * _Power;
			
			o.Alpha = 1;
			
			o.Gloss = d_tex.r;
			
			o.Specular = _Shininess;

			o.Emission = texCUBE (_Cube, IN.worldRefl).rgb * _ReflectPower*d_tex.r*_Shininess*10;
		}

		ENDCG
	}

	Fallback "MobileSpecular"
}
