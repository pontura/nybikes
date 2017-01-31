// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4013,x:33378,y:32421,varname:node_4013,prsc:2|diff-5926-OUT,normal-8343-RGB,lwrap-9379-RGB;n:type:ShaderForge.SFN_Tex2d,id:1145,x:31945,y:32379,ptovrint:False,ptlb:BaseGrass,ptin:_BaseGrass,varname:node_1145,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:49666bacb77a04d8b8be3c678bd0836e,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:8343,x:32237,y:33206,ptovrint:False,ptlb:Normal,ptin:_Normal,varname:node_8343,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:4062f257aa2524ca79718c06a3aa5a82,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:1004,x:31930,y:32587,ptovrint:False,ptlb:GrassTexture,ptin:_GrassTexture,varname:node_1004,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:1ffaa7097d91a456e9a9645a016b9614,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Lerp,id:9144,x:32245,y:32374,varname:node_9144,prsc:2|A-1145-RGB,B-1004-RGB,T-5478-RGB;n:type:ShaderForge.SFN_VertexColor,id:5478,x:31885,y:32825,varname:node_5478,prsc:2;n:type:ShaderForge.SFN_Slider,id:5751,x:32192,y:33008,ptovrint:False,ptlb:RockSIze,ptin:_RockSIze,varname:node_5751,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.1251826,max:1;n:type:ShaderForge.SFN_Multiply,id:9229,x:32521,y:32952,varname:node_9229,prsc:2|A-5478-A,B-5751-OUT;n:type:ShaderForge.SFN_Lerp,id:2536,x:32493,y:32407,varname:node_2536,prsc:2|A-9144-OUT,B-2595-RGB,T-5478-R;n:type:ShaderForge.SFN_Tex2d,id:2595,x:32238,y:32637,ptovrint:False,ptlb:Rocks,ptin:_Rocks,varname:node_2595,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:1d385e83caced462db5d426da16fae42,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:1171,x:32481,y:32675,ptovrint:False,ptlb:BaseGrass2,ptin:_BaseGrass2,varname:node_1171,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:03c585902fe344178a9c857982ff073b,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Lerp,id:2736,x:32927,y:32421,varname:node_2736,prsc:2|A-5589-OUT,B-9930-RGB,T-5478-B;n:type:ShaderForge.SFN_Lerp,id:5589,x:32713,y:32421,varname:node_5589,prsc:2|A-2536-OUT,B-1171-RGB,T-5478-G;n:type:ShaderForge.SFN_Tex2d,id:9930,x:32655,y:32785,ptovrint:False,ptlb:Rock2,ptin:_Rock2,varname:node_9930,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:1d385e83caced462db5d426da16fae42,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Lerp,id:5926,x:33125,y:32421,varname:node_5926,prsc:2|A-2736-OUT,B-255-RGB,T-9229-OUT;n:type:ShaderForge.SFN_Tex2d,id:255,x:32892,y:32825,ptovrint:False,ptlb:Noise,ptin:_Noise,varname:node_255,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Color,id:9379,x:33149,y:32683,ptovrint:False,ptlb:colour,ptin:_colour,varname:node_9379,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.05103806,c2:0.05240252,c3:0.05882353,c4:1;proporder:8343-1145-5751-1004-2595-1171-9930-255-9379;pass:END;sub:END;*/

