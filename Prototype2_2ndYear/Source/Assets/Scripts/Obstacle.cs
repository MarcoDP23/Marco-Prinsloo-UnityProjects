using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;

public class Obstacle : MonoBehaviour {
	public GameObject Part ;
	public bool StartCount = false;
	public int Count = 0 ; 
	public AudioSource DSound ;
	public AudioSource Music ;
	// Use this for initialization
	void Start () {
		
	}

	void Awake () {
		Music = GameObject.Find ("Player").GetComponent <AudioSource> () ;
		DSound = GameObject.Find ("Main Camera").GetComponent <AudioSource> () ;
	}
	
	// Update is called once per frame
	void Update () {
		if (Count >= 80) {
			SceneManager.LoadScene (1);
		}
	}

	void FixedUpdate () {
		if (StartCount == true) {
			Count = Count + 1 ; 
		}
	}

	void OnTriggerEnter (Collider Other) {
		if (Other.tag == "PlayerR" || Other.tag == "PlayerB") {
			Instantiate (Part, Other.transform.position, Other.transform.rotation); 
			Destroy (Other.gameObject) ;
			Music.Stop () ;
			DSound.Play () ;
			StartCount = true ;
		}
	}
}
