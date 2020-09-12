using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
	public int SpawnNum ;
	public GameObject GameControl ;
	public GameObject P1_Prefab ;
	// Use this for initialization
	void Start () {
		GameControl = GameObject.Find ("GameController") ;
		if ( GameControl.GetComponent<GameControl> ().RanP1_Spawn == SpawnNum) {
			Instantiate (P1_Prefab, this.transform.position, this.transform.rotation) ;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
