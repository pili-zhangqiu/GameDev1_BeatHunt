using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //[SerializeField]
    public Transform target;
    //public GameObject player;

    [SerializeField]
    private Vector3 offsetPosition;

    [SerializeField]
    private Space offsetPositionSpace = Space.Self;

    [SerializeField]
    private bool lookAt = true;

    // In start void define the target for the camera follower
    private void Start()
    {
        //player = GameObject.Find("Player");
        //target = player.transform;
        gameObject.transform.Rotate(0, 0, 270);
    }

    private void Update()
    {
        Refresh();
    }

    public void Refresh()
    {
        if (target == null)
        {
            Debug.Log("Missing target reference for camera!");
            return;
        }

        // compute position
        if (offsetPositionSpace == Space.Self)
        {
            transform.position = target.TransformPoint(offsetPosition);
        }
        else
        {
            transform.position = target.position + offsetPosition;
        }

        // compute rotation

        if (lookAt)
        {
            //transform.LookAt(target);
        }

        else
        {
            transform.rotation = target.rotation;
            //transform.position = new Vector3(0, 270, 0);
        }
    }
}