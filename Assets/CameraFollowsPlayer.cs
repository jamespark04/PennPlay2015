using UnityEngine;
using System.Collections;

public class CameraFollowsPlayer : MonoBehaviour {

	public Transform player;
	private Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = transform.position - player.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 newPosition = player.position + offset;
		transform.position = Vector3.Lerp (transform.position, newPosition, 5f * Time.deltaTime);
	}
}
