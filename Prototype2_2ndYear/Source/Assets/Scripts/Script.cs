using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;
using UnityEngine.SceneManagement ;

public class Script : MonoBehaviour {
	public float speed = 0.5f ;
	public Text Pts ;
	public float AmountP ;
	public bool GivePoint = false ;
	public KeyCode Exit = KeyCode.Escape ;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		this.transform.Translate (new Vector3 (0, speed));
		speed = speed + 0.005f ;
	}

	void Update () {
		if (GivePoint == true) {
			AddPoints () ;
		}
		if (Input.GetKeyDown(Exit)) {
			SceneManager.LoadScene (0) ;
		}
	}

	void AddPoints () {
		AmountP = AmountP + 10f ;
		Pts.text =  "" + Mathf.Round(AmountP);
		GivePoint = false ;
	}

}
