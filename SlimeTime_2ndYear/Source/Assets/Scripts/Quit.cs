using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour {
	private AudioSource ButtonSound ;

	public void QiutGame () {
		ButtonSound = GetComponent<AudioSource> () ;
		ButtonSound.Play ();
		Application.Quit () ;
	}
}
