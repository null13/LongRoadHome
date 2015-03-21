using UnityEngine;
using System.Collections;

public class CameraS : MonoBehaviour {

	public float			lockZ;
	public float			lockY;

	public GameObject		player;


	void Update () {
		transform.position = new Vector3(player.transform.position.x, lockY, lockZ);
	}
}



