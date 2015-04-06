using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExitWin : MonoBehaviour {

	public Transform playerPrefab;
	public Transform exit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		string textBuffer = "";

		if (playerPrefab.GetComponent<PlayerMove>().move == false){
			textBuffer += "You're trapped in this maze, find the exit.\n\n";
			textBuffer += "Avoid the enemies. You can stab them from either the back or the sides.\n\n";
			textBuffer += "Click to where you want to move.";

		}

		if (Vector3.Distance(exit.GetComponent<Collider>().transform.position, playerPrefab.GetComponent<Rigidbody>().transform.position) < 50f){

			textBuffer += "You Win!\n\n\n\n";
			textBuffer += "Press [R] to play again.";

		}



		GetComponent<Text>().text = textBuffer;

		
	}
	



}
