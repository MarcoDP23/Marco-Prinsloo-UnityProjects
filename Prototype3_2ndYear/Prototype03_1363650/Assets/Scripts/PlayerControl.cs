using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI ;

public class PlayerControl : MonoBehaviour {
	private NavMeshAgent nav ;
	public GameObject Particle ;
	public GameObject DP ;
	public GameObject GC ;
	public bool Fail = false ;
	public GameObject Menutext ;
	public GameObject CreditText ;
	public bool Pass = false ;

	void Awake () {
		GC = GameObject.Find ("GameCtrl") ;
	}
	// Use this for initialization
	void Start () {
		nav = this.GetComponent<NavMeshAgent> () ;
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition) ; //creates a ray from the mouses position
		RaycastHit MClick ; // allows info to gathered from ray
		if (Input.GetMouseButtonDown (0)) { // when the left mouse button is clicked
			if (Physics.Raycast (ray, out MClick, 100)) { //casts the ray 100 units and checks where the ray is colliding
				Menutext.SetActive (false) ;
				CreditText.SetActive (false) ;
				Instantiate (Particle, MClick.point, Quaternion.identity); //instantiates the particle effect
				nav.destination = MClick.point ; //set the point to which the player must move as the point where the ray touches the nav mesh
			}
		}
		Fail = GC.GetComponent<GameCtrl> ().Failed ;
		if (Fail == true) {
			Instantiate (DP, this.transform.position, Quaternion.identity);
			this.transform.DetachChildren () ;
			Destroy (gameObject) ;
		}
		Pass = GC.GetComponent<GameCtrl> ().AllShrineActv ;
		if (Pass == true) {
			//this.transform.Translate (new Vector3(0f, 0.5f)) ;
		}
	}
}
