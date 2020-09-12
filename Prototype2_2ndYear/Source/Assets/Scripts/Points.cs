using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;

public class Points : MonoBehaviour {
	public GameObject Core ;

	void Awake () {
		Core = GameObject.Find ("Player");
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider Other) {
		if (Other.tag == "PlayerR") {
				Core.GetComponent <Script> ().GivePoint = true ;
		}
	}
}
