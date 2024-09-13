using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private Transform interactRayStart;
    [SerializeField] private Transform interactRayEnd;

    private int cornHeld;
    private int cornHeldMax = 5;

    public int GetCornHeld()
    {
        return cornHeld;
    }
    public int GetCornHeldMax()
    {
        return cornHeldMax;
    }

    public void SetCornHeld(int amount)
    {
        cornHeld = amount;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(interactRayStart.position, interactRayEnd.position, Color.blue);

        float rayLength = 2f;
        if (Physics.Raycast(interactRayStart.position, interactRayEnd.position - interactRayStart.position, out RaycastHit rayHitInfo, rayLength))
        {
            if (rayHitInfo.transform.gameObject.TryGetComponent<CornPlant>(out CornPlant cornPlant))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    cornPlant.Interact(this);
                }
            }

            if (rayHitInfo.transform.gameObject.TryGetComponent<CornBarrel>(out CornBarrel cornBarrel))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    cornBarrel.Interact(this);
                }
            }
        }
    }
}
