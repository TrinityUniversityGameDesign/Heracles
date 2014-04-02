Shader "Custom/Cylindrical" {
	Properties {
		_MainTex ("Sprite Texture",2D) = "white" {}
	}
	SubShader { Pass {
		GLSLPROGRAM
	 
		uniform mat4 _Object2World; 
        uniform vec4 _Time;
        uniform sampler2D _MainTex;
        
        varying vec4 col;
        varying vec4 texVert;
 
 		float map(float val, float inlo, float inhi, float outlo, float outhi) {
 			float fract = (val - inlo) / (inhi - inlo);
 			return outlo + fract * (outhi - outlo);
 		}
 		float pi = 3.14159;
 		float angoff = pi/12.0;
 		float n = -tan(pi+angoff);
 
        #ifdef VERTEX
        void main() {
            vec4 pos = gl_ModelViewProjectionMatrix * gl_Vertex;
            float phi = map(pos.x, -1.0,1.0, pi/2.0+angoff,3.0/2.0*pi-angoff);
            pos.x = tan(phi);//n * tan(phi);
            gl_Position = pos;
            col = gl_Color;
            texVert = gl_MultiTexCoord0;
		}
		#endif
		
		#ifdef FRAGMENT
		void main() {
			gl_FragColor = col;//texture2D(_MainTex, texVert.xy) * col;
		}
		#endif
		
		ENDGLSL
	}}
	//FallBack "Diffuse"
}
