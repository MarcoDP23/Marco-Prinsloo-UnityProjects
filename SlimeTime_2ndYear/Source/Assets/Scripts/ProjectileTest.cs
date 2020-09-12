using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTest : MonoBehaviour {
	private Rigidbody2D rb ;
	public float bulletMagnitude = 7f ;
	public float xPos2 ;
	public float yPos2 ;
	public GameObject Aimret ;
	public GameObject P2_Healthbar ;
	public GameObject P1_Bpart ;
	public GameObject Tile_Part ;
	private AudioSource Hit ;
    // Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> () ;
		Hit = GetComponent <AudioSource> () ;
		Aimret = GameObject.Find ("P1Ret") ; 
		xPos2 = Aimret.GetComponent<AimTest>().xPosP ;
		yPos2 = Aimret.GetComponent<AimTest> ().yPosP ;
		rb.AddForce (new Vector2(xPos2*bulletMagnitude,yPos2*bulletMagnitude));
		P2_Healthbar = GameObject.Find ("P2_HealthFill");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Tile") {
			Hit.Play () ;
			Instantiate (P1_Bpart, this.transform.position, this.transform.rotation) ;
			//Instantiate (Tile_Part, this.transform.position, this.transform.rotation) ;
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
		if (other.tag == "KillBox") {
			Destroy (gameObject);
		}
		if (other.tag == "Player2") {
			Hit.Play () ;
			P2_Healthbar.GetComponent<P2_HealthBar> ().P2_Health -= 10f ;
			Instantiate (P1_Bpart, this.transform.position, this.transform.rotation) ;
			Destroy (gameObject);
		}
	}
}
