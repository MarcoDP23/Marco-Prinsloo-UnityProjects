using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;

public class Player2Control : MonoBehaviour {
	public GameObject Bullet ;
	public KeyCode Fire = KeyCode.Space ;
	public KeyCode MoveRight = KeyCode.D ;
	public KeyCode MoveLeft = KeyCode.A ;
	public KeyCode Jump = KeyCode.W ;
	public float MoveSpeed = 0.05f ;
	public float JumpSpeed = 10f ;
	public float BulletMagnitude = 0.5f ;
	public float MovingBullet ; 
	public GameObject GameControl ;
	private Rigidbody2D P2Rb ;
	public GameObject P2_Health ;
	public ParticleSystem DeathPart ;
	private Transform BulletSpawn ;
	private Vector3 tempBSpawn ;
	private AudioSource Shot ;
	// Use this for initialization
	void Start () {
		GameControl = GameObject.Find ("GameController") ;
		P2Rb = GetComponent<Rigidbody2D> () ;
		P2_Health = GameObject.Find ("P2_HealthFill");
		Shot = GetComponent <AudioSource> () ;
	}

	// Update is called once per frame
	void Update () {
		if (P2_Health.GetComponent<P2_HealthBar> ().P2_Health == 0f) {
			Instantiate (DeathPart, this.transform.position, this.transform.rotation) ;
			Destroy (gameObject) ;
			SceneManager.LoadScene (5) ;
		}
		tempBSpawn = this.transform.position ;
		tempBSpawn.y += 0.5f ;
		BulletSpawn = this.transform ;
	}

	void FixedUpdate () {
		if (Input.GetKey (Fire) && Time.time > MovingBullet && GameControl.GetComponent<GameControl> ().TheGameState == global::GameControl.GameState.P2Shoot) {
			MovingBullet = Time.time + BulletMagnitude ;
			Shot.Play () ;
			Instantiate (Bullet, tempBSpawn, this.transform.rotation); 
			GameControl.GetComponent<GameControl> ().TheGameState = global::GameControl.GameState.P1StandBy ; 
			GameControl.GetComponent<GameControl> ().TimerShoot = 5f ;
		}
		if (Input.GetKey (MoveRight) && GameControl.GetComponent<GameControl> ().TheGameState == global::GameControl.GameState.P2Move) {
			transform.Translate (new Vector2 (MoveSpeed, 0f));
		}
		if (Input.GetKey (MoveLeft) && GameControl.GetComponent<GameControl> ().TheGameState == global::GameControl.GameState.P2Move) {
			transform.Translate (new Vector2 (-MoveSpeed, 0f));
		}
		if (Input.GetKey (Jump) && GameControl.GetComponent<GameControl> ().TheGameState == global::GameControl.GameState.P2Move) {
			P2Rb.AddForce (new Vector2 (0f, JumpSpeed)) ;
		}
	}
}
