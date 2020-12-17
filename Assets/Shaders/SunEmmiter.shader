// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:7880,x:32988,y:32736,varname:node_7880,prsc:2|diff-2792-RGB,emission-6565-OUT,voffset-7924-OUT;n:type:ShaderForge.SFN_Tex2d,id:2792,x:32487,y:32551,ptovrint:False,ptlb:baseColor,ptin:_baseColor,varname:node_2792,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:8a90b4a07a863d34294ffa8381ac4923,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:6789,x:32417,y:32996,ptovrint:False,ptlb:additive,ptin:_additive,varname:node_6789,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:eff4b36d32718ad468a3585822837c81,ntxv:0,isnm:False|UVIN-1552-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:8251,x:31913,y:32928,varname:node_8251,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Time,id:3349,x:31839,y:33115,varname:node_3349,prsc:2;n:type:ShaderForge.SFN_Multiply,id:3564,x:32074,y:33150,varname:node_3564,prsc:2|A-3349-T,B-4327-OUT;n:type:ShaderForge.SFN_Slider,id:4327,x:31761,y:33281,ptovrint:False,ptlb:Velocity,ptin:_Velocity,varname:node_4327,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-4,cur:-0.07430234,max:4;n:type:ShaderForge.SFN_Panner,id:1552,x:32221,y:33022,varname:node_1552,prsc:2,spu:1,spv:1|UVIN-8251-UVOUT,DIST-3564-OUT;n:type:ShaderForge.SFN_Color,id:2116,x:32370,y:32735,ptovrint:False,ptlb:node_2116,ptin:_node_2116,varname:node_2116,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.9947585,c3:0.5424528,c4:1;n:type:ShaderForge.SFN_Multiply,id:6565,x:32586,y:32903,varname:node_6565,prsc:2|A-2116-RGB,B-6789-R;n:type:ShaderForge.SFN_Multiply,id:5039,x:32548,y:33308,varname:node_5039,prsc:2|A-4021-OUT,B-1186-OUT;n:type:ShaderForge.SFN_Slider,id:1186,x:32213,y:33411,ptovrint:False,ptlb:normal,ptin:_normal,varname:node_1186,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0.1025641,max:1;n:type:ShaderForge.SFN_NormalVector,id:4021,x:32355,y:33239,prsc:2,pt:False;n:type:ShaderForge.SFN_Multiply,id:7924,x:32709,y:33209,varname:node_7924,prsc:2|A-6789-R,B-5039-OUT;proporder:2792-6789-4327-2116-1186;pass:END;sub:END;*/

Shader "Unlit/SunEmiter" {
    Properties {
        _baseColor ("baseColor", 2D) = "white" {}
        _additive ("additive", 2D) = "white" {}
        _Velocity ("Velocity", Range(-4, 4)) = -0.07430234
        _node_2116 ("node_2116", Color) = (1,0.9947585,0.5424528,1)
        _normal ("normal", Range(-1, 1)) = 0.1025641
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        LOD 100
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
         
            uniform float4 _LightColor0;
            uniform sampler2D _baseColor; uniform float4 _baseColor_ST;
            uniform sampler2D _additive; uniform float4 _additive_ST;
            uniform float _Velocity;
            uniform float4 _node_2116;
            uniform float _normal;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_3349 = _Time;
                float2 node_1552 = (o.uv0+(node_3349.g*_Velocity)*float2(1,1));
                float4 _additive_var = tex2Dlod(_additive,float4(TRANSFORM_TEX(node_1552, _additive),0.0,0));
                v.vertex.xyz += (_additive_var.r*(v.normal*_normal));
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 _baseColor_var = tex2D(_baseColor,TRANSFORM_TEX(i.uv0, _baseColor));
                float3 diffuseColor = _baseColor_var.rgb;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float4 node_3349 = _Time;
                float2 node_1552 = (i.uv0+(node_3349.g*_Velocity)*float2(1,1));
                float4 _additive_var = tex2D(_additive,TRANSFORM_TEX(node_1552, _additive));
                float3 emissive = (_node_2116.rgb*_additive_var.r);
/// Final Color:
                float3 finalColor = diffuse + emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        
    }
    FallBack "Diffuse"
    
}