Shader "Shader Forge/P_Garden" {
    Properties {
        _Normal ("Normal", 2D) = "bump" {}
        _BaseGrass ("BaseGrass", 2D) = "white" {}
        _RockSIze ("RockSIze", Range(0, 1)) = 0.1251826
        _GrassTexture ("GrassTexture", 2D) = "white" {}
        _Rocks ("Rocks", 2D) = "black" {}
        _BaseGrass2 ("BaseGrass2", 2D) = "black" {}
        _Rock2 ("Rock2", 2D) = "white" {}
        _Noise ("Noise", 2D) = "black" {}
        _colour ("colour", Color) = (0.05103806,0.05240252,0.05882353,1)
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _BaseGrass; uniform float4 _BaseGrass_ST;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform sampler2D _GrassTexture; uniform float4 _GrassTexture_ST;
            uniform float _RockSIze;
            uniform sampler2D _Rocks; uniform float4 _Rocks_ST;
            uniform sampler2D _BaseGrass2; uniform float4 _BaseGrass2_ST;
            uniform sampler2D _Rock2; uniform float4 _Rock2_ST;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform float4 _colour;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                float4 vertexColor : COLOR;
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _Normal_var = UnpackNormal(tex2D(_Normal,TRANSFORM_TEX(i.uv0, _Normal)));
                float3 normalLocal = _Normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float3 w = _colour.rgb*0.5; // Light wrapping
                float3 NdotLWrap = NdotL * ( 1.0 - w );
                float3 forwardLight = max(float3(0.0,0.0,0.0), NdotLWrap + w );
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = forwardLight * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 _BaseGrass_var = tex2D(_BaseGrass,TRANSFORM_TEX(i.uv0, _BaseGrass));
                float4 _GrassTexture_var = tex2D(_GrassTexture,TRANSFORM_TEX(i.uv0, _GrassTexture));
                float4 _Rocks_var = tex2D(_Rocks,TRANSFORM_TEX(i.uv0, _Rocks));
                float4 _BaseGrass2_var = tex2D(_BaseGrass2,TRANSFORM_TEX(i.uv0, _BaseGrass2));
                float4 _Rock2_var = tex2D(_Rock2,TRANSFORM_TEX(i.uv0, _Rock2));
                float4 _Noise_var = tex2D(_Noise,TRANSFORM_TEX(i.uv0, _Noise));
                float3 diffuseColor = lerp(lerp(lerp(lerp(lerp(_BaseGrass_var.rgb,_GrassTexture_var.rgb,i.vertexColor.rgb),_Rocks_var.rgb,i.vertexColor.r),_BaseGrass2_var.rgb,i.vertexColor.g),_Rock2_var.rgb,i.vertexColor.b),_Noise_var.rgb,(i.vertexColor.a*_RockSIze));
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _BaseGrass; uniform float4 _BaseGrass_ST;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform sampler2D _GrassTexture; uniform float4 _GrassTexture_ST;
            uniform float _RockSIze;
            uniform sampler2D _Rocks; uniform float4 _Rocks_ST;
            uniform sampler2D _BaseGrass2; uniform float4 _BaseGrass2_ST;
            uniform sampler2D _Rock2; uniform float4 _Rock2_ST;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform float4 _colour;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                float4 vertexColor : COLOR;
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _Normal_var = UnpackNormal(tex2D(_Normal,TRANSFORM_TEX(i.uv0, _Normal)));
                float3 normalLocal = _Normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float3 w = _colour.rgb*0.5; // Light wrapping
                float3 NdotLWrap = NdotL * ( 1.0 - w );
                float3 forwardLight = max(float3(0.0,0.0,0.0), NdotLWrap + w );
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = forwardLight * attenColor;
                float4 _BaseGrass_var = tex2D(_BaseGrass,TRANSFORM_TEX(i.uv0, _BaseGrass));
                float4 _GrassTexture_var = tex2D(_GrassTexture,TRANSFORM_TEX(i.uv0, _GrassTexture));
                float4 _Rocks_var = tex2D(_Rocks,TRANSFORM_TEX(i.uv0, _Rocks));
                float4 _BaseGrass2_var = tex2D(_BaseGrass2,TRANSFORM_TEX(i.uv0, _BaseGrass2));
                float4 _Rock2_var = tex2D(_Rock2,TRANSFORM_TEX(i.uv0, _Rock2));
                float4 _Noise_var = tex2D(_Noise,TRANSFORM_TEX(i.uv0, _Noise));
                float3 diffuseColor = lerp(lerp(lerp(lerp(lerp(_BaseGrass_var.rgb,_GrassTexture_var.rgb,i.vertexColor.rgb),_Rocks_var.rgb,i.vertexColor.r),_BaseGrass2_var.rgb,i.vertexColor.g),_Rock2_var.rgb,i.vertexColor.b),_Noise_var.rgb,(i.vertexColor.a*_RockSIze));
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
