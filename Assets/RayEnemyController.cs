using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayEnemyController : MonoBehaviour
{
    [SerializeField]
    GameObject rayRowEnemy;

    [SerializeField]
    Image rayRowEnemyWarning;

    int intCurrBeat;

    Rigidbody rayRowObjEnemy;

    private Color fullColor;
    private Color transColor;

    private Vector3 rayRowStartPos = new Vector3(0, 0, 0);
    private Vector3 rayRowWarnStartPos = new Vector3(0, 1, 0);

    private Vector3 rayRowOutPos = new Vector3(0, 0, 120f);
    private Vector3 rayRowWarnOutPos = new Vector3(0, 150f, 0);

    public static int waveEnemy = 1;
    private int rayAttackRowLoc;    // From -17 to 17

    public float rowPosMov = 1.13f;

    private int intPrevBeat;


    void Start()
    {
        
        // Setup image alphas
        fullColor = rayRowEnemyWarning.color;
        fullColor.a = 0.5f;
        rayRowEnemyWarning.color = fullColor;
        /*
        transColor = fullColor;
        transColor.a = 0f;
        */
        rayRowObjEnemy = rayRowEnemy.GetComponent<Rigidbody>();

        // Ray GameObject out of scene
        rayRowObjEnemy.transform.position = rayRowOutPos;

        // Ray GameObject out of scene
        // rayRowEnemyWarning.color = transColor;
        rayRowEnemyWarning.transform.position = rayRowWarnOutPos;

        intPrevBeat = 0;


    }

    void Update()
    {
        intCurrBeat = Mathf.FloorToInt(ConductorController.songPositionInBeats);

        // -------------------- Wave 1 ----------------------
        if (waveEnemy == 1)
        {
            if (intCurrBeat % 2 == 0 & intCurrBeat != intPrevBeat)
            {
                // Previous ray object out
                rayRowObjEnemy.transform.position = rayRowOutPos;

                // Next ray warning in
                rayAttackRowLoc = Random.Range(-17, 17);
                //rayAttackRowLoc = -17;
                Debug.Log("Random row: " + rayAttackRowLoc);

                Vector3 offsetRayWarnRow = new Vector3((rowPosMov * rayAttackRowLoc),0, 0);
                //rayRowEnemyWarning.transform.position = rayRowWarnStartPos + offsetRayWarnRow;
                float offsetX = rowPosMov * rayAttackRowLoc;
                Debug.Log(" ---> Offset for Random row: " + offsetX);
                rayRowEnemyWarning.transform.position = new Vector3(offsetX, 1, 0);
            }

            else if (intCurrBeat % 2 == 1 & intCurrBeat != 1 & intCurrBeat != intPrevBeat)
            {
                // Previous ray warning out
                rayRowEnemyWarning.transform.position = rayRowWarnOutPos;

                // Next ray object in
                Vector3 offsetRayObjRow = new Vector3(rowPosMov * rayAttackRowLoc, 0, 0);
                rayRowObjEnemy.transform.position = rayRowStartPos + offsetRayObjRow;
            }
        }

        intPrevBeat = intCurrBeat;
    }
}
