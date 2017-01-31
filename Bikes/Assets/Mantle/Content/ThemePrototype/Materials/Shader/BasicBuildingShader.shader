// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:2865,x:36754,y:34266,varname:node_2865,prsc:2|diff-6343-OUT,spec-358-OUT,gloss-1813-OUT,normal-1414-OUT;n:type:ShaderForge.SFN_Multiply,id:6343,x:34961,y:33187,varname:node_6343,prsc:2|A-9517-OUT,B-6647-OUT;n:type:ShaderForge.SFN_Color,id:6665,x:33561,y:32446,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Tex2d,id:7736,x:32053,y:32005,ptovrint:False,ptlb:Surface Dif,ptin:_SurfaceDif,varname:_SurfaceDif,prsc:2,glob:False,taghide:True,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-9680-OUT;n:type:ShaderForge.SFN_Tex2d,id:5964,x:32036,y:32709,ptovrint:False,ptlb:Surface NRM,ptin:_SurfaceNRM,varname:_SurfaceNRM,prsc:2,glob:False,taghide:True,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True|UVIN-9680-OUT;n:type:ShaderForge.SFN_Slider,id:358,x:34897,y:34080,ptovrint:False,ptlb:Metallic,ptin:_Metallic,varname:_Metallic,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:1813,x:34897,y:34207,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:_Gloss,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.8,max:1;n:type:ShaderForge.SFN_Dot,id:362,x:31257,y:33765,varname:node_362,prsc:2,dt:3|A-2222-OUT,B-6545-OUT;n:type:ShaderForge.SFN_NormalVector,id:768,x:30522,y:33981,prsc:2,pt:False;n:type:ShaderForge.SFN_Vector3,id:2222,x:30927,y:33818,varname:node_2222,prsc:2,v1:1,v2:0,v3:0;n:type:ShaderForge.SFN_Dot,id:3863,x:31122,y:33594,varname:node_3863,prsc:2,dt:3|A-6545-OUT,B-9149-OUT;n:type:ShaderForge.SFN_Tex2d,id:4765,x:32511,y:33874,varname:_EdgeNormalmap,prsc:2,ntxv:0,isnm:False|UVIN-5179-OUT,TEX-6766-TEX;n:type:ShaderForge.SFN_Lerp,id:6191,x:33948,y:33540,varname:node_6191,prsc:2|A-8339-OUT,B-3869-OUT,T-3937-OUT;n:type:ShaderForge.SFN_TexCoord,id:2901,x:28750,y:33360,varname:node_2901,prsc:2,uv:0;n:type:ShaderForge.SFN_Multiply,id:9431,x:31390,y:33859,varname:node_9431,prsc:2|A-2031-OUT,B-4941-OUT;n:type:ShaderForge.SFN_Append,id:8675,x:31703,y:33897,varname:node_8675,prsc:2|A-9431-OUT,B-3016-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:6766,x:32052,y:33641,ptovrint:False,ptlb:Edge NRM,ptin:_EdgeNRM,varname:_EdgeNRM,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:453,x:32511,y:33681,varname:_node_453,prsc:2,ntxv:0,isnm:False|UVIN-8061-OUT,TEX-6766-TEX;n:type:ShaderForge.SFN_Append,id:2902,x:31703,y:34094,varname:node_2902,prsc:2|A-8287-OUT,B-3016-OUT;n:type:ShaderForge.SFN_Multiply,id:8287,x:31403,y:34033,varname:node_8287,prsc:2|A-7741-OUT,B-4941-OUT;n:type:ShaderForge.SFN_Lerp,id:3869,x:32958,y:33755,varname:node_3869,prsc:2|A-453-RGB,B-4765-RGB,T-9031-B;n:type:ShaderForge.SFN_Add,id:7278,x:33140,y:34072,varname:node_7278,prsc:2|A-105-OUT,B-7626-OUT;n:type:ShaderForge.SFN_Relay,id:3016,x:31432,y:34267,cmnt:World Y,varname:node_3016,prsc:2|IN-312-OUT;n:type:ShaderForge.SFN_Step,id:7626,x:32904,y:34221,varname:node_7626,prsc:2|A-8287-OUT,B-4311-B;n:type:ShaderForge.SFN_Step,id:105,x:32904,y:34029,varname:node_105,prsc:2|A-9431-OUT,B-9031-B;n:type:ShaderForge.SFN_OneMinus,id:2048,x:31145,y:34492,varname:node_2048,prsc:2|IN-2031-OUT;n:type:ShaderForge.SFN_Multiply,id:6558,x:31403,y:34394,varname:node_6558,prsc:2|A-2031-OUT,B-6321-OUT;n:type:ShaderForge.SFN_Multiply,id:2854,x:31403,y:34612,varname:node_2854,prsc:2|A-2048-OUT,B-6321-OUT;n:type:ShaderForge.SFN_Append,id:7732,x:31709,y:34410,varname:node_7732,prsc:2|A-6558-OUT,B-3016-OUT;n:type:ShaderForge.SFN_Append,id:360,x:31709,y:34590,varname:node_360,prsc:2|A-2854-OUT,B-3016-OUT;n:type:ShaderForge.SFN_Lerp,id:5179,x:32094,y:34062,varname:node_5179,prsc:2|A-7732-OUT,B-8675-OUT,T-2062-OUT;n:type:ShaderForge.SFN_Lerp,id:8061,x:32101,y:34353,varname:node_8061,prsc:2|A-360-OUT,B-2902-OUT,T-2062-OUT;n:type:ShaderForge.SFN_Step,id:9264,x:32904,y:34515,varname:node_9264,prsc:2|A-6558-OUT,B-9031-B;n:type:ShaderForge.SFN_Step,id:5163,x:32904,y:34730,varname:node_5163,prsc:2|A-2854-OUT,B-4311-B;n:type:ShaderForge.SFN_Add,id:9927,x:33150,y:34627,varname:node_9927,prsc:2|A-9264-OUT,B-5163-OUT;n:type:ShaderForge.SFN_Lerp,id:3937,x:33444,y:34316,varname:node_3937,prsc:2|A-9927-OUT,B-7278-OUT,T-362-OUT;n:type:ShaderForge.SFN_OneMinus,id:7741,x:31127,y:34039,varname:node_7741,prsc:2|IN-2031-OUT;n:type:ShaderForge.SFN_Tex2d,id:4512,x:32037,y:33018,ptovrint:False,ptlb:Window NRM,ptin:_WindowNRM,varname:_WindowNRM,prsc:2,glob:False,taghide:True,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True|UVIN-9680-OUT;n:type:ShaderForge.SFN_Lerp,id:8339,x:32573,y:32960,varname:node_8339,prsc:2|A-5964-RGB,B-4512-RGB,T-4640-A;n:type:ShaderForge.SFN_Relay,id:2062,x:31689,y:33649,varname:node_2062,prsc:2|IN-362-OUT;n:type:ShaderForge.SFN_OneMinus,id:7028,x:32372,y:32536,varname:node_7028,prsc:2|IN-4640-A;n:type:ShaderForge.SFN_Vector3,id:9149,x:30879,y:33664,varname:node_9149,prsc:2,v1:0,v2:1,v3:0;n:type:ShaderForge.SFN_Transform,id:1214,x:30743,y:33996,varname:node_1214,prsc:2,tffrom:0,tfto:1|IN-768-OUT;n:type:ShaderForge.SFN_Normalize,id:6545,x:30927,y:33981,varname:node_6545,prsc:2|IN-1214-XYZ;n:type:ShaderForge.SFN_Multiply,id:1959,x:30657,y:31869,varname:node_1959,prsc:2|A-4960-OUT,B-4600-OUT;n:type:ShaderForge.SFN_ObjectScale,id:2057,x:28700,y:33805,varname:node_2057,prsc:2,rcp:False;n:type:ShaderForge.SFN_Append,id:9196,x:30906,y:31944,cmnt:facing Z,varname:node_9196,prsc:2|A-1959-OUT,B-2620-OUT;n:type:ShaderForge.SFN_Multiply,id:2620,x:30657,y:32015,varname:node_2620,prsc:2|A-5137-OUT,B-8111-OUT;n:type:ShaderForge.SFN_Append,id:4534,x:30908,y:32224,cmnt:Facing X,varname:node_4534,prsc:2|A-1166-OUT,B-1802-OUT;n:type:ShaderForge.SFN_Multiply,id:1166,x:30657,y:32149,varname:node_1166,prsc:2|A-4960-OUT,B-5879-OUT;n:type:ShaderForge.SFN_Multiply,id:1802,x:30657,y:32293,varname:node_1802,prsc:2|A-5137-OUT,B-8111-OUT;n:type:ShaderForge.SFN_Append,id:2007,x:30908,y:32466,cmnt:Facing Y,varname:node_2007,prsc:2|A-9161-OUT,B-5049-OUT;n:type:ShaderForge.SFN_Multiply,id:9161,x:30657,y:32427,varname:node_9161,prsc:2|A-4960-OUT,B-4600-OUT;n:type:ShaderForge.SFN_Multiply,id:5049,x:30657,y:32550,varname:node_5049,prsc:2|A-5137-OUT,B-5879-OUT;n:type:ShaderForge.SFN_Multiply,id:312,x:31127,y:34269,varname:node_312,prsc:2|A-6016-OUT,B-6001-OUT;n:type:ShaderForge.SFN_Relay,id:6321,x:30551,y:33841,cmnt:Object X,varname:node_6321,prsc:2|IN-9822-OUT;n:type:ShaderForge.SFN_Relay,id:6001,x:30568,y:33630,cmnt:Object Y,varname:node_6001,prsc:2|IN-3465-OUT;n:type:ShaderForge.SFN_Relay,id:4941,x:30551,y:33733,cmnt:Object Z,varname:node_4941,prsc:2|IN-7104-OUT;n:type:ShaderForge.SFN_Relay,id:4600,x:30082,y:32301,cmnt:Object X,varname:node_4600,prsc:2|IN-9822-OUT;n:type:ShaderForge.SFN_Relay,id:8111,x:30083,y:32417,cmnt:Object Y,varname:node_8111,prsc:2|IN-3465-OUT;n:type:ShaderForge.SFN_Relay,id:5879,x:30079,y:32541,cmnt:Object Z,varname:node_5879,prsc:2|IN-7104-OUT;n:type:ShaderForge.SFN_Relay,id:2031,x:30522,y:34237,cmnt:UV Space U,varname:node_2031,prsc:2|IN-2901-U;n:type:ShaderForge.SFN_Relay,id:6016,x:30522,y:34398,cmnt:UV Space V,varname:node_6016,prsc:2|IN-2901-V;n:type:ShaderForge.SFN_Relay,id:4960,x:30205,y:32039,cmnt:UV Space U,varname:node_4960,prsc:2|IN-2901-U;n:type:ShaderForge.SFN_Relay,id:5137,x:30205,y:32156,cmnt:UV Space V,varname:node_5137,prsc:2|IN-2901-V;n:type:ShaderForge.SFN_Tex2d,id:3543,x:34123,y:35763,ptovrint:False,ptlb:Ground NRM,ptin:_GroundNRM,varname:_GroundNRM,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True|UVIN-7507-OUT;n:type:ShaderForge.SFN_Tex2d,id:4399,x:34123,y:35514,ptovrint:False,ptlb:Roof NRM,ptin:_RoofNRM,varname:_RoofNRM,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True|UVIN-3306-OUT;n:type:ShaderForge.SFN_Lerp,id:5550,x:35116,y:35641,cmnt:Bot top and mid lerp,varname:node_5550,prsc:2|A-3543-RGB,B-2544-OUT,T-2761-OUT;n:type:ShaderForge.SFN_Relay,id:541,x:32475,y:35680,cmnt:UV Space U,varname:node_541,prsc:2|IN-2901-U;n:type:ShaderForge.SFN_Relay,id:1132,x:32475,y:35851,cmnt:UV Space V,varname:node_1132,prsc:2|IN-2901-V;n:type:ShaderForge.SFN_Multiply,id:273,x:33146,y:35864,varname:node_273,prsc:2|A-1132-OUT,B-3142-OUT;n:type:ShaderForge.SFN_Append,id:7507,x:33602,y:35918,varname:node_7507,prsc:2|A-5239-OUT,B-273-OUT;n:type:ShaderForge.SFN_Tex2d,id:5971,x:33949,y:36336,varname:_TopBotMask,prsc:2,ntxv:0,isnm:False|UVIN-7507-OUT,TEX-8991-TEX;n:type:ShaderForge.SFN_Clamp01,id:2761,x:34534,y:36343,varname:node_2761,prsc:2|IN-5971-G;n:type:ShaderForge.SFN_Lerp,id:2544,x:34742,y:35301,cmnt:Top mid lerp,varname:node_2544,prsc:2|A-6191-OUT,B-4399-RGB,T-1469-OUT;n:type:ShaderForge.SFN_Append,id:3306,x:33534,y:35459,varname:node_3306,prsc:2|A-5239-OUT,B-2519-OUT;n:type:ShaderForge.SFN_OneMinus,id:6243,x:32835,y:35222,varname:node_6243,prsc:2|IN-1132-OUT;n:type:ShaderForge.SFN_Multiply,id:3819,x:33074,y:35222,varname:node_3819,prsc:2|A-6243-OUT,B-3142-OUT;n:type:ShaderForge.SFN_OneMinus,id:2519,x:33262,y:35222,varname:node_2519,prsc:2|IN-3819-OUT;n:type:ShaderForge.SFN_Step,id:7439,x:33943,y:35309,varname:node_7439,prsc:2|A-8021-OUT,B-2519-OUT;n:type:ShaderForge.SFN_Vector1,id:8021,x:33768,y:35266,varname:node_8021,prsc:2,v1:0.01;n:type:ShaderForge.SFN_Relay,id:2039,x:32527,y:35370,cmnt:Object X,varname:node_2039,prsc:2|IN-9822-OUT;n:type:ShaderForge.SFN_Relay,id:3142,x:32527,y:35462,cmnt:Object Y,varname:node_3142,prsc:2|IN-3465-OUT;n:type:ShaderForge.SFN_Relay,id:8886,x:32527,y:35574,cmnt:Object Z,varname:node_8886,prsc:2|IN-7104-OUT;n:type:ShaderForge.SFN_Lerp,id:5239,x:33262,y:35461,varname:node_5239,prsc:2|A-200-OUT,B-2274-OUT,T-5245-OUT;n:type:ShaderForge.SFN_Relay,id:5245,x:32934,y:35330,cmnt:Is facing X,varname:node_5245,prsc:2|IN-362-OUT;n:type:ShaderForge.SFN_Multiply,id:200,x:32937,y:35454,varname:node_200,prsc:2|A-2039-OUT,B-541-OUT;n:type:ShaderForge.SFN_Multiply,id:2274,x:32937,y:35643,varname:node_2274,prsc:2|A-8886-OUT,B-541-OUT;n:type:ShaderForge.SFN_Relay,id:387,x:33621,y:32719,cmnt:UV Space V,varname:node_387,prsc:2|IN-2901-V;n:type:ShaderForge.SFN_Lerp,id:6647,x:33965,y:32503,varname:node_6647,prsc:2|A-6665-RGB,B-3698-OUT,T-387-OUT;n:type:ShaderForge.SFN_Vector1,id:3698,x:33659,y:32576,varname:node_3698,prsc:2,v1:1;n:type:ShaderForge.SFN_Lerp,id:9680,x:31529,y:32362,varname:node_9680,prsc:2|A-9196-OUT,B-4534-OUT,T-362-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:8991,x:33356,y:36343,ptovrint:False,ptlb:Mask,ptin:_Mask,varname:_Mask,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:9031,x:32508,y:34257,varname:_node_9031,prsc:2,ntxv:0,isnm:False|UVIN-5179-OUT,TEX-3637-TEX;n:type:ShaderForge.SFN_Tex2d,id:4311,x:32512,y:34561,varname:_node_4311,prsc:2,ntxv:0,isnm:False|UVIN-8061-OUT,TEX-3637-TEX;n:type:ShaderForge.SFN_Tex2d,id:9847,x:33954,y:35077,varname:_node_9847,prsc:2,ntxv:0,isnm:False|UVIN-3306-OUT,TEX-3637-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:3637,x:31915,y:34887,ptovrint:False,ptlb:Mask Repeat,ptin:_MaskRepeat,varname:_MaskRepeat,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1469,x:34232,y:35185,varname:node_1469,prsc:2|A-9847-R,B-7439-OUT;n:type:ShaderForge.SFN_Lerp,id:1414,x:35421,y:35017,varname:node_1414,prsc:2|A-5550-OUT,B-3702-OUT,T-3863-OUT;n:type:ShaderForge.SFN_Vector3,id:3702,x:35087,y:34931,varname:node_3702,prsc:2,v1:0.5058824,v2:0.509804,v3:1;n:type:ShaderForge.SFN_Tex2d,id:4640,x:32045,y:32295,ptovrint:False,ptlb:Window Dif,ptin:_WindowDif,varname:_WindowDif,prsc:2,glob:False,taghide:True,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-9680-OUT;n:type:ShaderForge.SFN_Lerp,id:2500,x:32634,y:32399,varname:node_2500,prsc:2|A-7736-RGB,B-4640-RGB,T-4640-A;n:type:ShaderForge.SFN_Tex2dAsset,id:684,x:32041,y:33363,ptovrint:False,ptlb:Edge Dif,ptin:_EdgeDif,varname:_EdgeDif,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:5150,x:32511,y:33488,varname:_node_5150,prsc:2,ntxv:0,isnm:False|UVIN-5179-OUT,TEX-684-TEX;n:type:ShaderForge.SFN_Tex2d,id:2118,x:32511,y:33308,varname:_node_2118,prsc:2,ntxv:0,isnm:False|UVIN-8061-OUT,TEX-684-TEX;n:type:ShaderForge.SFN_Lerp,id:4111,x:32853,y:33364,varname:node_4111,prsc:2|A-2118-RGB,B-5150-RGB,T-9031-B;n:type:ShaderForge.SFN_Lerp,id:5127,x:33526,y:33002,varname:node_5127,prsc:2|A-2500-OUT,B-4111-OUT,T-3937-OUT;n:type:ShaderForge.SFN_Tex2d,id:5075,x:34123,y:36015,ptovrint:False,ptlb:Roof Dif,ptin:_RoofDif,varname:_RoofDif,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-3306-OUT;n:type:ShaderForge.SFN_Tex2d,id:3821,x:34123,y:36249,ptovrint:False,ptlb:Ground Dif,ptin:_GroundDif,varname:_GroundDif,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-7507-OUT;n:type:ShaderForge.SFN_Lerp,id:5728,x:34665,y:35563,varname:node_5728,prsc:2|A-5127-OUT,B-5075-RGB,T-1469-OUT;n:type:ShaderForge.SFN_Lerp,id:3195,x:35135,y:35983,varname:node_3195,prsc:2|A-3821-RGB,B-5728-OUT,T-2761-OUT;n:type:ShaderForge.SFN_Lerp,id:511,x:35709,y:35522,varname:node_511,prsc:2|A-3195-OUT,B-6980-OUT,T-3863-OUT;n:type:ShaderForge.SFN_Vector1,id:6980,x:35467,y:35366,varname:node_6980,prsc:2,v1:1;n:type:ShaderForge.SFN_Slider,id:2988,x:35767,y:35908,ptovrint:False,ptlb:Diffuse,ptin:_Diffuse,varname:_Diffuse,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Lerp,id:9517,x:36211,y:35458,varname:node_9517,prsc:2|A-7965-OUT,B-511-OUT,T-2988-OUT;n:type:ShaderForge.SFN_Vector1,id:7965,x:35917,y:35379,varname:node_7965,prsc:2,v1:1;n:type:ShaderForge.SFN_Divide,id:9822,x:29044,y:33732,varname:node_9822,prsc:2|A-2057-X,B-8054-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8054,x:29044,y:33628,ptovrint:False,ptlb:UV Divide Factor,ptin:_UVDivideFactor,varname:node_8054,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:4;n:type:ShaderForge.SFN_Divide,id:7104,x:29046,y:34090,varname:node_7104,prsc:2|A-2057-Z,B-8054-OUT;n:type:ShaderForge.SFN_Divide,id:3465,x:29044,y:33918,varname:node_3465,prsc:2|A-2057-Y,B-8054-OUT;proporder:7736-5964-2988-6665-684-6766-4640-4512-3821-3543-5075-4399-358-1813-8991-3637-8054;pass:END;sub:END;*/

