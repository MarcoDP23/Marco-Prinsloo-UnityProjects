﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part : MonoBehaviour {
	public int count = 0 ;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		count = count + 1 ;
		if (count >= 50){
			Destroy (this.gameObject) ;
		}
	}
}
