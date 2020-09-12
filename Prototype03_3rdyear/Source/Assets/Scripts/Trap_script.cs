using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI ;

public class Trap_script : MonoBehaviour {
	//public NavMeshAgent OtherNav;
	//public bool TrapActive = false ;
	//public int count; 
	//public GameObject Player ;
	// Use this for initialization
	void Start () {
		//Player = GameObject.Find ("Player") ;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//if (TrapActive == true) {
			//count++ ; 
		//}
		//if (count <= 100 && TrapActive == true) {
			//OtherNav.speed = 2f ;
		//}
		//if (count > 100 && TrapActive == true) {
			//TrapActive = false ;
			//count = 0 ;
			//OtherNav.speed = 5f ;
		//}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			//if (this.tag == "TType1") {
			   //other.GetComponent<Player_Ctrl> ().Health = other.GetComponent<Player_Ctrl> ().Health - 25 ;
			 //OtherNav = Player.GetComponent<NavMeshAgent> () ;
			  other.GetComponent<Player_Ctrl> ().TrapActive = true ;
			}
			 //TrapActive = true ;
			//if (this.tag == "TType2") {
				//other.GetComponent<Rigidbody> ().AddExplosionForce (1000f, this.transform.position, 4f, 3.0F) ;
			//}
		if (other.tag == "Enemy") {
			other.GetComponent<Enemy_Ctrl> ().TrapActive = true ;
		   }
		}
	}