Shader "Mantle/BasicBuildings" {
    Properties {
        [HideInInspector]_SurfaceDif ("Surface Dif", 2D) = "white" {}
        [HideInInspector]_SurfaceNRM ("Surface NRM", 2D) = "bump" {}
        _Diffuse ("Diffuse", Range(0, 1)) = 0
        _Color ("Color", Color) = (1,0,0,1)
        _EdgeDif ("Edge Dif", 2D) = "white" {}
        _EdgeNRM ("Edge NRM", 2D) = "bump" {}
        [HideInInspector]_WindowDif ("Window Dif", 2D) = "white" {}
        [HideInInspector]_WindowNRM ("Window NRM", 2D) = "bump" {}
        _GroundDif ("Ground Dif", 2D) = "white" {}
        _GroundNRM ("Ground NRM", 2D) = "bump" {}
        _RoofDif ("Roof Dif", 2D) = "white" {}
        _RoofNRM ("Roof NRM", 2D) = "bump" {}
        _Metallic ("Metallic", Range(0, 1)) = 0
        _Gloss ("Gloss", Range(0, 1)) = 0.8
        _Mask ("Mask", 2D) = "black" {}
        _MaskRepeat ("Mask Repeat", 2D) = "white" {}
        _UVDivideFactor ("UV Divide Factor", Float ) = 4
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
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma exclude_renderers metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _Color;
            uniform sampler2D _SurfaceDif; uniform float4 _SurfaceDif_ST;
            uniform sampler2D _SurfaceNRM; uniform float4 _SurfaceNRM_ST;
            uniform float _Metallic;
            uniform float _Gloss;
            uniform sampler2D _EdgeNRM; uniform float4 _EdgeNRM_ST;
            uniform sampler2D _WindowNRM; uniform float4 _WindowNRM_ST;
            uniform sampler2D _GroundNRM; uniform float4 _GroundNRM_ST;
            uniform sampler2D _RoofNRM; uniform float4 _RoofNRM_ST;
            uniform sampler2D _Mask; uniform float4 _Mask_ST;
            uniform sampler2D _MaskRepeat; uniform float4 _MaskRepeat_ST;
            uniform sampler2D _WindowDif; uniform float4 _WindowDif_ST;
            uniform sampler2D _EdgeDif; uniform float4 _EdgeDif_ST;
            uniform sampler2D _RoofDif; uniform float4 _RoofDif_ST;
            uniform sampler2D _GroundDif; uniform float4 _GroundDif_ST;
            uniform float _Diffuse;
            uniform float _UVDivideFactor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD10;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                #ifdef LIGHTMAP_ON
                    o.ambientOrLightmapUV.xy = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
                    o.ambientOrLightmapUV.zw = 0;
                #elif UNITY_SHOULD_SAMPLE_SH
                #endif
                #ifdef DYNAMICLIGHTMAP_ON
                    o.ambientOrLightmapUV.zw = v.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
                #endif
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                float3 recipObjScale = float3( length(unity_WorldToObject[0].xyz), length(unity_WorldToObject[1].xyz), length(unity_WorldToObject[2].xyz) );
                float3 objScale = 1.0/recipObjScale;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float3 recipObjScale = float3( length(unity_WorldToObject[0].xyz), length(unity_WorldToObject[1].xyz), length(unity_WorldToObject[2].xyz) );
                float3 objScale = 1.0/recipObjScale;
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float node_9822 = (objScale.r/_UVDivideFactor);
                float node_541 = i.uv0.r; // UV Space U
                float node_7104 = (objScale.b/_UVDivideFactor);
                float3 node_6545 = normalize(mul( unity_WorldToObject, float4(i.normalDir,0) ).xyz.rgb);
                float node_362 = abs(dot(float3(1,0,0),node_6545));
                float node_5239 = lerp((node_9822*node_541),(node_7104*node_541),node_362);
                float node_1132 = i.uv0.g; // UV Space V
                float node_3465 = (objScale.g/_UVDivideFactor);
                float node_3142 = node_3465; // Object Y
                float2 node_7507 = float2(node_5239,(node_1132*node_3142));
                float3 _GroundNRM_var = UnpackNormal(tex2D(_GroundNRM,TRANSFORM_TEX(node_7507, _GroundNRM)));
                float node_4960 = i.uv0.r; // UV Space U
                float node_4600 = node_9822; // Object X
                float node_5137 = i.uv0.g; // UV Space V
                float node_8111 = node_3465; // Object Y
                float node_5879 = node_7104; // Object Z
                float2 node_9680 = lerp(float2((node_4960*node_4600),(node_5137*node_8111)),float2((node_4960*node_5879),(node_5137*node_8111)),node_362);
                float3 _SurfaceNRM_var = UnpackNormal(tex2D(_SurfaceNRM,TRANSFORM_TEX(node_9680, _SurfaceNRM)));
                float3 _WindowNRM_var = UnpackNormal(tex2D(_WindowNRM,TRANSFORM_TEX(node_9680, _WindowNRM)));
                float4 _WindowDif_var = tex2D(_WindowDif,TRANSFORM_TEX(node_9680, _WindowDif));
                float node_2031 = i.uv0.r; // UV Space U
                float node_6321 = node_9822; // Object X
                float node_2854 = ((1.0 - node_2031)*node_6321);
                float node_3016 = (i.uv0.g*node_3465); // World Y
                float node_4941 = node_7104; // Object Z
                float node_8287 = ((1.0 - node_2031)*node_4941);
                float node_2062 = node_362;
                float2 node_8061 = lerp(float2(node_2854,node_3016),float2(node_8287,node_3016),node_2062);
                float3 _node_453 = UnpackNormal(tex2D(_EdgeNRM,TRANSFORM_TEX(node_8061, _EdgeNRM)));
                float node_6558 = (node_2031*node_6321);
                float node_9431 = (node_2031*node_4941);
                float2 node_5179 = lerp(float2(node_6558,node_3016),float2(node_9431,node_3016),node_2062);
                float3 _EdgeNormalmap = UnpackNormal(tex2D(_EdgeNRM,TRANSFORM_TEX(node_5179, _EdgeNRM)));
                float4 _node_9031 = tex2D(_MaskRepeat,TRANSFORM_TEX(node_5179, _MaskRepeat));
                float4 _node_4311 = tex2D(_MaskRepeat,TRANSFORM_TEX(node_8061, _MaskRepeat));
                float node_3937 = lerp((step(node_6558,_node_9031.b)+step(node_2854,_node_4311.b)),(step(node_9431,_node_9031.b)+step(node_8287,_node_4311.b)),node_362);
                float node_2519 = (1.0 - ((1.0 - node_1132)*node_3142));
                float2 node_3306 = float2(node_5239,node_2519);
                float3 _RoofNRM_var = UnpackNormal(tex2D(_RoofNRM,TRANSFORM_TEX(node_3306, _RoofNRM)));
                float4 _node_9847 = tex2D(_MaskRepeat,TRANSFORM_TEX(node_3306, _MaskRepeat));
                float node_1469 = (_node_9847.r*step(0.01,node_2519));
                float4 _TopBotMask = tex2D(_Mask,TRANSFORM_TEX(node_7507, _Mask));
                float node_2761 = saturate(_TopBotMask.g);
                float node_3863 = abs(dot(node_6545,float3(0,1,0)));
                float3 normalLocal = lerp(lerp(_GroundNRM_var.rgb,lerp(lerp(lerp(_SurfaceNRM_var.rgb,_WindowNRM_var.rgb,_WindowDif_var.a),lerp(_node_453.rgb,_EdgeNormalmap.rgb,_node_9031.b),node_3937),_RoofNRM_var.rgb,node_1469),node_2761),float3(0.5058824,0.509804,1),node_3863);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = _Gloss;
                float specPow = exp2( gloss * 10.0+1.0);
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                #if defined(LIGHTMAP_ON) || defined(DYNAMICLIGHTMAP_ON)
                    d.ambient = 0;
                    d.lightmapUV = i.ambientOrLightmapUV;
                #else
                    d.ambient = i.ambientOrLightmapUV;
                #endif
                d.boxMax[0] = unity_SpecCube0_BoxMax;
                d.boxMin[0] = unity_SpecCube0_BoxMin;
                d.probePosition[0] = unity_SpecCube0_ProbePosition;
                d.probeHDR[0] = unity_SpecCube0_HDR;
                d.boxMax[1] = unity_SpecCube1_BoxMax;
                d.boxMin[1] = unity_SpecCube1_BoxMin;
                d.probePosition[1] = unity_SpecCube1_ProbePosition;
                d.probeHDR[1] = unity_SpecCube1_HDR;
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float LdotH = max(0.0,dot(lightDirection, halfDirection));
                float node_7965 = 1.0;
                float4 _GroundDif_var = tex2D(_GroundDif,TRANSFORM_TEX(node_7507, _GroundDif));
                float4 _SurfaceDif_var = tex2D(_SurfaceDif,TRANSFORM_TEX(node_9680, _SurfaceDif));
                float4 _node_2118 = tex2D(_EdgeDif,TRANSFORM_TEX(node_8061, _EdgeDif));
                float4 _node_5150 = tex2D(_EdgeDif,TRANSFORM_TEX(node_5179, _EdgeDif));
                float4 _RoofDif_var = tex2D(_RoofDif,TRANSFORM_TEX(node_3306, _RoofDif));
                float node_6980 = 1.0;
                float node_3698 = 1.0;
                float3 diffuseColor = (lerp(float3(node_7965,node_7965,node_7965),lerp(lerp(_GroundDif_var.rgb,lerp(lerp(lerp(_SurfaceDif_var.rgb,_WindowDif_var.rgb,_WindowDif_var.a),lerp(_node_2118.rgb,_node_5150.rgb,_node_9031.b),node_3937),_RoofDif_var.rgb,node_1469),node_2761),float3(node_6980,node_6980,node_6980),node_3863),_Diffuse)*lerp(_Color.rgb,float3(node_3698,node_3698,node_3698),i.uv0.g)); // Need this for specular when using metallic
                float specularMonochrome;
                float3 specularColor;
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, _Metallic, specularColor, specularMonochrome );
                specularMonochrome = 1-specularMonochrome;
                float NdotV = max(0.0,dot( normalDirection, viewDirection ));
                float NdotH = max(0.0,dot( normalDirection, halfDirection ));
                float VdotH = max(0.0,dot( viewDirection, halfDirection ));
                float visTerm = SmithBeckmannVisibilityTerm( NdotL, NdotV, 1.0-gloss );
                float normTerm = max(0.0, NDFBlinnPhongNormalizedTerm(NdotH, RoughnessToSpecPower(1.0-gloss)));
                float specularPBL = max(0, (NdotL*visTerm*normTerm) * (UNITY_PI / 4) );
                float3 directSpecular = 1 * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularPBL*lightColor*FresnelTerm(specularColor, LdotH);
                half grazingTerm = saturate( gloss + specularMonochrome );
                float3 indirectSpecular = (gi.indirect.specular);
                indirectSpecular *= FresnelLerp (specularColor, grazingTerm, NdotV);
                float3 specular = (directSpecular + indirectSpecular);
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float3 directDiffuse = ((1 +(fd90 - 1)*pow((1.00001-NdotL), 5)) * (1 + (fd90 - 1)*pow((1.00001-NdotV), 5)) * NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += gi.indirect.diffuse;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
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
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma exclude_renderers metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _Color;
            uniform sampler2D _SurfaceDif; uniform float4 _SurfaceDif_ST;
            uniform sampler2D _SurfaceNRM; uniform float4 _SurfaceNRM_ST;
            uniform float _Metallic;
            uniform float _Gloss;
            uniform sampler2D _EdgeNRM; uniform float4 _EdgeNRM_ST;
            uniform sampler2D _WindowNRM; uniform float4 _WindowNRM_ST;
            uniform sampler2D _GroundNRM; uniform float4 _GroundNRM_ST;
            uniform sampler2D _RoofNRM; uniform float4 _RoofNRM_ST;
            uniform sampler2D _Mask; uniform float4 _Mask_ST;
            uniform sampler2D _MaskRepeat; uniform float4 _MaskRepeat_ST;
            uniform sampler2D _WindowDif; uniform float4 _WindowDif_ST;
            uniform sampler2D _EdgeDif; uniform float4 _EdgeDif_ST;
            uniform sampler2D _RoofDif; uniform float4 _RoofDif_ST;
            uniform sampler2D _GroundDif; uniform float4 _GroundDif_ST;
            uniform float _Diffuse;
            uniform float _UVDivideFactor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                float3 recipObjScale = float3( length(unity_WorldToObject[0].xyz), length(unity_WorldToObject[1].xyz), length(unity_WorldToObject[2].xyz) );
                float3 objScale = 1.0/recipObjScale;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float3 recipObjScale = float3( length(unity_WorldToObject[0].xyz), length(unity_WorldToObject[1].xyz), length(unity_WorldToObject[2].xyz) );
                float3 objScale = 1.0/recipObjScale;
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float node_9822 = (objScale.r/_UVDivideFactor);
                float node_541 = i.uv0.r; // UV Space U
                float node_7104 = (objScale.b/_UVDivideFactor);
                float3 node_6545 = normalize(mul( unity_WorldToObject, float4(i.normalDir,0) ).xyz.rgb);
                float node_362 = abs(dot(float3(1,0,0),node_6545));
                float node_5239 = lerp((node_9822*node_541),(node_7104*node_541),node_362);
                float node_1132 = i.uv0.g; // UV Space V
                float node_3465 = (objScale.g/_UVDivideFactor);
                float node_3142 = node_3465; // Object Y
                float2 node_7507 = float2(node_5239,(node_1132*node_3142));
                float3 _GroundNRM_var = UnpackNormal(tex2D(_GroundNRM,TRANSFORM_TEX(node_7507, _GroundNRM)));
                float node_4960 = i.uv0.r; // UV Space U
                float node_4600 = node_9822; // Object X
                float node_5137 = i.uv0.g; // UV Space V
                float node_8111 = node_3465; // Object Y
                float node_5879 = node_7104; // Object Z
                float2 node_9680 = lerp(float2((node_4960*node_4600),(node_5137*node_8111)),float2((node_4960*node_5879),(node_5137*node_8111)),node_362);
                float3 _SurfaceNRM_var = UnpackNormal(tex2D(_SurfaceNRM,TRANSFORM_TEX(node_9680, _SurfaceNRM)));
                float3 _WindowNRM_var = UnpackNormal(tex2D(_WindowNRM,TRANSFORM_TEX(node_9680, _WindowNRM)));
                float4 _WindowDif_var = tex2D(_WindowDif,TRANSFORM_TEX(node_9680, _WindowDif));
                float node_2031 = i.uv0.r; // UV Space U
                float node_6321 = node_9822; // Object X
                float node_2854 = ((1.0 - node_2031)*node_6321);
                float node_3016 = (i.uv0.g*node_3465); // World Y
                float node_4941 = node_7104; // Object Z
                float node_8287 = ((1.0 - node_2031)*node_4941);
                float node_2062 = node_362;
                float2 node_8061 = lerp(float2(node_2854,node_3016),float2(node_8287,node_3016),node_2062);
                float3 _node_453 = UnpackNormal(tex2D(_EdgeNRM,TRANSFORM_TEX(node_8061, _EdgeNRM)));
                float node_6558 = (node_2031*node_6321);
                float node_9431 = (node_2031*node_4941);
                float2 node_5179 = lerp(float2(node_6558,node_3016),float2(node_9431,node_3016),node_2062);
                float3 _EdgeNormalmap = UnpackNormal(tex2D(_EdgeNRM,TRANSFORM_TEX(node_5179, _EdgeNRM)));
                float4 _node_9031 = tex2D(_MaskRepeat,TRANSFORM_TEX(node_5179, _MaskRepeat));
                float4 _node_4311 = tex2D(_MaskRepeat,TRANSFORM_TEX(node_8061, _MaskRepeat));
                float node_3937 = lerp((step(node_6558,_node_9031.b)+step(node_2854,_node_4311.b)),(step(node_9431,_node_9031.b)+step(node_8287,_node_4311.b)),node_362);
                float node_2519 = (1.0 - ((1.0 - node_1132)*node_3142));
                float2 node_3306 = float2(node_5239,node_2519);
                float3 _RoofNRM_var = UnpackNormal(tex2D(_RoofNRM,TRANSFORM_TEX(node_3306, _RoofNRM)));
                float4 _node_9847 = tex2D(_MaskRepeat,TRANSFORM_TEX(node_3306, _MaskRepeat));
                float node_1469 = (_node_9847.r*step(0.01,node_2519));
                float4 _TopBotMask = tex2D(_Mask,TRANSFORM_TEX(node_7507, _Mask));
                float node_2761 = saturate(_TopBotMask.g);
                float node_3863 = abs(dot(node_6545,float3(0,1,0)));
                float3 normalLocal = lerp(lerp(_GroundNRM_var.rgb,lerp(lerp(lerp(_SurfaceNRM_var.rgb,_WindowNRM_var.rgb,_WindowDif_var.a),lerp(_node_453.rgb,_EdgeNormalmap.rgb,_node_9031.b),node_3937),_RoofNRM_var.rgb,node_1469),node_2761),float3(0.5058824,0.509804,1),node_3863);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = _Gloss;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float LdotH = max(0.0,dot(lightDirection, halfDirection));
                float node_7965 = 1.0;
                float4 _GroundDif_var = tex2D(_GroundDif,TRANSFORM_TEX(node_7507, _GroundDif));
                float4 _SurfaceDif_var = tex2D(_SurfaceDif,TRANSFORM_TEX(node_9680, _SurfaceDif));
                float4 _node_2118 = tex2D(_EdgeDif,TRANSFORM_TEX(node_8061, _EdgeDif));
                float4 _node_5150 = tex2D(_EdgeDif,TRANSFORM_TEX(node_5179, _EdgeDif));
                float4 _RoofDif_var = tex2D(_RoofDif,TRANSFORM_TEX(node_3306, _RoofDif));
                float node_6980 = 1.0;
                float node_3698 = 1.0;
                float3 diffuseColor = (lerp(float3(node_7965,node_7965,node_7965),lerp(lerp(_GroundDif_var.rgb,lerp(lerp(lerp(_SurfaceDif_var.rgb,_WindowDif_var.rgb,_WindowDif_var.a),lerp(_node_2118.rgb,_node_5150.rgb,_node_9031.b),node_3937),_RoofDif_var.rgb,node_1469),node_2761),float3(node_6980,node_6980,node_6980),node_3863),_Diffuse)*lerp(_Color.rgb,float3(node_3698,node_3698,node_3698),i.uv0.g)); // Need this for specular when using metallic
                float specularMonochrome;
                float3 specularColor;
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, _Metallic, specularColor, specularMonochrome );
                specularMonochrome = 1-specularMonochrome;
                float NdotV = max(0.0,dot( normalDirection, viewDirection ));
                float NdotH = max(0.0,dot( normalDirection, halfDirection ));
                float VdotH = max(0.0,dot( viewDirection, halfDirection ));
                float visTerm = SmithBeckmannVisibilityTerm( NdotL, NdotV, 1.0-gloss );
                float normTerm = max(0.0, NDFBlinnPhongNormalizedTerm(NdotH, RoughnessToSpecPower(1.0-gloss)));
                float specularPBL = max(0, (NdotL*visTerm*normTerm) * (UNITY_PI / 4) );
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularPBL*lightColor*FresnelTerm(specularColor, LdotH);
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float3 directDiffuse = ((1 +(fd90 - 1)*pow((1.00001-NdotL), 5)) * (1 + (fd90 - 1)*pow((1.00001-NdotV), 5)) * NdotL) * attenColor;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "Meta"
            Tags {
                "LightMode"="Meta"
            }
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_META 1
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma exclude_renderers metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _Color;
            uniform sampler2D _SurfaceDif; uniform float4 _SurfaceDif_ST;
            uniform float _Metallic;
            uniform float _Gloss;
            uniform sampler2D _Mask; uniform float4 _Mask_ST;
            uniform sampler2D _MaskRepeat; uniform float4 _MaskRepeat_ST;
            uniform sampler2D _WindowDif; uniform float4 _WindowDif_ST;
            uniform sampler2D _EdgeDif; uniform float4 _EdgeDif_ST;
            uniform sampler2D _RoofDif; uniform float4 _RoofDif_ST;
            uniform sampler2D _GroundDif; uniform float4 _GroundDif_ST;
            uniform float _Diffuse;
            uniform float _UVDivideFactor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float3 recipObjScale = float3( length(unity_WorldToObject[0].xyz), length(unity_WorldToObject[1].xyz), length(unity_WorldToObject[2].xyz) );
                float3 objScale = 1.0/recipObjScale;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
                float3 recipObjScale = float3( length(unity_WorldToObject[0].xyz), length(unity_WorldToObject[1].xyz), length(unity_WorldToObject[2].xyz) );
                float3 objScale = 1.0/recipObjScale;
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                o.Emission = 0;
                
                float node_7965 = 1.0;
                float node_9822 = (objScale.r/_UVDivideFactor);
                float node_541 = i.uv0.r; // UV Space U
                float node_7104 = (objScale.b/_UVDivideFactor);
                float3 node_6545 = normalize(mul( unity_WorldToObject, float4(i.normalDir,0) ).xyz.rgb);
                float node_362 = abs(dot(float3(1,0,0),node_6545));
                float node_5239 = lerp((node_9822*node_541),(node_7104*node_541),node_362);
                float node_1132 = i.uv0.g; // UV Space V
                float node_3465 = (objScale.g/_UVDivideFactor);
                float node_3142 = node_3465; // Object Y
                float2 node_7507 = float2(node_5239,(node_1132*node_3142));
                float4 _GroundDif_var = tex2D(_GroundDif,TRANSFORM_TEX(node_7507, _GroundDif));
                float node_4960 = i.uv0.r; // UV Space U
                float node_4600 = node_9822; // Object X
                float node_5137 = i.uv0.g; // UV Space V
                float node_8111 = node_3465; // Object Y
                float node_5879 = node_7104; // Object Z
                float2 node_9680 = lerp(float2((node_4960*node_4600),(node_5137*node_8111)),float2((node_4960*node_5879),(node_5137*node_8111)),node_362);
                float4 _SurfaceDif_var = tex2D(_SurfaceDif,TRANSFORM_TEX(node_9680, _SurfaceDif));
                float4 _WindowDif_var = tex2D(_WindowDif,TRANSFORM_TEX(node_9680, _WindowDif));
                float node_2031 = i.uv0.r; // UV Space U
                float node_6321 = node_9822; // Object X
                float node_2854 = ((1.0 - node_2031)*node_6321);
                float node_3016 = (i.uv0.g*node_3465); // World Y
                float node_4941 = node_7104; // Object Z
                float node_8287 = ((1.0 - node_2031)*node_4941);
                float node_2062 = node_362;
                float2 node_8061 = lerp(float2(node_2854,node_3016),float2(node_8287,node_3016),node_2062);
                float4 _node_2118 = tex2D(_EdgeDif,TRANSFORM_TEX(node_8061, _EdgeDif));
                float node_6558 = (node_2031*node_6321);
                float node_9431 = (node_2031*node_4941);
                float2 node_5179 = lerp(float2(node_6558,node_3016),float2(node_9431,node_3016),node_2062);
                float4 _node_5150 = tex2D(_EdgeDif,TRANSFORM_TEX(node_5179, _EdgeDif));
                float4 _node_9031 = tex2D(_MaskRepeat,TRANSFORM_TEX(node_5179, _MaskRepeat));
                float4 _node_4311 = tex2D(_MaskRepeat,TRANSFORM_TEX(node_8061, _MaskRepeat));
                float node_3937 = lerp((step(node_6558,_node_9031.b)+step(node_2854,_node_4311.b)),(step(node_9431,_node_9031.b)+step(node_8287,_node_4311.b)),node_362);
                float node_2519 = (1.0 - ((1.0 - node_1132)*node_3142));
                float2 node_3306 = float2(node_5239,node_2519);
                float4 _RoofDif_var = tex2D(_RoofDif,TRANSFORM_TEX(node_3306, _RoofDif));
                float4 _node_9847 = tex2D(_MaskRepeat,TRANSFORM_TEX(node_3306, _MaskRepeat));
                float node_1469 = (_node_9847.r*step(0.01,node_2519));
                float4 _TopBotMask = tex2D(_Mask,TRANSFORM_TEX(node_7507, _Mask));
                float node_2761 = saturate(_TopBotMask.g);
                float node_6980 = 1.0;
                float node_3863 = abs(dot(node_6545,float3(0,1,0)));
                float node_3698 = 1.0;
                float3 diffColor = (lerp(float3(node_7965,node_7965,node_7965),lerp(lerp(_GroundDif_var.rgb,lerp(lerp(lerp(_SurfaceDif_var.rgb,_WindowDif_var.rgb,_WindowDif_var.a),lerp(_node_2118.rgb,_node_5150.rgb,_node_9031.b),node_3937),_RoofDif_var.rgb,node_1469),node_2761),float3(node_6980,node_6980,node_6980),node_3863),_Diffuse)*lerp(_Color.rgb,float3(node_3698,node_3698,node_3698),i.uv0.g));
                float specularMonochrome;
                float3 specColor;
                diffColor = DiffuseAndSpecularFromMetallic( diffColor, _Metallic, specColor, specularMonochrome );
                float roughness = 1.0 - _Gloss;
                o.Albedo = diffColor + specColor * roughness * roughness * 0.5;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
