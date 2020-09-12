using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Projectile : MonoBehaviour {
	private Rigidbody2D rb ;
	public float bulletMagnitude = 7f ;
	public float xPos2 ;
	public float yPos2 ;
	public GameObject Aimret ;
	public GameObject P1_Health ;
	public GameObject P2_Bpart ;
	public GameObject Tile_Part ;
	private AudioSource Hit ;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> () ;
		Hit = GetComponent <AudioSource> () ;
		Aimret = GameObject.Find ("P2RetTrue") ;
		xPos2 = Aimret.GetComponent<P2RetAim> ().xPosP ;
		yPos2 = Aimret.GetComponent<P2RetAim> ().yPosP ;
		rb.AddForce (new Vector2(xPos2*bulletMagnitude,yPos2*bulletMagnitude));
		P1_Health = GameObject.Find ("P1_HealthFill");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Tile") {
			Hit.Play () ;
			Instantiate (P2_Bpart, this.transform.position, this.transform.rotation) ;
			//Instantiate (Tile_Part, this.transform.position, this.transform.rotation) ;
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
		if (other.tag == "KillBox") {
			Destroy (gameObject);
		}
		if (other.tag == "Player1") {
			Hit.Play () ;
			P1_Health.GetComponent<P1_HealthBar> ().P1_Health -= 10f ;
			Instantiate (P2_Bpart, this.transform.position, this.transform.rotation) ;
			Destroy (gameObject);
		}
	}
}
