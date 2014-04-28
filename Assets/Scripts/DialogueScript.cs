using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class DialogueScript : MonoBehaviour {

	public Font fontRes;
	public int fontSize = 32;
	public int messageWidth = 20;
	public int numberOfLines = 2;
	public float localx = 0;
	public float localy = 2;
	public string message;
	public bool oneUse = false;
	//public Color c;

	private GameObject objText;
	private TextMesh textMesh;
	private float delay = 0.02f;
	private string[] lines;
	private int index;
	private int lineHieght;
	private bool isDisplaying = false;
	private bool used = false;
	private bool initilized = false;
	private bool wait = false;
	private bool skip = false;
	private bool collide = false;
	private bool hasFocus = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("space") && !wait && isDisplaying) {
			textMesh.text = "";
			if (index < lines.Length)
				StartCoroutine(DispRoutine());
			else
				isDisplaying = false;
		}
		else if (Input.GetKeyDown("space") && wait) {
			skip = true;
		}
		else if (Input.GetKeyDown("space") && !isDisplaying && collide) {
			isDisplaying = true;
			DisplayMessage(message,numberOfLines);
		}
		if (!collide && initilized) {
			isDisplaying = false;
			if (textMesh.gameObject.GetComponent<MeshRenderer>().material.color.a > 0) {
				Color tempColor = textMesh.gameObject.GetComponent<MeshRenderer>().material.color;
				tempColor.a -= 0.015f;
				textMesh.gameObject.GetComponent<MeshRenderer>().material.color = tempColor;
			}
			else
				textMesh.text = "";
		}
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		collide = true;
		if (other.tag == "P1" && !isDisplaying) {
			if (oneUse && !used) {
				isDisplaying = used = true;
				DisplayMessage(message,numberOfLines);
			}
			else if (!oneUse) {
				isDisplaying = true;
				DisplayMessage(message,numberOfLines);
			}
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		collide = false;
	}

	public void DisplayMessage(string newMessage, int lineHt) {
		lineHieght = lineHt;
		StartCoroutine(NewDispRoutine(newMessage));
	}

	public IEnumerator NewDispRoutine(string newMessage) {
		wait = true;
		if (!initilized) {
			objText = new GameObject("TextObject");
			textMesh = objText.AddComponent("TextMesh") as TextMesh;
			objText.transform.parent = transform;
			textMesh.font = fontRes;
			textMesh.renderer.material = fontRes.material;
			//textMesh.renderer.material.color = c;
			textMesh.fontSize = fontSize;
			objText.transform.localScale = objText.transform.localScale/5;
			objText.transform.localPosition = new Vector3(localx,localy,0f);
			initilized = true;
		}
		else {
			Color tempColor = textMesh.gameObject.GetComponent<MeshRenderer>().material.color;
			tempColor.a = 1;
			textMesh.gameObject.GetComponent<MeshRenderer>().material.color = tempColor;
		}
		index = 0;
		textMesh.text = "";
		string pattern = ".{1,"+messageWidth+"}(\\s+|$)";
		string rep = "$&\n";
		string temp = Regex.Replace(newMessage,pattern,rep);
		lines = Regex.Split(temp,"[\n]");
		for (int i = 0; i < lineHieght; i++) {
			if (index < lines.Length)
				yield return StartCoroutine(WriteText(lines[index]));
			else
				isDisplaying = false;
			textMesh.text += "\n";
			index++;
		}
		wait = skip = false;
	}

	public IEnumerator DispRoutine() {
		wait = true;
		for (int i = 0; i < lineHieght; i++) {
			if (index < lines.Length)
				yield return StartCoroutine(WriteText(lines[index]));
			else
				isDisplaying = false;
			textMesh.text += "\n";
			index++;
		}
		wait = skip = false;
	}

	public IEnumerator WriteText(string lines) {
		for (int i = 0; i < lines.Length; i++) {
			textMesh.text += lines[i];
			if (!skip)
				yield return new WaitForSeconds(delay);
		}
	}
}
