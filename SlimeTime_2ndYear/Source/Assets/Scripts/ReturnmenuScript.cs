using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;

public class ReturnmenuScript : MonoBehaviour {
	private AudioSource ButtonSound ;
	private int RandLvl ;
	public void LoadScene (int scene) {
		ButtonSound = GetComponent<AudioSource> () ;
		ButtonSound.Play () ;
		SceneManager.LoadScene (scene) ;
	}
}
