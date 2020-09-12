using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour {
	public GameObject EndTrig ;
	public GameObject Spin ;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter (Collider Other) {
		if (Other.tag == "PlayerB" || Other.tag == "PlayerR") {
			EndTrig.SetActive (true);
			Spin.SetActive (false) ;
		}
	}
}
