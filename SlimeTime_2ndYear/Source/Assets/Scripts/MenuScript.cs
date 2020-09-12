using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour {
	private SpriteRenderer BGRenderer ;
	public Sprite BG01 ;
	public Sprite BG02 ;
	public Sprite BG03 ;
	public KeyCode Esc = KeyCode.Escape ;
	private int count = 0 ;
	private bool Sprt01Active ;
	private bool Sprt02Active ;
	private bool Sprt03Active ;
	// Use this for initialization
	void Start () {
		BGRenderer = GetComponent <SpriteRenderer> () ;
		count = 0 ;
		BGRenderer.sprite = BG01 ;
		Sprt01Active = true ;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (Esc)) {
			Application.Quit () ;
		}
	}
	void FixedUpdate () {
		count ++ ;
		if (count == 100 && Sprt01Active == true) {
			BGRenderer.sprite = BG02 ;
			Sprt02Active = true ;
			Sprt01Active = false ;
			count = 0 ;
		}
		if (count == 100 && Sprt02Active == true) {
			BGRenderer.sprite = BG03 ;
			Sprt03Active = true ;
			Sprt02Active = false ;
			count = 0 ;
		}
		if (count == 100 && Sprt03Active == true) {
			BGRenderer.sprite = BG01 ;
			Sprt01Active = true ;
			Sprt03Active = false ;
			count = 0 ;
		}
	}
}
