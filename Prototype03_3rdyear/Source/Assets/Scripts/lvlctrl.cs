using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvlctrl : MonoBehaviour {
	public GameObject[] HouseSpawn ;
	public GameObject[] KeySpawn ;
	public GameObject Key ;
	public int selectRandom ;
	public int selectRandomKeyS ;
	// Use this for initialization
	void Awake () {
		//selectRandom = Random.Range (0, 4); 
		//Instantiate (HouseSpawn [selectRandom], HouseSpawn[selectRandom].transform.position, HouseSpawn[selectRandom].transform.rotation) ;
	}
	void Start () {
		selectRandom = Random.Range (0, 8); 
		selectRandomKeyS = Random.Range (0, 8);
		Instantiate (HouseSpawn [selectRandom], HouseSpawn[selectRandom].transform.position, HouseSpawn[selectRandom].transform.rotation) ;
		Instantiate (Key, KeySpawn[selectRandomKeyS].transform.position, Quaternion.identity) ;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
