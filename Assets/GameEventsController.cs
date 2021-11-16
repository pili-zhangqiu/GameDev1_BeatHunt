using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventsController : MonoBehaviour
{
    int intCurrBeat;

    [SerializeField]
    GameObject fireBallPrefab;

    [SerializeField]
    public GameObject clone1;

    [SerializeField]
    public GameObject clone2;

    [SerializeField]
    public GameObject clone3;

    [SerializeField]
    public GameObject clone4;

    [SerializeField]
    public GameObject clone5;

    [SerializeField]
    public GameObject clone6;


    // Update is called once per frame
    void Update()
    {
        intCurrBeat = Mathf.FloorToInt(ConductorController.songPositionInBeats);

        if (intCurrBeat <= 30f )
        {
            if (intCurrBeat == 5)
            {
                //GameObject clone1 = Instantiate(fireBallPrefab) as GameObject;
                clone1.SetActive(true);
            }

            else if (intCurrBeat == 10)
            {
                //GameObject clone2 = Instantiate(fireBallPrefab) as GameObject;
                clone2.SetActive(true);
            }

            /*
            else if (intCurrBeat == 15)
            {
                //GameObject clone3 = Instantiate(fireBallPrefab) as GameObject;
                clone3.SetActive(true);
                clone1.SetActive(false);
            }

            if (intCurrBeat == 20)
            {
                //GameObject clone4 = Instantiate(fireBallPrefab) as GameObject;
                clone4.SetActive(true);
                clone2.SetActive(false);
            }

            else if (intCurrBeat == 25)
            {
                //GameObject clone5 = Instantiate(fireBallPrefab) as GameObject;
                clone5.SetActive(true);
                clone3.SetActive(false);
            }

            else if (intCurrBeat == 30)
            {
                //GameObject clone6 = Instantiate(fireBallPrefab) as GameObject;
                clone6.SetActive(true);
                clone4.SetActive(false);
            }
            */
        }

        /*
        else if (intCurrBeat > 30f & intCurrBeat >= 60f)
        {
            if (intCurrBeat % 4 == 0)
            {
                GameObject clone1 = Instantiate(fireBallPrefab) as GameObject;
                clone.SetActive(true);
            }
        }

        else if (intCurrBeat > 60f & intCurrBeat >= 90f)
        {
            if (intCurrBeat % 3 == 0)
            {
                GameObject clone = Instantiate(fireBallPrefab) as GameObject;
                clone.SetActive(true);
            }
        }

        else if (intCurrBeat > 90f & intCurrBeat >= 120f)
        {
            if (intCurrBeat % 2 == 0)
            {
                GameObject clone = Instantiate(fireBallPrefab) as GameObject;
                clone.SetActive(true);
            }
        }
        */
    }
}
