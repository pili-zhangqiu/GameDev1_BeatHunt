using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    Image fullHealth1;

    [SerializeField]
    Image fullHealth2;

    [SerializeField]
    Image fullHealth3;

    [SerializeField]
    Image emptyHealth1;

    [SerializeField]
    Image emptyHealth2;

    [SerializeField]
    Image emptyHealth3;

    private Color fullColor;
    private Color transColor;


    void Start()
    {
        fullColor = fullHealth1.color;

        transColor = fullColor;
        transColor.a = 0f;
    }

    void FixedUpdate()
    {
        float playerHealth = PlayerController.playerHealth;

        if (playerHealth >= 3)
        {
            // Full hearts (all active)
            fullHealth1.color = fullColor;
            fullHealth2.color = fullColor;
            fullHealth3.color = fullColor;

            // Empty hearts (all transparent)
            emptyHealth1.color = transColor;
            emptyHealth2.color = transColor;
            emptyHealth3.color = transColor;
        }

        if (playerHealth == 2)
        {
            // Full hearts (number 3 transparent)
            fullHealth1.color = fullColor;
            fullHealth2.color = fullColor;
            fullHealth3.color = transColor;

            // Empty hearts (number 3 active)
            emptyHealth1.color = transColor;
            emptyHealth2.color = transColor;
            emptyHealth3.color = fullColor;
        }

        if (playerHealth == 1)
        {
            // Full hearts (number 3 & 2 transparent)
            fullHealth1.color = fullColor;
            fullHealth2.color = transColor;
            fullHealth3.color = transColor;

            // Empty hearts (number 3 & 2 active)
            emptyHealth1.color = transColor;
            emptyHealth2.color = fullColor;
            emptyHealth3.color = fullColor;
        }

        if (playerHealth <= 0)
        {
            // Full hearts (all transparent)
            fullHealth1.color = transColor;
            fullHealth2.color = transColor;
            fullHealth3.color = transColor;

            // Empty hearts (all active)
            emptyHealth1.color = fullColor;
            emptyHealth2.color = fullColor;
            emptyHealth3.color = fullColor;
        }
    }
}
