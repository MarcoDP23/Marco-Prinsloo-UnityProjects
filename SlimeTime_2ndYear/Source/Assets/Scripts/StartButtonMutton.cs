using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;

public class StartButtonMutton : MonoBehaviour {
    private AudioSource ButtonSound ;
	private int RandLvl ;
	public void LoadScene () {
		ButtonSound = GetComponent<AudioSource> () ;
		RandLvl = Random.Range (1 , 4);
		ButtonSound.Play () ;
		SceneManager.LoadScene (RandLvl) ;
	}

}
