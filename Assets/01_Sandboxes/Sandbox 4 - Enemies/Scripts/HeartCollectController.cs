using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCollectController : MonoBehaviour
{
	public AudioSource oneUpAudio;

	void Start()
	{
		// Ray GameObject and warning out of scene
		Vector3 startHeartPos = new Vector3(Random.Range(-16.5f, 16.5f), 0, Random.Range(-14f, 14f));
		gameObject.transform.position = startHeartPos;
	}

	void OnTriggerEnter(Collider collision)
	{
		// -------------- Hit by log --------------
		if (collision.gameObject.name == "Player")
		{
			PlayerController.heartCollected = true;
			oneUpAudio.Play();
			Debug.Log("---------- One life collected! ----------");

			// Find new place to move
			Vector3 nextHeartPos = new Vector3(Random.Range(-16.5f, 16.5f), 0, Random.Range(-14f, 14f));
			gameObject.transform.position = nextHeartPos;
		}
	}
}
