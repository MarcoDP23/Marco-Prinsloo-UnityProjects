using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;

public class GameCtrl : MonoBehaviour {
	public int[] Order ;
	public int ShrineActv01 = 0 ;
	public int ShrineActv02 = 0 ;
	public int ShrineActv03 = 0 ;
	public bool AllShrineActv = false ;
	public bool Failed = false ;
	public GameObject WinText ;
	public GameObject LoseText ;
	public KeyCode Exit = KeyCode.Escape ;
	public int Count = 0 ; 
	public bool StartCount = false;

	// Use this for initialization
	void Start () {
		Order = new int[3] ;
		Order [0] = 1 ;
		Order [1] = 2 ;
		Order [2] = 3 ;
	}

	void FixedUpdate () {
		if (StartCount == true) {
			Count = Count + 1 ; 
		}
	}

	// Update is called once per frame
	void Update () {
		if (ShrineActv01 == Order [0] && ShrineActv02 == Order [1] && ShrineActv03 == Order [2]) {
			AllShrineActv = true;
			WinText.SetActive (true) ;
		} else if (ShrineActv01 != 0 && ShrineActv02 != 0 && ShrineActv03 != 0){
			Failed = true ;
			LoseText.SetActive (true) ;
			StartCount = true ;
		}
		if (Input.GetKeyDown(Exit)) {
			Application.Quit () ;
		}
		if (Count >= 130) {
			SceneManager.LoadScene (0);
		}
		
	}
	public void setShrineActive(int ShrineID) {
		if (ShrineActv01 == 0) {
			ShrineActv01 = ShrineID;
		} else if (ShrineActv02 == 0 && ShrineActv01 != 0) {
			ShrineActv02 = ShrineID;
		} else if (ShrineActv03 == 0 && ShrineActv01 != 0 && ShrineActv02 != 0) {
			ShrineActv03 = ShrineID ;
		}
	}
		
}
