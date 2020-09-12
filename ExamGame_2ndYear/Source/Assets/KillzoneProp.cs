using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillzoneProp : MonoBehaviour {
	public GameObject [] Prop ;
	public int SelectRand ; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider Other) {
		if (Other.tag == "Prop") {
			Destroy (Other.gameObject) ;
			SelectRand = Random.Range (0, 3);
			Instantiate (Prop [SelectRand], Prop[SelectRand].transform.position, Quaternion.identity) ;
		}
	}
}
