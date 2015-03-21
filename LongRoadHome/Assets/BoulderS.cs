using UnityEngine;
using System.Collections;

public class BoulderS : MonoBehaviour {

	public float			speed;

	public int				currentNode = 0;
	public int				totalNodes;

	private Vector3			currentPos;
	private Vector3			targetPos;

	public GameObject[]		nodes;
	

	void Update () {
		if(currentNode == totalNodes)
			Destroy(gameObject);

		currentPos = this.transform.position;

		if (Vector3.Distance (currentPos, targetPos) > .1f) {
			Vector3 directionOfTravel = targetPos - currentPos;
			directionOfTravel.Normalize ();

			switch (currentNode) {
			case(0):
				targetPos = nodes [0].transform.position;
				break;
			case(1):
				targetPos = nodes [1].transform.position;
				break;
			case(2):
				targetPos = nodes [2].transform.position;
				break;
			case(3):
				targetPos = nodes [3].transform.position;
				break;
			}

			this.transform.Translate(
				(directionOfTravel.x * speed * Time.deltaTime),
				(directionOfTravel.y * speed * Time.deltaTime),
				(directionOfTravel.z * 0),
				Space.World);
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "node") {
			print ("hitNode");
			currentNode += 1;
		}
	}
}



