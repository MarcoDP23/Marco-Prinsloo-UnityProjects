using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn2 : MonoBehaviour {
	public int SpawnNum ;
	public GameObject GameControl ;
	public GameObject P2_Prefab ;
	// Use this for initialization
	void Start () {
		GameControl = GameObject.Find ("GameController") ;
		if ( GameControl.GetComponent<GameControl> ().RanP2_Spawn == SpawnNum) {
			Instantiate (P2_Prefab, this.transform.position, this.transform.rotation) ;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
