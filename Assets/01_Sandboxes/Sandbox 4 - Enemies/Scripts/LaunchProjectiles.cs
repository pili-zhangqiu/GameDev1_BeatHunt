using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchProjectiles : MonoBehaviour
{

	[SerializeField]
	int numberOfProjectiles;

	[SerializeField]
	GameObject player;

	[SerializeField]
	GameObject projectile;

	[SerializeField]
	float moveSpeed;

	Vector3 startPoint;
	int intStartBeat;
	int intCurrBeat;

	float radius;
	public bool fireBall = true;

	public static List<GameObject> allTheProjectiles = new List<GameObject>();

	private Vector3 offsetFromPlayer;

	public AudioSource explosion;


	// Use this for initialization
	void Start()
	{
		radius = 0.7f;
		//moveSpeed = 1f;

		intStartBeat = Mathf.FloorToInt(ConductorController.songPositionInBeats);

		// Calculate where to instantiate projectile, random area close to player
		Vector3 playerPos = player.transform.position;

		float projOffsetX = Random.Range(-10.0f, 10.0f);
		while (projOffsetX > -3f & projOffsetX < 3f)
		{
			projOffsetX = Random.Range(-10.0f, 10.0f);
		}

		float projOffsetZ = Random.Range(-10.0f, 10.0f);
		while (projOffsetZ > -3f & projOffsetZ < 3f)
		{
			projOffsetX = Random.Range(-10.0f, 10.0f);
		}

		Vector3 offsetFromPlayer = new Vector3(projOffsetX, 0, projOffsetZ);

		projectile.transform.position = playerPos + offsetFromPlayer;
		
		startPoint = projectile.transform.position;
		Debug.Log("Fireball instantiated at: " + startPoint);
	}

	// Update is called once per frame
	void Update()
	{
		if (fireBall == true)
        {
			/*
			// Do not instantiate until 2 beats happen
			if (intCurrBeat == intStartBeat)
            {
				intCurrBeat = Mathf.FloorToInt(ConductorController.songPositionInBeats);

				//Get the Renderer component from main sphere/projectile
				var projRenderer = projectile.GetComponent<Renderer>();

				//Call SetColor using the shader property name "_Color" and setting the color to red
				projRenderer.material.SetColor("_Color", Color.yellow);
			}

			// Do not instantiate until 2 beats happen
			else if (intCurrBeat == (intStartBeat + 1))
			{
				intCurrBeat = Mathf.FloorToInt(ConductorController.songPositionInBeats);

				//Get the Renderer component from main sphere/projectile
				var projRenderer = projectile.GetComponent<Renderer>();

				//Call SetColor using the shader property name "_Color" and setting the color to red
				projRenderer.material.SetColor("_Color", Color.red);
			}
			*/

			intCurrBeat = Mathf.FloorToInt(ConductorController.songPositionInBeats);

			//Get the Renderer component from main sphere/projectile
			//var projRenderer = projectile.GetComponent<Renderer>();

			//Call SetColor using the shader property name "_Color" and setting the color to red
			//projRenderer.material.SetColor("_Color", Color.white);

			explosion.Play();
			SpawnProjectiles(numberOfProjectiles);
			fireBall = false;

		}

	}

	void SpawnProjectiles(int numberOfProjectiles)
	{
		float angleStep = 360f / numberOfProjectiles;
		float angle = 0f;

		for (int i = 0; i <= numberOfProjectiles - 1; i++)
		{

			float projectileDirXposition = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
			//float projectileDirYposition = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;
			float projectileDirYposition = startPoint.y;
			float projectileDirZposition = startPoint.z + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

			Vector3 projectileVector = new Vector3(projectileDirXposition, projectileDirYposition, projectileDirZposition);
			Vector3 projectileMoveDirection = (projectileVector - startPoint).normalized * moveSpeed;

			var proj = Instantiate(projectile, startPoint, Quaternion.identity);
			allTheProjectiles.Add(proj);
			Debug.Log(allTheProjectiles);

			proj.GetComponent<Rigidbody>().velocity =
				new Vector3(projectileMoveDirection.x, projectileMoveDirection.y, projectileMoveDirection.z);

			angle += angleStep;
		}
	}

}