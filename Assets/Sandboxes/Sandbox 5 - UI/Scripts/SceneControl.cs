using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControl : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
