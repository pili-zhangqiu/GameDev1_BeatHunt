/* --------------------------------------------------------------------------------------------------------------
|	Author(s): Pilar Zhang Qiu for the BeatHunt Team
|   Last Modified: 11th November 2021
|
|   Player Controller code for the BeatHunt Game
|   Version 1.0: Cube movement control
|
|   References: 
|       Cube Roll Movement from Oimo, URL: https://b13.app/unity/unity-script-for-roll-a-rectangular-parallelpiped-jp/
| -----------------------------------------------------------------------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float rotationPeriod = 0.3f;     // Time it takes to move
	Vector3 scale;                          // The size of the cube or parallelepiped

	bool isRotate = false;                  // Flag to detect if the Cube is spinning
	float directionX = 0;                   // Rotation direction
	float directionZ = 0;                   // Rotation direction

	float startAngleRad = 0;                // Angle of the center of gravity before rotation in the horizontal plane happens
	Vector3 startPos;                       // Cube position before rotation
	float rotationTime = 0;                 // Elapsed time during rotation
	float radius = 1;                       // Semi-major axis of the center of gravity (temporarily 1)
	Quaternion fromRotation;                // Cube quaternion before rotation
	Quaternion toRotation;                  // Cube quaternion after rotation or desired rotation

	private float beatPositionNow;
	private float beatRemainder;

	private float beatThresholdDown;
	private float beatThresholdUp;


	// Use this for initialization
	void Start()
	{

		// Get the size of a cube or parallelepiped
		scale = transform.lossyScale;
		//Debug.Log ("[x, y, z] = [" + scale.x + ", " + scale.y + ", " + scale.z + "]");

		// Init beats
		beatThresholdDown = 0.05f;
		beatThresholdUp = 1 - beatThresholdDown;
	}

	// Update is called once per frame
	void Update()
	{
		// -------------------------------------------------------- Beats
		// Get current beat position
		beatPositionNow = ConductorController.songPositionInBeats;
		beatRemainder = beatPositionNow % 1;
		Debug.Log("Current beat: " + beatPositionNow);
		Debug.Log("Beat remainder: " + beatRemainder);

		// ------------------------------------------------------- Movement 
		float tryX = 0;
		float tryY = 0; 
		
		float x = 0;
		float y = 0;

		// Identify keyboard keys pressed
		tryX = Input.GetAxisRaw("Horizontal");

		if ((tryX != 0 && beatRemainder <= beatThresholdDown) || (tryX != 0 && beatRemainder >= beatThresholdUp))
		{
			x = tryX;
			Debug.Log("x " + x);
			Debug.Log("-------------------------------- Beat Scored --------------------------------");
		}

		else if (tryX != 0 && beatRemainder > beatThresholdDown && beatRemainder < beatThresholdUp)
		{
			Debug.Log("-------------------------------- Missed a beat --------------------------------");
		}

		if (tryX == 0)
		{
			tryY = Input.GetAxisRaw("Vertical");

			if ((tryY != 0 && beatRemainder <= beatThresholdDown) || (tryX != 0 && beatRemainder >= beatThresholdUp))
			{
				y = tryY;
				Debug.Log("y " + y);
				Debug.Log("-------------------------------- Beat Scored --------------------------------");
			}

			else if (tryY != 0 && beatRemainder > beatThresholdDown && beatRemainder < beatThresholdUp)
            {
				Debug.Log("-------------------------------- Missed a beat --------------------------------");
			}
		}


		// If there is a key input and the Cube is not rotating, rotate the Cube
		if ((x != 0 || y != 0) && !isRotate)
		{
			directionX = y;                                                             // Rotation direction set (either x or y is always 0)
			directionZ = x;                                                             
			startPos = transform.position;                                              // Keep the coordinates before rotation
			fromRotation = transform.rotation;                                          // Keep the quaternion before rotation
			transform.Rotate(directionZ * 90, 0, directionX * 90, Space.World);         // Rotate 90 degrees in the direction of rotation
			toRotation = transform.rotation;                                            // Hold the rotated quaternion
			transform.rotation = fromRotation;                                          // Return the Cube Rotation to before rotation
			setRadius();                                                                // Calculate the radius of rotation
			rotationTime = 0;                                                           // Set the elapsed time during rotation to 0
			isRotate = true;                                                            // Set the rotating flag
		}
	}

	void FixedUpdate()
	{

		if (isRotate)
		{

			rotationTime += Time.fixedDeltaTime;                                    // Increase elapsed time
			float ratio = Mathf.Lerp(0, 1, rotationTime / rotationPeriod);          // The ratio of the current elapsed time to the rotation time

			// Move
			float thetaRad = Mathf.Lerp(0, Mathf.PI / 2f, ratio);                   // Rotation angle in radians
			float distanceX = -directionX * radius * (Mathf.Cos(startAngleRad) - Mathf.Cos(startAngleRad + thetaRad));      // X-axis travel distance. The minus sign (-) is to match the direction of movement with the key.
			float distanceY = radius * (Mathf.Sin(startAngleRad + thetaRad) - Mathf.Sin(startAngleRad));                        // Y-axis travel distance
			float distanceZ = directionZ * radius * (Mathf.Cos(startAngleRad) - Mathf.Cos(startAngleRad + thetaRad));           // Z-axis travel distance
			transform.position = new Vector3(startPos.x + distanceX, startPos.y + distanceY, startPos.z + distanceZ);           // Set current position

			// Rotate
			transform.rotation = Quaternion.Lerp(fromRotation, toRotation, ratio);      // Set the current angle of rotation with Quaternion.Lerp

			// Initialize each parameter at the end of movement / rotation.Lower the isRotate flag
			if (ratio == 1)
			{
				isRotate = false;
				directionX = 0;
				directionZ = 0;
				rotationTime = 0;
			}
		}
	}

	void setRadius()
	{

		Vector3 dirVec = new Vector3(0, 0, 0);          // Movement direction vector
		Vector3 nomVec = Vector3.up;                    // (0,1,0)

		// Convert movement direction to vector
		if (directionX != 0)
		{                           
			// Move in the X direction
			dirVec = Vector3.right;                     // (1,0,0)
		}
		else if (directionZ != 0)
		{                   
			// Move in the Z direction
			dirVec = Vector3.forward;                   // (0,0,1)
		}

		// Calculate the radius and startAngle of the movement direction from the inner product of the movement direction vector and the direction of the Object.
		if (Mathf.Abs(Vector3.Dot(transform.right, dirVec)) > 0.99)
		{                       
			// The movement direction is the x direction of object
			if (Mathf.Abs(Vector3.Dot(transform.up, nomVec)) > 0.99)
			{
				// The y-axis of global is the y-direction of object
				radius = Mathf.Sqrt(Mathf.Pow(scale.x / 2f, 2f) + Mathf.Pow(scale.y / 2f, 2f)); // Radius of rotation
				startAngleRad = Mathf.Atan2(scale.y, scale.x);									// Angle of the center of gravity before rotation from the horizontal plane
			}
			else if (Mathf.Abs(Vector3.Dot(transform.forward, nomVec)) > 0.99)
			{       
				// The y-axis of global is the z-direction of object
				radius = Mathf.Sqrt(Mathf.Pow(scale.x / 2f, 2f) + Mathf.Pow(scale.z / 2f, 2f));
				startAngleRad = Mathf.Atan2(scale.z, scale.x);
			}

		}
		else if (Mathf.Abs(Vector3.Dot(transform.up, dirVec)) > 0.99)
		{                   
			// The movement direction is the y direction of object
			if (Mathf.Abs(Vector3.Dot(transform.right, nomVec)) > 0.99)
			{
				// The y-axis of global is the x-direction of the object
				radius = Mathf.Sqrt(Mathf.Pow(scale.y / 2f, 2f) + Mathf.Pow(scale.x / 2f, 2f));
				startAngleRad = Mathf.Atan2(scale.x, scale.y);
			}
			else if (Mathf.Abs(Vector3.Dot(transform.forward, nomVec)) > 0.99)
			{       
				// The y-axis of global is the z-direction of object
				radius = Mathf.Sqrt(Mathf.Pow(scale.y / 2f, 2f) + Mathf.Pow(scale.z / 2f, 2f));
				startAngleRad = Mathf.Atan2(scale.z, scale.y);
			}
		}
		else if (Mathf.Abs(Vector3.Dot(transform.forward, dirVec)) > 0.99)
		{           
			// The movement direction is the z direction of object
			if (Mathf.Abs(Vector3.Dot(transform.right, nomVec)) > 0.99)
			{                   
				// The y-axis of global is the x-direction of the object
				radius = Mathf.Sqrt(Mathf.Pow(scale.z / 2f, 2f) + Mathf.Pow(scale.x / 2f, 2f));
				startAngleRad = Mathf.Atan2(scale.x, scale.z);
			}
			else if (Mathf.Abs(Vector3.Dot(transform.up, nomVec)) > 0.99)
			{               
				// The y-axis of global is the y-direction of object
				radius = Mathf.Sqrt(Mathf.Pow(scale.z / 2f, 2f) + Mathf.Pow(scale.y / 2f, 2f));
				startAngleRad = Mathf.Atan2(scale.y, scale.z);
			}
		}
	}
}
