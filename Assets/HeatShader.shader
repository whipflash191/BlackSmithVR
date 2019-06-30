/*
* Copyright (c) Dylan Faith (Whipflash191)
* https://twitter.com/Whipflash191
*/

Shader "Custom/NewSurfaceShader"
{
	Properties
	{
		_BaseColor("Base Color", Color) = (1,1,1,1)
		_RedHeat("Cherry Red Heat", Color) = (1,1,1,1)
		_OrangeHeat("Orange Heat", Color) = (1,1,1,1)
		_HeatLerp("Heat Lerp", Range(0,2)) = 0
		[Toggle]_Emission("Enable Emission", Float) = 0
		[HDR]_EmissionColor("Emission", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 1
        _Metallic ("Metallic", Range(0,1)) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows
		#pragma multi_compile _EMISSION _EMISSION_ON

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        half _Glossiness;
        half _Metallic;
		half _HeatLerp;
		fixed4 _EmissionColor;
        fixed4 _BaseColor;
		fixed4 _RedHeat;
		fixed4 _OrangeHeat;
		fixed4 _ColorLerp;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

			void surf(Input IN, inout SurfaceOutputStandard o)
		{
			// Albedo comes from a texture tinted by color
			if (_HeatLerp <= 1)
			{
				_Metallic -= _HeatLerp;
				_Glossiness -= _HeatLerp;
				_ColorLerp = lerp(_BaseColor, _RedHeat, _HeatLerp);
			}
			else if (_HeatLerp <= 2)
			{
				_Metallic = 0;
				_Glossiness = 0;
				_ColorLerp = lerp(_RedHeat, _OrangeHeat, (_HeatLerp - 1));
			}
			_EmissionColor.rgba = _ColorLerp.rgba;
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _ColorLerp;
			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
			#ifdef _EMISSION_ON
				o.Emission = _EmissionColor;
			#endif
        }
        ENDCG
    }
    FallBack "Diffuse"
}
