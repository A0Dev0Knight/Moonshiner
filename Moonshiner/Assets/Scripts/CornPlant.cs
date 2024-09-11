using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornPlant : MonoBehaviour
{
    private int cornAmount;
    private int cornAmountMax = 3;
    private float cornSpawnTimer;
    private float cornSpawnTimerMax = 3f;

    public void PickUpCorn(int amount = 1)
    {
        cornAmount -= amount;

        if (cornAmount < 0)
        {
            Debug.LogError("Cannot pick up any corn!");
            cornAmount = 0;
        }
    }

    private void Update()
    {
        Debug.Log(cornAmount);

        if (cornAmount < cornAmountMax )
        {
            // a corn needs to be spawned

            cornSpawnTimer -= Time.deltaTime;

            if (cornSpawnTimer < 0 )
            {
                // time to spawn a corn
                cornSpawnTimer = cornSpawnTimerMax;
                cornAmount++;
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            PickUpCorn();
        }
    }
}
