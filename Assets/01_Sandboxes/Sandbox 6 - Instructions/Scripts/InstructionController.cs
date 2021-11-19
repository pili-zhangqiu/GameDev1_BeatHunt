using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InstructionController : MonoBehaviour
{
    //public Image instructionImg;

    void Update()
    {
        bool imgON = TitleScreenController.instructionsON;

        if (imgON == true)
        {
            //Debug.Log("Moving instructions forward!");
            transform.position = new Vector3(0, 0, -1);
        }

        else
        {
            //Debug.Log("Moving instructions backward!");
            transform.position = new Vector3(0, 0, 1);
        }
    }
}
