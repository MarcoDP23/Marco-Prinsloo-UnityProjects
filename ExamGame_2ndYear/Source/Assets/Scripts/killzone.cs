using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killzone : MonoBehaviour {
	public GameObject GameC ;

	void Awake () {
		GameC = GameObject.Find ("GameCtrl") ;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter (Collider Other) {
		if (Other.tag != "Guide") {
		GameC.GetComponent <GameCtrl> ().Score = GameC.GetComponent <GameCtrl> ().Score + 1 ;
		Destroy (Other.gameObject) ;
		}
		if (Other.tag == "Guide") {
			Destroy (Other.gameObject) ;
		}
	}
}
