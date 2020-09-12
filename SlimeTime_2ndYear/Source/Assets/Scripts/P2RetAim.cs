using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2RetAim : MonoBehaviour {
	private float angle = Mathf.PI / 2;
	public KeyCode RotateAntiClock = KeyCode.A ;
	public KeyCode RotateClock = KeyCode.D ;
	public float xPos ;
	public float yPos ;
	public Transform Player;
	public float xPosP ;
	public float yPosP ;
	public GameObject GameControl ;
	// Use this for initialization
	void Start () {
		GameControl = GameObject.Find ("GameController") ;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (RotateAntiClock) && GameControl.GetComponent<GameControl> ().TheGameState == global::GameControl.GameState.P2Shoot) {
			//Rotates the object AntiClockwise 
			angle = Mathf.Clamp(angle + (0.01f * Mathf.PI), 0, Mathf.PI) ;
			//Debug.Log (angle);

		} 
		else if (Input.GetKey (RotateClock) && GameControl.GetComponent<GameControl> ().TheGameState == global::GameControl.GameState.P2Shoot) {
			//Rotates the object Clockwise
			angle = Mathf.Clamp(angle - (0.01f * Mathf.PI), 0, Mathf.PI) ; 
			//Debug.Log (angle);
		}

		MovePointer () ; 
	}
	void MovePointer () {
		xPos = (Mathf.Cos (angle) * 1.0f) + Player.position.x ;
		yPos = (Mathf.Sin (angle) * 1.0f) + Player.position.y ;
		xPosP = (Mathf.Cos (angle) * 1.0f) ;
		yPosP = (Mathf.Sin (angle) * 1.0f) ;
		this.transform.position = new Vector2 (xPos, yPos) ;
	}
}
