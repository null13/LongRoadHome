using UnityEngine;
using System.Collections;

public class TriggerS : MonoBehaviour {

	//add bools for each enemy/obstacle type

	public GameObject		Hazard;

	void Start () {
	
	}
	
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D coll){
		if (coll.gameObject.tag == "Player") {
			print ("hit");
			this.transform.position = new Vector2(0,100);
			//locate enemy script, start attack function

			DropEnemyS de = Hazard.GetComponent<DropEnemyS>();
			iTweenEvent.GetEvent(Hazard, "shake").Play();
			de.StartCoroutine("start");
		}
	}
}
