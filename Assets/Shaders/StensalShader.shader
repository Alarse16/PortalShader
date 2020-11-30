Shader "Custom/StensalShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        [Enum(Equal,0,NotEqual,1)] _StencilTest ("Stencil Test", int) = 0
    }
    SubShader
    {
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
