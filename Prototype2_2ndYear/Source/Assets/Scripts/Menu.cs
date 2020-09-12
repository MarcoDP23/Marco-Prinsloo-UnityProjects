using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;

public class Menu : MonoBehaviour {
	public KeyCode StartButt = KeyCode.Space ;
	public KeyCode Exit = KeyCode.Escape ;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	  if (Input.GetKeyDown(StartButt)) {
				SceneManager.LoadScene (1) ;
	 }
	  if (Input.GetKeyDown(Exit)) {
				Application.Quit () ;
	  }
	}
}
