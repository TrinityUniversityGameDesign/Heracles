Shader "Custom/PositionWaveOverTime" {
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
 
        #ifdef VERTEX
        void main() {
        	vec4 pos = (gl_ModelViewProjectionMatrix * gl_Vertex);
            gl_Position = vec4(pos.x, pos.y + 1.0*sin(_Time.x*10.0 + pos.x*10.0), pos.z, 1.0);
            col = gl_Color;
            texVert = gl_MultiTexCoord0;
		}
		#endif
		
		#ifdef FRAGMENT
		void main() {
			gl_FragColor = texture2D(_MainTex, texVert.xy) * col;
		}
		#endif
		
		ENDGLSL
	}}
	//FallBack "Diffuse"
}
