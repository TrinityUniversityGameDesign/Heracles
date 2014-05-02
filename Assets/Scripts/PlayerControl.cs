using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	
	
	//	bool facingRight = true;
	public Vector2 resetPosition = new Vector2 (-7.5f, -1.75f);

	public float runSpeed;
	public float crouchSpeed;
	private float speed;
	private float crouchHeight = .5f;
	public bool paused;

	private float speedTemp;
	private float runSpeedTemp;
	
	public Transform groundCheck;
	float groundRadius = 0.3f;
	bool grounded = false;
	bool groundedLoop = false;
	public AudioSource[] sounds;
	public AudioSource jumpAS;
	public AudioSource footstepsAS;
	public AudioClip jumpSound;
	public AudioClip footsteps;
	public LayerMask groundMask;
	public float jumpPower;
	public string horizAxisName = "Horizontal";
	public string jumpAxisName = "Vertical";
	
	private float crouch;
	private bool isCrouched = false;
	private float animIdleRate = 4f;
	private float idleCooldown;
	private bool facingRight = true;
	private bool isShooting = false;
	private bool isClimbing = false;
	private float inputX;
	
	public Component boxcollider;
	
	BoxCollider2D bc = new BoxCollider2D();
	
	//	bool dead = false;
	
	Animator anim;
	void Awake() {
		if (!grounded) {
			groundedLoop = true;
		}
		idleCooldown = animIdleRate;
		anim = GetComponent<Animator> ();
		bc = GetComponent<BoxCollider2D>();
		speed = runSpeed;
	}

	void Start()
	{
		sounds = GetComponents<AudioSource>();
		jumpAS = sounds[0];
		footstepsAS = sounds[1];
	}
	
	// Update is called once per frame
	void Update () {
		crouch = 1f;
		if (paused)	Time.timeScale = 0;	else Time.timeScale = 1;
		Collider2D[] GroundList = Physics2D.OverlapCircleAll (groundCheck.position, groundRadius,groundMask);
		grounded = false;
		if (GroundList.Length > 0) {
			for (int a =0; a<GroundList.Length; a++) {
				if (!GroundList [a].isTrigger) {
					grounded = true;
				}
			}
		}

		//grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, groundMask);
		
		bool jump = Input.GetButtonDown (jumpAxisName);
		if (jump && grounded && Input.GetAxis(jumpAxisName)>0) {
			rigidbody2D.AddForce (new Vector2 (0, jumpPower));
			jumpAS.PlayOneShot (jumpSound);
		}
		if (grounded && Input.GetAxis (horizAxisName) > 0) {
			if (!footstepsAS.isPlaying) {
				footstepsAS.clip = footsteps;
				footstepsAS.Play ();
			}
		} else if (footstepsAS.isPlaying) {
			footstepsAS.Stop ();
		}
		crouch = Input.GetAxis ("Vertical");
		//if (crouch != -1f) crouch = 0f;
		if (crouch < 0) {
			if (!isCrouched) {
				anim.SetBool("Crouch",true);
				isCrouched = true;
				speed = crouchSpeed;
				//BoxCollider2D = new BoxCollider2D (BoxCollider2D.size.x, crouchHeight);//BoxCollider2D.size.y = BoxCollider2D.size.y / 2;
				bc.size = new Vector2(bc.size.x,crouchHeight);
				bc.center = new Vector2(bc.center.x,-.25f);
			}
		} else {
			anim.SetBool("Crouch",false);
			isCrouched = false;
			speed = runSpeed;
			bc.size = new Vector2(bc.size.x, 1f);
			bc.center = new Vector2(bc.center.x, 0f);
		}
		if (Input.GetKey(KeyCode.Q)){
			gameObject.transform.position = GRE_PS_Checkpoint.respawnPos;
		}
		if (Input.GetKeyDown(KeyCode.Escape)){ //why does GetButtonDown not have escape but GetKey does?  The world may never know.
			if(!paused) {
				//Time.timeScale=0;
				paused=true;
			} else {
				//Time.timeScale=1;
				paused=false;
			}
				
		}
		
		if (idleCooldown > 0)
			idleCooldown -= Time.deltaTime;
		if (idleCooldown < 0){
			idleCooldown = animIdleRate;
			anim.SetTrigger("doPuff");
		}
	}
	
	public void flipDirection() {
		facingRight = !facingRight;
		Vector3 transScale = transform.localScale;
		transScale.x *= -1;
		transform.localScale = transScale;
	}
	
	void FixedUpdate () {
		inputX = Input.GetAxis (horizAxisName);
		float vel = inputX * speed;
		rigidbody2D.velocity = new Vector2 (vel, rigidbody2D.velocity.y);
		
		if (Input.GetButton("Fire") && grounded && inputX == 0) {
			isShooting = true;
			anim.SetBool("isShooting",isShooting);
		}
		if (!Input.GetButton("Fire") && isShooting && GetComponent<ShootingScript>().DontShoot()) {
			isShooting = false;
			anim.SetTrigger("doShoot");
			anim.SetBool("isShooting",isShooting);
		}
		else if (!Input.GetButton("Fire") && isShooting) {
			isShooting = false;
			anim.SetBool("isShooting",isShooting);
		}
		anim.SetFloat("Speed", Mathf.Abs(vel));
		anim.SetFloat("vSpeed", rigidbody2D.velocity.y);
		anim.SetBool("Grounded",grounded);
		
		if (inputX > 0 && !facingRight) flipDirection();
		else if (inputX < 0 && facingRight) flipDirection();
		if (inputX > 0) idleCooldown = animIdleRate;
	}

	public void SetClimbing(bool input) {
		isClimbing = input;
	}

	public void SetMove(bool input) {
		if (input) {
			speed = 6;
			runSpeed = 6;
			jumpPower = 800;
		} else {
			speed = 0;
			runSpeed = 0;
			jumpPower = 0;
		}
	}
	
	public bool IsFacingRight() {
		return facingRight;
	}

	public bool IsGrounded() {
		return grounded;
	}

	public bool CanShoot() {
		if (grounded && inputX != 0)
			return false;
		else
			return true;
	}

	public bool IsClimbing() {
		return isClimbing;
	}
	void OnGUI(){
		if(paused) {
			if(GUI.Button (new Rect ((Screen.width/2)-100, (Screen.height/2)-50, 180, 40), "Resume")){
				paused=false;
			}
			if(GUI.Button (new Rect ((Screen.width/2)-100, (Screen.height/2), 180, 40), "Go back To Previous Checkpoint")){
				paused=false;
				gameObject.transform.position = GRE_PS_Checkpoint.respawnPos;
			}
			if(GUI.Button (new Rect ((Screen.width/2)-100, (Screen.height/2)+50, 180, 40), "Quit")){
				Application.Quit();
			}
		}
	}

}