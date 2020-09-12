using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour {
	public Transform ObjFollow ;
	public float smoothSpeed = 10f ;
	public Vector3 offset ;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LateUpdate () {
		Vector3 desiredPos = ObjFollow.position + offset ;
		Vector3 smoothedPos = Vector3.Lerp (transform.position, desiredPos, smoothSpeed) ;

		transform.position = smoothedPos ;

		transform.LookAt (ObjFollow) ;
	}
}
