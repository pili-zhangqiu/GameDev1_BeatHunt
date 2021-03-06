using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    float startingTime = 120f;
    public static float currentTime = 0.1f;


    [SerializeField] Text countdownText;

    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString ("0");

        if (currentTime <= 0) {
            currentTime = 0; }
     }
}
        
