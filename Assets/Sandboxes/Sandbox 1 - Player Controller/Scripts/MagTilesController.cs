using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MagTilesController : MonoBehaviour
{
    public Image magImage;

    public static float magAlpha;


    void Start()
    {
        magImage = GetComponent<Image>();

        var magColor = magImage.color;

        // Set them transparent at the beggining
        magColor.a = 0f;

        magImage.color = magColor;
    }

    void FixedUpdate()
    {
        magImage = GetComponent<Image>();

        var magColor = magImage.color;

        // Set the transparency
        magColor.a = magAlpha;

        magImage.color = magColor;
    }
}