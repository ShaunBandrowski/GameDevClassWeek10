﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPCCommand : MonoBehaviour {

	public NPCRaycast npcPrefab; // assign in inpector

	public List<NPCRaycast> allMyNpcs = new List<NPCRaycast> ();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		// first find out where player is clicking

		// take player's mouse cursor position, and porject out from camera's facing 
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		// if we want forensics info about where the raycast hit, we need a blank variable
		RaycastHit rayHit = new RaycastHit();

		if (Physics.Raycast ( ray, out rayHit, 1000f)){

			if (Input.GetMouseButtonDown (1) && rayHit.collider.tag != "Player"){

				NPCRaycast newNPC = Instantiate (npcPrefab, rayHit.point + rayHit.normal, Quaternion.identity) as NPCRaycast;
				allMyNpcs.Add(newNPC);

			}

		}

		if (Input.GetKeyDown(KeyCode.R)){

			foreach (var thisNPC in allMyNpcs){

				thisNPC.speed *= 2f;

			}

		}
	
	}
}
