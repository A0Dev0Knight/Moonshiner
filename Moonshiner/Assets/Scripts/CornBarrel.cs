using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornBarrel : MonoBehaviour
{
    private int cornHeld;
    private int cornHeldMax = 10;

    private float decompTimer = 5f;
    private float decompTimerMax = 5f;

    private float decompCorn = 0f;
    private float decompCornMax = 5f;

    void Update()
    {
        if (cornHeld == cornHeldMax)
        {
            // start decomp timer for corn
            Debug.Log("Decomping");
        
            decompTimer -= Time.deltaTime;
            if (decompTimer < 0)
            {
                decompTimer = decompTimerMax;
                Debug.Log("finished decomping");

                decompCorn = decompCornMax; // added decompedorn to be picked up by the player
            }
        }
    }

    public void Interact(Player player, int amount = 1)
    {
        if (cornHeld < cornHeldMax && decompCorn == 0)
        {
            if (player.GetCornHeld() > 0)
            {
                cornHeld += amount;
                player.SetCornHeld(player.GetCornHeld() - amount);

            }
        }
    }

    public void InteractAlternate(Player player, int amount = 1)
    {
        if (decompCorn > 0)
        {
            decompCorn -= amount;
            player.SetDecompedCornHeld(player.GetDecompedCornHeld() + amount);
        }
    }
}
