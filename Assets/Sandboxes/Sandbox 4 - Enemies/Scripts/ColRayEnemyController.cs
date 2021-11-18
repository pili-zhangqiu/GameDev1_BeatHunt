using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColRayEnemyController : MonoBehaviour
{
    [SerializeField]
    GameObject rayRowEnemy;
    Rigidbody rayRowObjEnemy;

    [SerializeField]
    Image rayRowEnemyWarning;

    // Color parameters for image alpha modifications
    private Color imgColor;

    // Parameters for randomisation of row ray swipers location in map
    private Vector3 rayRowStartPos = new Vector3(0, 0, -0.6f);
    private Vector3 rayRowWarnStartPos = new Vector3(0, 1, -0.6f);

    private Vector3 rayRowOutPos = new Vector3(0, 0, 120f);
    private Vector3 rayRowWarnOutPos = new Vector3(0, 150f, 0);

    private int rayAttackRowLoc;    // From -17 to 17
    public float rowPosMov = 1.135f;

    // Beat position memory
    int intPrevBeat;
    int intCurrBeat;

    // Ray spawning rate - for enemy wave tweaks
    public  int spawnBeatDelay;
    private bool calcNewLoc = true;


    void Start()
    {
        // Setup image properties (RGB and alphas)
        imgColor = rayRowEnemyWarning.color;

        // Get Ray GameObject rigidbody
        rayRowObjEnemy = rayRowEnemy.GetComponent<Rigidbody>();

        // Ray GameObject and warning out of scene
        rayRowObjEnemy.transform.position = rayRowOutPos;
        rayRowEnemyWarning.transform.position = rayRowWarnOutPos;

        // Start beat parameters
        intPrevBeat = 0;
    }

    void Update()
    {
        intCurrBeat = Mathf.FloorToInt(ConductorController.songPositionInBeats);
        bool stopRayEnemy = EnemyWaves.stopSpawningColRay;

        if (stopRayEnemy == false)
        {
            // -------------------- Wave Parameter Tweaker ----------------------
            // Entering warning before triggering attack
            if (intCurrBeat % spawnBeatDelay != 0 & intCurrBeat != intPrevBeat)
            {
                if (calcNewLoc == true)
                {
                    // Previous ray object out
                    rayRowObjEnemy.transform.position = rayRowOutPos;

                    // Next ray warning in
                    rayAttackRowLoc = Random.Range(-14, 15);
                    Debug.Log("Random row: " + rayAttackRowLoc);

                    Vector3 offsetRayWarnRow = new Vector3(0, 0, (rowPosMov * rayAttackRowLoc));
                    rayRowEnemyWarning.transform.position = rayRowWarnStartPos + offsetRayWarnRow;
                    //float offsetX = rowPosMov * rayAttackRowLoc;
                    //rayRowEnemyWarning.transform.position = new Vector3(offsetX, 1, 0);

                    // Toggle to avoid recalculation of new ray lcoation when in the same ray loop
                    calcNewLoc = false;
                }

                if (intCurrBeat % spawnBeatDelay == (spawnBeatDelay-2))
                {
                    // Change transparency to indicate imminency of ray attack
                    // (60% equal one turn left before strike)
                    imgColor.a = 0.7f;
                    rayRowEnemyWarning.color = imgColor;
                }

                else if (intCurrBeat % spawnBeatDelay == (spawnBeatDelay-1))
                {
                    // Change transparency to indicate imminency of ray attack
                    // (30% indicates strike will happen in the next turn)
                    imgColor.a = 0.3f;
                    rayRowEnemyWarning.color = imgColor;
                }

                else
                {
                    // Set transparent when warning states has not started
                    imgColor.a = 0f;
                    rayRowEnemyWarning.color = imgColor;
                }

            }

            else if (intCurrBeat % spawnBeatDelay == 0 & intCurrBeat != intPrevBeat)
            {
                // Previous ray warning out
                rayRowEnemyWarning.transform.position = rayRowWarnOutPos;

                // Next ray object in
                Vector3 offsetRayObjRow = new Vector3(0, 0, rowPosMov * rayAttackRowLoc);
                rayRowObjEnemy.transform.position = rayRowStartPos + offsetRayObjRow;

                // Calculate location next turn for new strike
                calcNewLoc = true;
            }
        }

        intPrevBeat = intCurrBeat;
    }
}
