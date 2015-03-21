using UnityEngine;
using System.Collections;

public class PlayerS : MonoBehaviour {

	public int			movePhase;

	public float		speed1;
	public float		speed2;
	public float		speed3;
	public float		jumpHeight;

	public bool			grounded;

	public GameObject	respawnPoint;
	

	void Start () {
	
	}
	//SPEEDS ARE INCONSISTANT
	void Update () {
		if (Input.GetKeyDown (KeyCode.Q) ||
		    Input.GetKeyDown (KeyCode.W) ||
		    Input.GetKeyDown (KeyCode.E)){
			movePhase += 1;
		}

		if (Input.GetKeyUp (KeyCode.Q) ||
		    Input.GetKeyUp (KeyCode.W) ||
		    Input.GetKeyUp (KeyCode.E)){
			movePhase -= 1;
		}


		if(!Input.anyKey)
		   movePhase = 0;

		if (Input.GetMouseButtonDown (0)) {
			if(grounded)
				GetComponent<Rigidbody2D>().AddForce (transform.up * jumpHeight);
		}

	}

	void FixedUpdate(){

		switch (movePhase) {

		case 0:
			GetComponent<Rigidbody2D>().velocity = new Vector2 (0,GetComponent<Rigidbody2D>().velocity.y);
			break;
		case 1:
			GetComponent<Rigidbody2D>().velocity = new Vector2 (speed1, GetComponent<Rigidbody2D>().velocity.y);
			break;
		case 2:
			GetComponent<Rigidbody2D>().velocity = new Vector2 (speed2, GetComponent<Rigidbody2D>().velocity.y);
			break;
		case 3:
			GetComponent<Rigidbody2D>().velocity = new Vector2 (speed3, GetComponent<Rigidbody2D>().velocity.y);
			break;
		}
	}

	void OnCollisionStay2D(Collision2D coll){
		if (coll.gameObject.tag == "ground")
			grounded = true;
	}

	void OnCollisionExit2D(Collision2D coll){
		if (coll.gameObject.tag == "ground")
			grounded = false;
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "respawnNode")
			respawnPoint = coll.gameObject;

		if (coll.gameObject.tag == "killZ")
			StartCoroutine ("Respawn");
	}

	IEnumerator Respawn(){
		yield return new WaitForSeconds(2);
		this.transform.position = new Vector2 (respawnPoint.transform.position.x, respawnPoint.transform.position.y);
	}
}
