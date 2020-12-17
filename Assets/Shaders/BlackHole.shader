// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.07450981,fgcg:0.06666667,fgcb:0.2352941,fgca:1,fgde:0.03,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:570,x:32824,y:32712,varname:node_570,prsc:2|emission-8681-OUT,alpha-8295-OUT;n:type:ShaderForge.SFN_Tex2d,id:4018,x:32269,y:32736,ptovrint:False,ptlb:Base,ptin:_Base,varname:node_4018,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:00231fed4a63c81429bf8770b87d7dfb,ntxv:0,isnm:False|UVIN-245-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:1340,x:31919,y:32707,varname:node_1340,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Time,id:8271,x:31890,y:33126,varname:node_8271,prsc:2;n:type:ShaderForge.SFN_Multiply,id:1371,x:32129,y:33194,varname:node_1371,prsc:2|A-8271-T,B-3867-OUT;n:type:ShaderForge.SFN_Slider,id:3867,x:31815,y:33349,ptovrint:False,ptlb:node_3867,ptin:_node_3867,varname:node_3867,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-2,cur:0.5095236,max:2;n:type:ShaderForge.SFN_Panner,id:245,x:32090,y:32883,varname:node_245,prsc:2,spu:0,spv:1|UVIN-1340-UVOUT,DIST-1371-OUT;n:type:ShaderForge.SFN_OneMinus,id:5605,x:32298,y:32948,varname:node_5605,prsc:2|IN-4018-R;n:type:ShaderForge.SFN_Multiply,id:2416,x:32511,y:33050,varname:node_2416,prsc:2|A-4018-R,B-3557-OUT;n:type:ShaderForge.SFN_Slider,id:3557,x:32164,y:33117,ptovrint:False,ptlb:cutAlpha,ptin:_cutAlpha,varname:node_3557,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:5,max:5;n:type:ShaderForge.SFN_Tex2d,id:930,x:32392,y:33257,ptovrint:False,ptlb:Mask,ptin:_Mask,varname:node_930,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:8295,x:32637,y:33199,varname:node_8295,prsc:2|A-2416-OUT,B-5660-OUT;n:type:ShaderForge.SFN_Multiply,id:5660,x:32549,y:33374,varname:node_5660,prsc:2|A-930-R,B-3557-OUT;n:type:ShaderForge.SFN_Color,id:9139,x:32335,y:32493,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_9139,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.289344,c2:0.04165182,c3:0.9811321,c4:1;n:type:ShaderForge.SFN_Multiply,id:8681,x:32505,y:32672,varname:node_8681,prsc:2|A-9139-RGB,B-4018-R;proporder:4018-3867-3557-930-9139;pass:END;sub:END;*/

Shader "Unlit/BlackHole" {
    Properties {
        _Base ("Base", 2D) = "white" {}
        _node_3867 ("node_3867", Range(-2, 2)) = 0.5095236
        _cutAlpha ("cutAlpha", Range(0, 5)) = 5
        _Mask ("Mask", 2D) = "white" {}
        _Color ("Color", Color) = (0.289344,0.04165182,0.9811321,1)
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        LOD 100
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
           
            #include "UnityCG.cginc"
        
            uniform sampler2D _Base; uniform float4 _Base_ST;
            uniform float _node_3867;
            uniform float _cutAlpha;
            uniform sampler2D _Mask; uniform float4 _Mask_ST;
            uniform float4 _Color;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
////// Lighting:
////// Emissive:
                float4 node_8271 = _Time;
                float2 node_245 = (i.uv0+(node_8271.g*_node_3867)*float2(0,1));
                float4 _Base_var = tex2D(_Base,TRANSFORM_TEX(node_245, _Base));
                float3 emissive = (_Color.rgb*_Base_var.r);
                float3 finalColor = emissive;
                float4 _Mask_var = tex2D(_Mask,TRANSFORM_TEX(i.uv0, _Mask));
                fixed4 finalRGBA = fixed4(finalColor,((_Base_var.r*_cutAlpha)*(_Mask_var.r*_cutAlpha)));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
       
    }
    FallBack "Diffuse"
    
}
