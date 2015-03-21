using UnityEngine;
using System.Collections;

public class DropEnemyS : MonoBehaviour {

	//can add other things here, like homing the player a bit, etc

	public float		dropSpeed;
	public bool			activate = false;


	void FixedUpdate () {
		//have it wiggle for a second, then fall
		if (activate) { 
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -dropSpeed);
			dropSpeed += .21f;
		}
	}

	void OnTriggerEnter2D (Collider2D coll){
		if (coll.gameObject.tag == "killZ")
			Destroy (gameObject);
	}

	IEnumerator start(){
		yield return new WaitForSeconds (.5f);
		activate = true;
	}
}
