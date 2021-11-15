using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TilesLitController : MonoBehaviour
{
    public Image magImage;
    public Image cyanImage;

    public static float magAlpha;
    public static float cyanAlpha;

    void Start()
    {
        magImage = GetComponent<Image>();
        cyanImage = GetComponent<Image>();

        var magColor = magImage.color;
        var cyanColor = cyanImage.color;

        // Set them transparent at the beggining
        magColor.a = 0f;
        cyanColor.a = 0f;

        magImage.color = magColor;
        cyanImage.color = cyanColor;
    }

    void FixedUpdate()
    {
        magImage = GetComponent<Image>();
        cyanImage = GetComponent<Image>();

        var magColor = magImage.color;
        var cyanColor = cyanImage.color;

        // Set the transparency
        magColor.a = magAlpha;
        cyanColor.a = cyanAlpha;

        magImage.color = magColor;
        cyanImage.color = cyanColor;
    }
}
