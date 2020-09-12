using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;

public class MenuCtrl : MonoBehaviour {
	public KeyCode StartButt = KeyCode.Space ;
	public KeyCode Exit = KeyCode.Escape ;
	public GameObject [] Cu ;
	public int Count = 0 ;
	public int SelectRand ;

	void Awake () {
		Time.timeScale = 1f ;
	}
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
	void FixedUpdate () {
		Count = Count + 1 ;
		if (Count == 80) {
			SelectRand = Random.Range (0, 3);
			Instantiate (Cu [SelectRand], Cu[SelectRand].transform.position, Quaternion.identity) ;
			Count = 0 ;
		}
	}
}
