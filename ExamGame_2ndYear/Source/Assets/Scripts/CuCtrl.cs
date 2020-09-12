using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuCtrl : MonoBehaviour {
	public GameObject DeathPart ;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter (Collision Other) {
		Destroy (this.gameObject) ;
		Instantiate (DeathPart, this.transform.position, Quaternion.identity) ;
	}
}
