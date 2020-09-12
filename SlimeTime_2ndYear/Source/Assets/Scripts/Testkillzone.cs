using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;

public class Testkillzone : MonoBehaviour {
	public GameObject P1_Health ;
	public GameObject P2_Health ;
	// Use this for initialization
	void Start () {
		P1_Health = GameObject.Find ("P1_HealthFill");
		P2_Health = GameObject.Find ("P2_HealthFill");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Bullet") {
			Destroy (other.gameObject) ;
		}
		if (other.tag == "Player1") {
			Destroy (other.gameObject) ;
			P1_Health.GetComponent<P1_HealthBar> ().P1_Health = 0f ;
			SceneManager.LoadScene (6) ;
		}
		if (other.tag == "Player2") {
			Destroy (other.gameObject) ;
			P2_Health.GetComponent<P2_HealthBar> ().P2_Health = 0f ;
			SceneManager.LoadScene (5) ;
		}
	}
}
