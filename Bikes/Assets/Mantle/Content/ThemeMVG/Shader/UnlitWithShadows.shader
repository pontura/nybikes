Shader "Mantle/UnlitWithShadows" 
{
    Properties {
        // While these two values do nothing for your shader, the fallback shader "VertexLit" requires them for your mesh to cast/recieve shadows.
        _Color ("Main Color", Color) = (1.0, 1.0, 1.0, 1.0)
        _MainTex ("Color (RGBA)", 2D) = "white" {}
    }
 
    SubShader {
        Tags {"Queue" = "Geometry" "RenderType" = "Opaque" "LightMode" = "Always" "LightMode" = "ForwardBase"}
       
        Pass {
            CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #pragma multi_compile_fwdbase
                #pragma fragmentoption ARB_precision_hint_fastest
               
                #include "UnityCG.cginc"
                #include "AutoLight.cginc"
 
                // If you really want separate shadow and falloff values, uncomment the commented out lines below - the ones starting with //
                // As Unity Free only supports shadows from one directional light anyway, there's no real need as directional lights have no falloff.
 
                //#include "CustomLight.cginc"

                sampler2D _MainTex;
				float4 _MainTex_ST;

                struct appdata {
                    float4 vertex   :   POSITION;
                    fixed2 uv    :   TEXCOORD0;
                };
 
                struct v2f
                {
                    float4  pos     :   SV_POSITION;
                    float2 uv 		: 	TEXCOORD0;
                    LIGHTING_COORDS(1, 2) // This tells it to put the vertex attributes required for lighting into TEXCOORD1 and TEXCOORD2.
                };
 
                v2f vert (appdata v)
                {
                    v2f o;
                    o.pos = mul( UNITY_MATRIX_MVP, v.vertex);
					o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                    
                    TRANSFER_VERTEX_TO_FRAGMENT(o) // This sets up the vertex attributes required for lighting and passes them through to the fragment shader.
                    return o;
                }
 
                fixed4 frag(v2f i) : COLOR
                {
                   
                    fixed atten = LIGHT_ATTENUATION(i); // This gets the shadow and attenuation values combined.
                    //fixed falloff = LIGHT_FALLOFF(i); // This is a custom one to get just the attenuation value. Requires CustomLight.cginc to be included.
                    //fixed shadow = SHADOW_ATTENUATION(i); // This is gets just the shadow value - it's basically a fixed precision float where 1 is in light and 0 is in shadow.

                    fixed4 col = tex2D(_MainTex, i.uv);
                    col.rgb *= atten;
                    return col;
                }
            ENDCG
        }
    }
    FallBack "VertexLit"
}