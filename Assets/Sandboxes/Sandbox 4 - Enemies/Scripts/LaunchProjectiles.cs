using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchProjectiles : MonoBehaviour
{

	[SerializeField]
	int numberOfProjectiles;

	[SerializeField]
	GameObject projectile;

	Vector3 startPoint;

	float radius, moveSpeed;
	public bool fireBall = true;

	// Use this for initialization
	void Start()
	{
		radius = 0.2f;
		moveSpeed = 1f;
	}

	// Update is called once per frame
	void Update()
	{
		/*if (Input.GetButtonDown("Fire1"))
		{
			startPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			SpawnProjectiles(numberOfProjectiles);
		}*/

		if (fireBall== true)
        {
			startPoint = new Vector3(0, 2.5f, 0);
			SpawnProjectiles(numberOfProjectiles);
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
			float projectileDirYposition = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;
			float projectileDirZposition = startPoint.z;

			Vector3 projectileVector = new Vector3(projectileDirXposition, 2.5f, projectileDirYposition);
			Vector3 projectileMoveDirection = (projectileVector - startPoint).normalized * moveSpeed;

			var proj = Instantiate(projectile, startPoint, Quaternion.identity);
			proj.GetComponent<Rigidbody>().velocity =
				new Vector3(projectileMoveDirection.x, projectileMoveDirection.y, projectileMoveDirection.z);

			angle += angleStep;
		}
	}

}