using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour {
	public GameObject player;

	PlayerHealth playerHealth;

	void Awake () {
		playerHealth = player.GetComponent <PlayerHealth> ();
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject == player) {
			playerHealth.invinsible = true;
			Destroy (this.gameObject);
		}
	}
}
