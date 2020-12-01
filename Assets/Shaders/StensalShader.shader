Shader "Custom/StensalShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        [Enum(Equal,3,NotEqual,6)] _StencilTest ("Stencil Test", int) = 3
    }
    SubShader
    {
        Tags { "RenderType" = "Opaque" }
        LOD 1000
        Color [_Color]

        Stencil
        {
            Ref 1
            Comp [_StencilTest]
        }

        Pass
        {
            
        }
    }
}
