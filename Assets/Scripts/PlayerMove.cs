using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	Vector3 destination = new Vector3 (0,0,0);
	Vector3 moveDirection = new Vector3 (0,0,0);
	public bool move = false;

	public float speed = 10f;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	if (Input.GetMouseButtonDown(0)){
		move = true;
		Ray mouseRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit mouseRayInfo = new RaycastHit ();

		if (Physics.Raycast (mouseRay, out mouseRayInfo, 1000f)){

			// Debug.Log (mouseRayInfo.collider.name);

				destination = (mouseRayInfo.point);
				


		}

	}
		moveDirection = destination-transform.position;
			
		moveDirection = moveDirection.normalized;
		GetComponent<Rigidbody>().AddForce(moveDirection*speed);

	

		// GetComponent<Rigidbody>().AddForce(moveDirection*50f);

	}
}
