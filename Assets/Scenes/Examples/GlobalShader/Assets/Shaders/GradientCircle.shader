Shader "Custom/GradientCircle" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
	}
	SubShader {
	Pass {
	         GLSLPROGRAM
	 
	         uniform mat4 _Object2World; 
	            // definition of a Unity-specific uniform variable 
	         uniform vec4 _Time;
	 
	         varying vec4 position_in_world_space;
	 
	         #ifdef VERTEX
	 
	         void main() {
	            //Used for distance calculation later in fragment shader
	            position_in_world_space = _Object2World * gl_Vertex;
	            
	            vec4 pos = gl_ModelViewProjectionMatrix * gl_Vertex;
	            //gl_Position = vec4(pos.x, pos.y + 0.05*sin(_Time.x*10.0 + pos.x*10.0), pos.z, 1.0);
	            gl_Position = pos;
	         }
	 
	         #endif

	         #ifdef FRAGMENT
	 
	         void main() {
	         	//Distance to origin in world space
	            float dist = distance(position_in_world_space, vec4(0.0, 0.0, 0.0, 1.0));
	 
	 			//First version is white close to origin, black farther away
	            if (dist < 5.0) {
	               gl_FragColor = vec4(1.0, 1.0, 1.0, 1.0); 
	            } else {
	               gl_FragColor = vec4(0.0, 0.0, 0.0, 1.0); 
	            }
	            
	            //Second version creates a gradient from black to white
	            //gl_FragColor = vec4(min(1.0, dist/5.0), min(1.0, dist/5.0), min(1.0,dist/5.0), 1.0);
	         }
	 
	         #endif
	 		
	         ENDGLSL
		}
	}
}
