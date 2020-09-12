using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;
using UnityEngine.SceneManagement ;

public class GameControl : MonoBehaviour {
	public enum GameState {
		P1StandBy,
		P1Move,
		P1Shoot,
		P2StandBy,
		P2Move,
		P2Shoot
	} ;
	public KeyCode StateShoot = KeyCode.W ;
	public KeyCode StateMove = KeyCode.S  ;
	public GameState TheGameState ;
	public float TimerMove = 5f ;
	public float TimerShoot = 5f ;
	public Text P1_Timer ;
	public Text P2_Timer ;
	public float RanP1_Spawn ;
	public float RanP2_Spawn ;
	public GameObject P1_Ttxt ;
	public GameObject P2_Ttxt ;
	public GameObject TCtrlTxt ;
	public KeyCode Esc = KeyCode.Escape ;

	void Awake () {
		RanP1_Spawn = Random.Range (1 , 4);
		RanP2_Spawn = Random.Range (1 , 4);
	}
	// Use this for initialization
	void Start () {
		TheGameState = GameState.P1StandBy ;
	}
	
	// Update is called once per frame
	void Update () {
		if ((TheGameState == GameState.P1StandBy) && (Input.GetKey (StateShoot))){
			P1_Ttxt.SetActive (false) ;
			TCtrlTxt.SetActive (false) ;
			TheGameState = GameState.P1Shoot ;
		}
		if ((TheGameState == GameState.P1StandBy) && (Input.GetKey (StateMove))) {
			P1_Ttxt.SetActive (false) ;
			TCtrlTxt.SetActive (false) ;
			TheGameState = GameState.P1Move ;
		}
		if ((TheGameState == GameState.P2StandBy) && (Input.GetKey (StateShoot))){
			P2_Ttxt.SetActive (false) ;
			TCtrlTxt.SetActive (false) ;
			TheGameState = GameState.P2Shoot ;
		}
		if ((TheGameState == GameState.P2StandBy) && (Input.GetKey (StateMove))) {
			P2_Ttxt.SetActive (false) ;
			TCtrlTxt.SetActive (false) ;
			TheGameState = GameState.P2Move ;
		}
		if (TheGameState == GameState.P1Shoot) {
			TimerShoot -= Time.deltaTime ;
			P1_Timer.text = "T I M E R : " + Mathf.Round (TimerShoot) ;
			if (TimerShoot <= 0f) {
				TheGameState = GameState.P2StandBy ;
				TimerShoot = 5f ;
				P1_Timer.text = "T I M E R : 5" ;
			}
		}
		if (TheGameState == GameState.P2Shoot) {
			TimerShoot -= Time.deltaTime ;
			P2_Timer.text = "T I M E R : " + Mathf.Round (TimerShoot) ;
			if (TimerShoot <= 0f) {
				TheGameState = GameState.P1StandBy ; 
				TimerShoot = 5f ;
				P2_Timer.text = "T I M E R : 5" ;
			}
		}
		if (TheGameState == GameState.P1Move) {
			TimerMove -= Time.deltaTime ;
			P1_Timer.text = "T I M E R : " + Mathf.Round (TimerMove) ;
			if (TimerMove <= 0f) {
				TheGameState = GameState.P2StandBy ; 
				TimerMove = 5f ;
				P1_Timer.text = "T I M E R : 5";
			}
		}
		if (TheGameState == GameState.P2Move) {
			TimerMove -= Time.deltaTime ;
			P2_Timer.text = "T I M E R : "+ Mathf.Round (TimerMove) ;
			if (TimerMove <= 0f) {
				TheGameState = GameState.P1StandBy ; 
				TimerMove = 5f ;
				P2_Timer.text = "T I M E R : 5" ;
			}
		}
		if (TheGameState == GameState.P1StandBy) {
			TCtrlTxt.SetActive (true) ;
			P1_Ttxt.SetActive (true) ;
		}
		if (TheGameState == GameState.P2StandBy) {
			TCtrlTxt.SetActive (true) ;
			P2_Ttxt.SetActive (true) ;
		}
		if (Input.GetKey (Esc)) {
			SceneManager.LoadScene (0) ;
		}
	}
}
