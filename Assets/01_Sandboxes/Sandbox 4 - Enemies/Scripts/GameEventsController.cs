using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventsController : MonoBehaviour
{
    int intCurrBeat;

    [SerializeField]
    GameObject fireBallPrefab;

    /*
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
    */


    // Update is called once per frame
    void Update()
    {
        intCurrBeat = Mathf.FloorToInt(ConductorController.songPositionInBeats);

        if (intCurrBeat <= 30f )
        {
            // -------------------- Wave 1 ----------------------
            if (intCurrBeat == 5)
            {
                //GameObject clone1 = Instantiate(fireBallPrefab) as GameObject;
                fireBallPrefab.SetActive(true);
            }

            if (intCurrBeat == 12)
            {
                //GameObject clone1 = Instantiate(fireBallPrefab) as GameObject;
                fireBallPrefab.SetActive(false);
                DestroyInstances(LaunchProjectiles.allTheProjectiles);
            }
            /*
            // -------------------- Wave 2 ----------------------
            else if (intCurrBeat == 10)
            {
                //GameObject clone2 = Instantiate(fireBallPrefab) as GameObject;
                //fireBallPrefab.SetActive(false);
                fireBallPrefab.SetActive(true);
            }

            else if (intCurrBeat == 15)
            {
                //GameObject clone3 = Instantiate(fireBallPrefab) as GameObject;
                fireBallPrefab.SetActive(false);
                fireBallPrefab.SetActive(true);
            }

            if (intCurrBeat == 20)
            {
                //GameObject clone4 = Instantiate(fireBallPrefab) as GameObject;
                fireBallPrefab.SetActive(false);
                fireBallPrefab.SetActive(true);
            }

            else if (intCurrBeat == 25)
            {
                //GameObject clone5 = Instantiate(fireBallPrefab) as GameObject;
                fireBallPrefab.SetActive(false);
                fireBallPrefab.SetActive(true);
            }

            else if (intCurrBeat == 30)
            {
                //GameObject clone6 = Instantiate(fireBallPrefab) as GameObject;
                fireBallPrefab.SetActive(false);
                fireBallPrefab.SetActive(true);
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

    private void DestroyInstances(List<GameObject> instanceList)
    {
        for (int i = 0; i < instanceList.Count; i++)
        {
            Destroy(instanceList[i]);
        }
        instanceList.Clear();
    }
}
