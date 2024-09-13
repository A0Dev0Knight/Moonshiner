using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornBarrel : MonoBehaviour
{
    private int cornHeld;
    private int cornHeldMax = 10;

    private float decompTimer = 5f;
    private float decompTimerMax = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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

                // waiting to scoop the corn back in the still
            }
        }
    }

    public void Interact(Player player, int amount = 1)
    {
        if (cornHeld < cornHeldMax)
        {
            if (player.GetCornHeld() > 0)
            {
                cornHeld += amount;
                player.SetCornHeld(player.GetCornHeld() - amount);

            }
        }
    }
}
