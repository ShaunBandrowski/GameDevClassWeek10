using UnityEngine;
using System.Collections;
using System.Collections.Generic; // You need this line to use Lists

// ObstaclePlacer places walls, remembers the walls it places, 
// and if the player presses [K] then all walls are deleted
public class ObstaclePlacer : MonoBehaviour {

	public Transform obstaclePrefab; // asiign in Inspector

	List<Transform> obstacleClones = new List<Transform> ();

	// Update is called once per frame
	void Update () {

		// generate a ray before shooting a raycast
		Ray cursorRay = Camera.main.ScreenPointToRay (Input.mousePosition);

		// reserve in memory a "blank" object to hold impact data
		RaycastHit cursorRayInfo = new RaycastHit ();

		if (Physics.Raycast (cursorRay, out cursorRayInfo, 1000f) ){

			Debug.Log (cursorRayInfo.collider.name);

			if (Input.GetMouseButtonDown (0) ){

				Transform newClone = (Transform)Instantiate (obstaclePrefab, cursorRayInfo.point, Random.rotation);
				obstacleClones.Add(newClone);

			}

		}

		// if the player presses [K], rotate all walls by 90 degrees
		if (Input.GetKey(KeyCode.K)){

			foreach (Transform clone in obstacleClones){

				clone.Rotate(0f,90f,0f, Space.World);

			}

		}
	
	}
}
