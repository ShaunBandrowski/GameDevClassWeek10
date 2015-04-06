using UnityEngine;
using System.Collections;

// Put this on a capsule with a Rigidbody
public class NPCRaycast : MonoBehaviour {

	public float speed = 0.5f;
	public float speedFound = 0.5f;

	public Transform playerPrefab;

	// Use this for initialization
	void Start () {
	
	}

	// FixedUpdate is called once per physics frame / fixed Timestamp

	void FixedUpdate () {

		GetComponent<Rigidbody>().AddForce (transform.forward * speed, ForceMode.VelocityChange);

		Ray ray = new Ray (transform.position, transform.forward);
		RaycastHit rayHit = new RaycastHit();

		if (Physics.Raycast(ray, out rayHit, 6f) && rayHit.collider.tag == "Player"){
			
			transform.position = Vector3.MoveTowards(transform.position, playerPrefab.GetComponent<Rigidbody>().position, speedFound);
			transform.renderer.material.color = Color.red;
			
		}
		else {
			
			GetComponent<Rigidbody>().AddForce (transform.forward * speed, ForceMode.VelocityChange);
			transform.renderer.material.color = Color.blue;

			if (Physics.Raycast (ray, 3f)) {
				
				transform.Rotate (0f,90f,0f);
				
			}
			
		}
	
	}


//	void Update () {
//		Ray lineOfSightRay = new Ray (playerPrefab.GetComponent<Rigidbody>().position,transform.position);
//
//		// RaycastHit enemyRayInfo = new RaycastHit ();
//
//		if (Physics.Raycast(lineOfSightRay, 5f)){
//
//			transform.position = Vector3.MoveTowards(transform.position, playerPrefab.GetComponent<Rigidbody>().position, speed);
//			transform.renderer.material.color = Color.red;
//
//		}
//		else {
//
//			GetComponent<Rigidbody>().AddForce (transform.forward * speed, ForceMode.VelocityChange);
//			transform.renderer.material.color = Color.blue;
//
//		}
//
////		If raycast between (player position) and (npc position) is FALSE...
//			then make NPC move toward player
//				Else
//				then make NPC move forward
//				if raycast from (npc position) to (1 unit in front of NPC) is TRUE...
//					then NPC should rotate 90 degrees
//		
//		bool isCloseEnough = Vector3.Distance(transform.position,playerPrefab.GetComponent<Rigidbody>().position) <  50f;
//		bool isInViewCone = Vector3.Angle(playerPrefab.GetComponent<Rigidbody>().position, transform.forward) < 50f;
//		bool isInLineOfSight = Physics.Raycast(lineOfSightRay, 50f);
//
//		if ( isCloseEnough && isInViewCone && isInLineOfSight ){
//
//			GetComponent<Rigidbody>().AddForce(transform.forward*speed, ForceMode.VelocityChange);
//			transform.renderer.material.color = Color.red;
//
//		}
//		else{
//
// 			transform.renderer.material.color = Color.blue;
//
////		}
//
//	}
	
}
