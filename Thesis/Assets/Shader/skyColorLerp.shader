Shader "Unlit/skyColorLerp"
{
    Properties
    {
        [MainTexture] _BaseMap ("BaseMap", 2D) = "white" {}
        _ColorA ("ColorA", Color ) = (1, 1, 1, 1)
        _ColorB ("ColorB", Color) = (1, 1, 1, 1)
        _ColorC ("ColorC", Color) = (1, 1, 1, 1)
    }
    SubShader
    {
        Tags { "RenderType" = "Opaque" "RenderPipeline" = "UniversalPipeline" }

        Pass
        {
            HLSLPROGRAM
            // This line defines the name of the vertex shader.
            #pragma vertex vert
            // This line defines the name of the fragment shader.
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DeclareDepthTexture.hlsl"
            
            struct appdata
            {
            float4 pos : POSITION;
            float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 posHClip : SV_POSITION;
            };

            sampler2D _BaseMap;
            float4 _BaseMap_ST;
            float4 _ColorA;
            float4 _ColorB;
            float4 _ColorC;

            v2f vert(appdata IN)
            {
                v2f OUT;
                OUT.uv = TRANSFORM_TEX(IN.uv, _BaseMap);
                OUT.posHClip = TransformObjectToHClip(IN.pos.xyz);
                return OUT;
            }

            half4 frag(v2f IN) : SV_Target
            {
                float t = 1-IN.uv.y;
                if(t<0.5)
                {
                    return lerp(_ColorA, _ColorB, t*2);
                }
                return lerp(_ColorB, _ColorC, (t-0.5)*2);
            }


            ENDHLSL //End
        }
    }
}
