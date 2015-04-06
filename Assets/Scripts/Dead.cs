using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Dead : MonoBehaviour {


	public Transform playerPrefab;

	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		string textBuffer = "";
		
		if (playerPrefab.GetComponent<Health>().health < 0f){
			textBuffer += "You're dead.\n";
			textBuffer += "Try Again? [R]";
		}


		GetComponent<Text>().text = textBuffer;
	}
}
