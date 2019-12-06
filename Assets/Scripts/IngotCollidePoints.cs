using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngotCollidePoints : MonoBehaviour
{
    public GameObject Metal;
    public Collider thisCollider;
    public Vector3 distFromTarget;

    public bool onAnvil = false;
    public IngotCollidePoints myOppositeSide;

    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Anvil")
        {
            onAnvil = true;
            
        }
        if (collider.tag == "Hammer" && myOppositeSide.onAnvil == true)
        {
            Metal.SendMessage("Forge", thisCollider);
        }
        else if (collider.tag == "Guard" || collider.tag == "Handle")
        {
            //Metal.SendMessage("Snap", collider);
        }

    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Anvil")
        {
            onAnvil = false;
           
        }
    }
    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "GrindWheel")
        {
            Metal.SendMessage("Forge", thisCollider);
        }
    }
}
