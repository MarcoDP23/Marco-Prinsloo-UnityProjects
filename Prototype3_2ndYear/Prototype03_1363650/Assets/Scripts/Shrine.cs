using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrine : MonoBehaviour {
	private Animator ShrineAnim ;
	public int ShrineID ;
	public GameObject GameCtr ;
	public AudioSource ShrineSound ;
	// Use this for initialization
	void Awake () {
		GameCtr = GameObject.Find ("GameCtrl") ;
		ShrineSound = GameObject.Find ("Main Camera").GetComponent <AudioSource> () ;
	}

	void Start () {
	  ShrineAnim = GetComponentInParent <Animator> () ;
		if (this.tag == "OShrine") {
			ShrineID = 1 ;
		}
		if (this.tag == "BShrine") {
			ShrineID = 2 ;
		}
		if (this.tag == "PShrine") {
			ShrineID = 3 ;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider Other) {
		ShrineAnim.SetBool ("ShrineActive", true) ;
		GameCtr.GetComponent<GameCtrl> ().setShrineActive (ShrineID) ;
		ShrineSound.Play () ;
	}
}
