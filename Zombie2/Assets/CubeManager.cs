using UnityEngine;
using System.Collections;

public class CubeManager : MonoBehaviour {
	public GameObject[] cube;
	private float spawnTime = 10f;
	public Transform[] spawnPoints; 

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}
	
	// Update is called once per frame
	void Spawn () {
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);
		int cubeIndex = Random.Range (0, cube.Length);
		Instantiate (cube[cubeIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}
}
