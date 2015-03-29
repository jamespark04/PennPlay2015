using UnityEngine;
using System.Collections;

public class HealthCubeController : MonoBehaviour {
	public GameObject player;
	
	PlayerHealth playerHealth;
	
	void Awake () {
		playerHealth = player.GetComponent <PlayerHealth> ();
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject == player) {
			playerHealth.currentHealth += 50;
			if (playerHealth.currentHealth > 100) {
				playerHealth.currentHealth = 100;
			}
			playerHealth.healthSlider.value = playerHealth.currentHealth;
			Destroy (this.gameObject);
		}
	}
}
