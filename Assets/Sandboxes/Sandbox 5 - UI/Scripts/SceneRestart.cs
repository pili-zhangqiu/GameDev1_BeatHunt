using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRestart : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            LoadCurrentScene();
        }
    }

    public void LoadCurrentScene()
    {
        Debug.Log("Hello I am the reloaded scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
