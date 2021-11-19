using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour
{
    public static bool instructionsON = false;

    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("MainGame");
        }

        else if (Input.GetKey(KeyCode.I))
        {
            instructionsON = true;
            Debug.Log("Instruction Toggle ON");
        }

        else if (Input.GetKey(KeyCode.X))
        {
            instructionsON = false;
            Debug.Log("Instruction Toggle OFF");
        }
    }
}
