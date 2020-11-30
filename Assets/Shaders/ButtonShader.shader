Shader "Custom/ButtonShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _NoiseMap("Noise Map", 2D) = "white" {}
        _DestortionDevider ("Destortion Devider", Range(1,15)) = 25
        _DestortionSpreader ("Destortion Spreader", Range(0.1,2)) = 2
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            sampler2D _NoiseMap;
            float4 _MainTex_ST;

            float _DestortionDevider;
            float _DestortionSpreader;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float2 offset = float2(
                    tex2D(_NoiseMap, float2(i.uv.y / _DestortionSpreader, _Time[1])).r,
                    tex2D(_NoiseMap, float2(_Time[1], i.uv.x / _DestortionSpreader) ).r );

                offset -= 0.5;
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv + offset/ _DestortionDevider);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
