using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement ;

public class GameCtrl : MonoBehaviour {
	public GameObject [] Obstacles ;
	public int Count = 0 ;
	public int SelectRand ; 
	public int Score = 0 ;
	public Text ScoreTxt ;
	public Text final ;
	public Text Instr ;
	public Text Instr2 ;
	public int countlimit = 80 ;  
	public bool PlayerDead = false ;
	public float timeslow = 1f ;
	public int CountRe = 0 ;
	public KeyCode Exit = KeyCode.Escape ;
	public KeyCode StartButt = KeyCode.Space ;
	public GameObject Guide ;

	void Awake () {
		Time.timeScale = 1f ;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (CountRe >= 30) {
			SceneManager.LoadScene (1);
		}
		if (Input.GetKeyDown(Exit)) {
			SceneManager.LoadScene (0) ;
		}
		if (Input.GetKeyDown(StartButt)) {
			SceneManager.LoadScene (1) ;
		}
	}
	void FixedUpdate () {// counts to number then spawns obstacle then resets count and decreases up till were it will count
		Count = Count + 1 ;
		if (Count == countlimit) {
			SelectRand = Random.Range (0, 9);
			Instantiate (Obstacles [SelectRand], Obstacles[SelectRand].transform.position, Quaternion.identity) ;
			Instantiate (Guide, Guide.transform.position, Quaternion.identity);
			Count = 0 ;
			countlimit = countlimit - 2 ;
			if (countlimit <= 5) {
				countlimit = 60 ;
			}
		}
		ScoreTxt.text = "" + Score ;
		if (PlayerDead == true){
			Time.timeScale = timeslow ;
			CountRe = CountRe + 1 ;
			final.text = "Final Score: " + Score ;
			ScoreTxt.text = "You Lose" ;
			Instr.text = "Press Escape to Return To Menu" ; 
			Instr2.text = "Press Space to restart immediately" ;
			if (Time.timeScale > 0.05f) {
				timeslow = timeslow - 0.05f ;
			}
			if (Time.timeScale <= 0.05f) {
				Time.timeScale = 0f ;
			}
		}
	}
}
