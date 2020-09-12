using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSpin : MonoBehaviour {
	private float angle = Mathf.PI / 2;
	public float speed = 1f ;
	public bool FreeSpin = false ;
	public Transform Player;
	// Use this for initialization
	void Start () {
		FreeSpin = true ;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FixedUpdate () {
		if (FreeSpin == true) {
			this.transform.RotateAround (Player.position, Vector3.up, angle * -speed);
		}

	}
}
