using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimTest : MonoBehaviour {
	private float angle = Mathf.PI / 2;
	public float speed = 0.3f ;
	public bool FreeSpin = false ;
	public Transform Player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey (KeyCode.Space)) {
			this.transform.RotateAround (Player.position, Vector3.up, angle * speed);
			speed = speed + 0.005f ;
		}
		else if (FreeSpin == true) {
			this.transform.RotateAround (Player.position, Vector3.up, angle * -speed);
			}
			speed = speed + 0.005f ;
	}

}
