using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeSpinTrig : MonoBehaviour {
	public GameObject PB ;
	public GameObject PR ;
	public GameObject Spin ;

	void Awake () {
		PB = GameObject.Find ("PlayerBlue") ;
		PR = GameObject.Find ("PlayerRed") ;
		//Spin = GameObject.Find ("Spin") ;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider Other) {
		if (Other.tag == "PlayerB") {
			PB.GetComponent <AimTest> ().FreeSpin = true;
			Spin.SetActive (true) ;
		}
		if (Other.tag == "PlayerR") {
			PR.GetComponent <AimTest> ().FreeSpin = true;
		}
	}
}
