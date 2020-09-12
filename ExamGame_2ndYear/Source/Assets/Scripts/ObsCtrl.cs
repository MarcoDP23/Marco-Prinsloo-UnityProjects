using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsCtrl : MonoBehaviour {
	public float MovementSpeed = 0.5f ;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FixedUpdate () {
		this.transform.Translate (new Vector3 (0f, MovementSpeed, 0f)) ; // moves the obstacles, oriented for facing down player
		MovementSpeed = MovementSpeed + 0.05f ;
		if (MovementSpeed == 15f){
			MovementSpeed = 0.5f ;
		}
	}
}
