using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;

public class P1_HealthBar : MonoBehaviour {
	private Image HealthBarFill ;
	private float MaxHealth = 100f ;
	public float P1_Health ;
	// Use this for initialization
	void Start () {
		HealthBarFill = GetComponent<Image> ();
		P1_Health = MaxHealth ;
	}
	
	// Update is called once per frame
	void Update () {
		HealthBarFill.fillAmount = P1_Health / MaxHealth ;
	}
}
