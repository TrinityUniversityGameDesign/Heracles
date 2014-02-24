using UnityEngine;
using System.Collections;

public class CameraShaderScript : MonoBehaviour {

	public Shader shader;

	// Use this for initialization
	void Awake() {
		if (shader) 
			transform.camera.SetReplacementShader (shader, null);
	}
	
}
