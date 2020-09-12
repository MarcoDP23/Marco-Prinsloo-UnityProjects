using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI ;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;

public class Player_Ctrl : MonoBehaviour {
	public float Rotate_Amount = 10f; 
	public float Rotate_Speed = 100f ;
	public float max_X = 360f ;
	public float min_X = -360f ;
	public float max_y = 60f ;
	public float min_y = -60f ;
	public float Move_Speed = 1f ;
	public int Health = 100;
	public bool HasKey = false ;
	public bool isWalking = false ;

	private Rigidbody P_rb ;
	public KeyCode Exit = KeyCode.Escape ;
	public Text Healthtxt ;
	public GameObject HaveKeytxt ;
	public GameObject NeedKeytxt ;
	public GameObject light01 ;
	public GameObject BrightlLight ; 
	public bool TrapActive = false ;
	public int TrapCount = 0 ;
	public Animator PlayerAnim ; 

	public float sensitivity = 5.0f ;
	public float smoothing = 2.0f ;
	GameObject Capsule ;
	private Vector2 M_look ;
	private Vector2 smoothV ;
	private Vector2 md ;

	private NavMeshAgent nav ;
	// Use this for initialization
	void Start () {
		P_rb = this.GetComponent<Rigidbody> () ;
		Capsule = this.transform.gameObject ;
		nav = this.GetComponent<NavMeshAgent> () ;
		PlayerAnim = GetComponentInChildren<Animator> () ;
		PlayerAnim.SetBool ("isIdle",true) ;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//RotateCam () ;
		//P_Move () ;

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition) ; //creates a ray from the mouses position
		RaycastHit MClick ; // allows info to gathered from ray
		if (Input.GetMouseButtonDown (0)) { // when the left mouse button is clicked
			if (Physics.Raycast (ray, out MClick, 100)) { //casts the ray 100 units and checks where the ray is colliding
				//Menutext.SetActive (false) ;
				//CreditText.SetActive (false) ;
				//Instantiate (Particle, MClick.point, Quaternion.identity); //instantiates the particle effect
				nav.destination = MClick.point; //set the point to which the player must move as the point where the ray touches the nav mesh
			}
		}


		if (Input.GetKeyDown (Exit)) {
			SceneManager.LoadScene (0) ;
		}

		if (Health <= 0) {
			SceneManager.LoadScene (3);
		}

		Healthtxt.text = "Health:" + Health + "%" ;

		if (HasKey == true) {
			HaveKeytxt.SetActive (true) ;
			NeedKeytxt.SetActive (false) ;
		}
		if (nav.remainingDistance > 0)
		{
			isWalking = true ;
			PlayerAnim.SetBool ("isRunning",true) ; 
			PlayerAnim.SetBool ("isWalking",false) ; 
			PlayerAnim.SetBool ("isIdle",false) ; 

			light01.SetActive (true) ;
			BrightlLight.SetActive  (false) ;
		}
		else
		{
			isWalking = false ;
			PlayerAnim.SetBool ("isRunning",false) ; 
			PlayerAnim.SetBool ("isWalking",false) ; 
			PlayerAnim.SetBool ("isIdle",true) ; 
			light01.SetActive (false) ;
			BrightlLight.SetActive (true) ;
		}

		if (TrapActive == true) {
			TrapCount++ ; 
		}
		if (TrapCount <= 200 && TrapActive == true) {
			this.nav.speed = 2f ;
		}
		if (TrapCount > 200 && TrapActive == true) {
			TrapActive = false ;
			TrapCount = 0 ;
			this.nav.speed = 5f ;
		}

		if (this.nav.speed == 2f && isWalking == true) {
			PlayerAnim.SetBool ("isRunning",false) ; 
			PlayerAnim.SetBool ("isWalking",true) ; 
			PlayerAnim.SetBool ("isIdle",false) ; 
		}
	}


	//private void RotateCam () {
		//Vector3 Cam_Ro_Origin = Camera.main.transform.eulerAngles ;
		//Vector3 Cam_Ro_Destination = Cam_Ro_Origin ;


		//md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) ;
		//md = Vector2.Scale (md, new Vector2 (sensitivity*smoothing, sensitivity*smoothing)) ;
		//smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing) ;
		//smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing) ;
		//M_look += smoothV ;

		//Camera.main.transform.localRotation = Quaternion.AngleAxis (-M_look.y, Vector3.right) ;
		//Capsule.transform.localRotation = Quaternion.AngleAxis (M_look.x, Capsule.transform.up) ;
		//Detect rotation amount
		//if (Input.GetMouseButton(2)) {
		//Cam_Ro_Destination.x -= Mathf.Clamp(Input.GetAxis ("Mouse Y") * Rotate_Amount, min_X, max_X) ;
		//Cam_Ro_Destination.y += Mathf.Clamp(Input.GetAxis ("Mouse X") * Rotate_Amount, min_y, max_y) ;
		//}

		//Actually rotates cam
		//if (Cam_Ro_Destination != Cam_Ro_Origin) {
			//Camera.main.transform.eulerAngles = Vector3.MoveTowards (Cam_Ro_Origin, Cam_Ro_Destination, Time.deltaTime * Rotate_Speed) ;

		//}
	//}

	//private void P_Move () {
		//float moveHor = Input.GetAxis ("Horizontal") * Move_Speed ;
		//float moveVert = Input.GetAxis ("Vertical") * Move_Speed ;

		//moveHor *= Time.deltaTime ;
		//moveVert *= Time.deltaTime ;  

		//Vector3 move = new Vector3 (moveHor, 0.0f, moveVert) ;
		//P_rb.AddForce (move * Move_Speed) ;
		//this.transform.Translate(moveHor, 0.0f, moveVert) ;
	//}
}
