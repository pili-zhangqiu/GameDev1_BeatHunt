using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CyanTilesController : MonoBehaviour
{
    public Image cyanImage;
    public static float cyanAlpha;


    void Start()
    {
        cyanImage = GetComponent<Image>();

        var cyanColor = cyanImage.color;

        // Set them transparent at the beggining
        cyanColor.a = 0f;

        cyanImage.color = cyanColor;
    }

    void FixedUpdate()
    {
        cyanImage = GetComponent<Image>();

        var cyanColor = cyanImage.color;

        // Set the transparency
        cyanColor.a = cyanAlpha;

        cyanImage.color = cyanColor;
    }
}
