using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PointsB : MonoBehaviour {
	public GameObject Core ;

	void Awake () {
		Core = GameObject.Find ("Player") ;
	}
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter (Collider Other) {
		if (Other.tag == "PlayerB") {
			Core.GetComponent <Script> ().GivePoint = true ;
		}
	}
}
