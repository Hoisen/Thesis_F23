Shader "Unlit/fog"
{
    Properties
    {
         [MainTexture] _BaseMap ("BaseMap", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" "RenderPipeline"="UniversalPipeline"}

        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            //#pragma multi_compile_fog

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DeclareDepthTexture.hlsl"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 posHClip : SV_POSITION;
            };

            sampler2D _BaseMap;
            //sampler2D _CameraDepthTexture;
            float4 _BaseMap_ST;
            float4 _fogColor;
            float _fogDensity, _fogOffset;


            v2f vert (appdata IN)
            {
                v2f o;
                o.posHClip = TransformObjectToHClip(IN.vertex.xyz);
                o.uv = TRANSFORM_TEX(IN.uv, _BaseMap);
                return o;
            }

            half4 frag (v2f IN) : SV_Target
            {
                int x,y;
                float2 UV = IN.posHClip.xy / _ScaledScreenParams.xy;
                // sample the texture
                float4 col = tex2D(_BaseMap, IN.uv);
                real depth = SampleSceneDepth(UV);

                float viewDistance = depth * _ProjectionParams.z;
                float fogFactor = (_fogDensity/sqrt(log(2))) * max(0.0f, viewDistance - _fogOffset);
                fogFactor = exp2(-fogFactor * fogFactor);

                float4 fogOutput = lerp(_fogColor, col, saturate(fogFactor));
                return fogOutput;
            }
            ENDHLSL
        }
    }
}
