using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;

public class TestPlayerControl : MonoBehaviour {
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
	private Rigidbody2D P1Rb ;
	public ParticleSystem MovePart ;
	public GameObject P1_Health ;
	public ParticleSystem DeathPart ;
	private Transform BulletSpawn ;
	private Vector3 tempBSpawn ;
	private AudioSource Shot ;
	// Use this for initialization
	void Start () {
		GameControl = GameObject.Find ("GameController");
		P1Rb = GetComponent<Rigidbody2D> ();
		P1_Health = GameObject.Find ("P1_HealthFill");
		Shot = GetComponent <AudioSource> () ;
	}
	// Update is called once per frame
	void Update () {
		if (P1_Health.GetComponent<P1_HealthBar> ().P1_Health == 0f) {
			Instantiate (DeathPart, this.transform.position, this.transform.rotation) ;
			Destroy (gameObject) ;
			SceneManager.LoadScene (6) ;
		}
		tempBSpawn = this.transform.position ;
		tempBSpawn.y += 0.5f ;
		BulletSpawn = this.transform ;

	}

	void FixedUpdate () {
		if (Input.GetKey (Fire) && Time.time > MovingBullet && GameControl.GetComponent<GameControl> ().TheGameState == global::GameControl.GameState.P1Shoot) {
			MovingBullet = Time.time + BulletMagnitude ;
			Shot.Play () ;
			Instantiate (Bullet, tempBSpawn, BulletSpawn.rotation); 
			GameControl.GetComponent<GameControl> ().TheGameState = global::GameControl.GameState.P2StandBy ;
			GameControl.GetComponent<GameControl> ().TimerShoot = 5f ;
		}
		if (Input.GetKey (MoveRight) && GameControl.GetComponent<GameControl> ().TheGameState == global::GameControl.GameState.P1Move) {
			transform.Translate (new Vector2 (MoveSpeed, 0f));

		}
		if (Input.GetKeyUp (MoveRight)) {

		}
		if (Input.GetKey (MoveLeft) && GameControl.GetComponent<GameControl> ().TheGameState == global::GameControl.GameState.P1Move) {
			transform.Translate (new Vector2 (-MoveSpeed, 0f));

		}
		if (Input.GetKeyUp (MoveLeft)) {

		}
		if (Input.GetKey (Jump) && GameControl.GetComponent<GameControl> ().TheGameState == global::GameControl.GameState.P1Move) {
			P1Rb.AddForce (new Vector2 (0f, JumpSpeed)) ;
		}
	}
}
