using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class End_trig : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player" && other.GetComponent <Player_Ctrl> ().HasKey == true) {
			SceneManager.LoadScene (2);
		} else if (other.tag == "Player" && other.GetComponent <Player_Ctrl> ().HasKey == false) {
			other.GetComponent <Player_Ctrl> ().NeedKeytxt.SetActive (true) ;
		}
	}
}
