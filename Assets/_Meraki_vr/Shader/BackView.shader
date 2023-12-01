Shader "Custom/BackView"
{
    Properties{
        _MainTex("Texture", 2D) = "white" {}
        _RotationSpeed("Rotation Speed", Range(0, 10)) = 1
    }
        SubShader{
            Tags {"Queue" = "Transparent" "RenderType" = "Transparent"}
            LOD 100

            Pass {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "UnityCG.cginc"

                struct appdata {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                };

                struct v2f {
                    float2 uv : TEXCOORD0;
                    float4 vertex : SV_POSITION;
                };

                sampler2D _MainTex;
                float _RotationSpeed;

                v2f vert(appdata v) {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = v.uv;
                    return o;
                }

                fixed4 frag(v2f i) : SV_Target {
                    float4 col = tex2D(_MainTex, i.uv);
                    float angle = _Time.y * _RotationSpeed;
                    float s = sin(angle);
                    float c = cos(angle);
                    float2x2 rotationMatrix = float2x2(c, s, -s, c);
                    float2 rotatedUV = mul(rotationMatrix, i.uv - 0.5) + 0.5;
                    col = tex2D(_MainTex, rotatedUV);
                    return col;
                }
                ENDCG
            }
        }
            FallBack "Diffuse"
}
