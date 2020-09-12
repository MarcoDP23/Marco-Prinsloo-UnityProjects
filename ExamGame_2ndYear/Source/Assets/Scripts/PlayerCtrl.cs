using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour {
	public KeyCode Exit = KeyCode.Escape ;
	public KeyCode MoveUp = KeyCode.W ;
	public KeyCode Restart = KeyCode.R ;
	public KeyCode MoveDown = KeyCode.S ;
	public KeyCode MoveRight = KeyCode.D ;
	public KeyCode MoveLeft = KeyCode.A ;
	public float MovementSpeed = 0.5f ;
	public int score ;
	public Rigidbody Player ;
	public GameObject GameC ;
	private Vector3 pos ;
	public GameObject DeathPart ;
	public AudioSource DSound ;

	void Awake () {
		GameC = GameObject.Find ("GameCtrl") ;
		DSound = GameObject.Find ("GameObject").GetComponent <AudioSource> () ;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () {
		if (Input.GetKey (MoveUp)) {// moves, but oriented to work with facing down
			this.transform.Translate (new Vector3 (0f, 0f,MovementSpeed));
			//Player.AddForce (new Vector3 (0f, 0f, MovementSpeed)) ;
		}
		if (Input.GetKey (MoveDown)) {
			this.transform.Translate (new Vector3 (0f, 0f,-MovementSpeed));
			//Player.AddForce (new Vector3 (0f, 0f, -MovementSpeed)) ;
		}
		if (Input.GetKey (MoveRight)) {
			this.transform.Translate (new Vector3 (MovementSpeed, 0f, 0f));
			//Player.AddForce (new Vector3 (MovementSpeed, 0f, 0f)) ;
		}
		if (Input.GetKey (MoveLeft)) {
			this.transform.Translate (new Vector3 (-MovementSpeed, 0f, 0f));
			//Player.AddForce (new Vector3 (-MovementSpeed, 0f, 0f)) ;
		}
		score = GameC.GetComponent <GameCtrl> ().Score ;
		pos = this.transform.position ;
		pos.x = Mathf.Clamp (pos.x, -12f, 12f) ;
		pos.z = Mathf.Clamp (pos.z, -12f, 12f) ;
		this.transform.position = pos ;
		if (score >= 20 && score < 60){
			this.transform.Rotate (Vector3.up) ; //Rotates the player, orientated for facing down
		}
		if (score >= 80 && score < 120){
			this.transform.Rotate (Vector3.down) ; //Rotates the  player, orientated for facing down
		}

	}
	void OnCollisionEnter (Collision Other) {
		this.transform.DetachChildren () ;
		DSound.Play () ;
		Destroy (this.gameObject) ;
		GameC.GetComponent <GameCtrl> ().PlayerDead = true ;
		Instantiate (DeathPart, this.transform.position, Quaternion.identity) ;
	}
}
