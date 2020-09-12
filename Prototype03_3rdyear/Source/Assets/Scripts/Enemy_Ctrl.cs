using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI ;

public class Enemy_Ctrl : MonoBehaviour {
	public GameObject Player ;
	public bool TrapActive = false ;
	public int TrapCount = 0 ;
	public int GrowlCooldwon = 300 ;
	public bool HasGrowled = false ;
	public Animator EnemyAnim ; 
	public AudioSource WGnarl ;
	public AudioSource WGrowl ;
	public GameObject GrowlObj ;

	private NavMeshAgent EnemyNav ;
	// Use this for initialization
	void Start () {
		EnemyNav = this.GetComponent<NavMeshAgent> () ;
		Player = GameObject.Find ("Player") ;
		EnemyAnim = GetComponentInChildren<Animator> () ;
		GrowlObj = GameObject.Find ("WolfGrowlObj") ;
		WGrowl = GrowlObj.GetComponent <AudioSource> () ;
		WGnarl = GetComponent<AudioSource> () ;
		EnemyAnim.SetBool ("isRunning",true) ;
		EnemyAnim.SetBool ("isWalking",false) ;
		EnemyNav.destination = Player.transform.position ;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () {
		EnemyNav.destination = Player.transform.position ;

		if (TrapActive == true) {
			TrapCount++ ; 
		}
		if (TrapCount <= 200 && TrapActive == true) {
			EnemyNav.speed = 2f ;
		}
		if (TrapCount > 200 && TrapActive == true) {
			TrapActive = false ;
			TrapCount = 0 ;
			EnemyNav.speed = 5f ;
			EnemyAnim.SetBool ("isRunning",true) ;
			EnemyAnim.SetBool ("isWalking",false) ;
		}

		if (EnemyNav.speed == 2f) {
			EnemyAnim.SetBool ("isRunning",false) ; 
			EnemyAnim.SetBool ("isWalking",true) ; 
		}

		if (EnemyNav.remainingDistance <= 0.3f && GrowlCooldwon >= 300) {
			WGrowl.Play () ;
			GrowlCooldwon = 0 ;
			HasGrowled = true ;
		}

		if (HasGrowled == true) {
			GrowlCooldwon++ ;
		}

		if (GrowlCooldwon >= 300) {
			HasGrowled = false ;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			other.GetComponent<Player_Ctrl> ().Health = other.GetComponent<Player_Ctrl> ().Health - 25 ;
			WGnarl.Play () ;
		}
	}
}
