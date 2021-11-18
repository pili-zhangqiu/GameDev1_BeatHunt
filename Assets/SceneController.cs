using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    void Update()
    {
        int myPlayerHealth = PlayerController.playerHealth;
        float myTime = CountdownTimer.currentTime;
        Debug.Log("--------> Time: " + myTime);

        if (myPlayerHealth == 0)
        {
            Debug.Log("--------> You lost! :(");
            SceneManager.LoadScene("GameOver");
        }

        if (myTime <= 0f)
        {
            Debug.Log("--------> You won! :)");
            SceneManager.LoadScene("Congrats");
        }

    }
}
