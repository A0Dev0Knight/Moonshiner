using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornPlant : MonoBehaviour
{
    private int cornAmount;
    private int cornAmountMax = 3;
    private float cornSpawnTimer;
    private float cornSpawnTimerMax = 3f;

    public bool TryPickUpCorn(int amount = 1)
    {
        cornAmount -= amount;

        if (cornAmount < 0)
        {
            Debug.LogError("Cannot pick up any corn!");
            cornAmount = 0;
            return false;
        }
        else
        {
            return true;
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
    }

    public void Interact(Player player, int amount = 1)
    {
        Debug.Log("interanct with corn plant");
        if (player.GetCornHeld() < player.GetCornHeldMax())
        {
            bool didPickUp = TryPickUpCorn(amount);
            if (didPickUp)
            {
                player.SetCornHeld(player.GetCornHeld() + amount);
            }
        }
        else
        {
            Debug.LogError("Player cannot pick up any more corn!");
        }
        Debug.Log("corn held is: " + player.GetCornHeld());
    }
}
