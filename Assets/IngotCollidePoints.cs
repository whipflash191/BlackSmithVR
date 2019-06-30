using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngotCollidePoints : MonoBehaviour
{
    public GameObject Metal;
    public Collider thisCollider;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Hammer")
        {
            Metal.SendMessage("Forge", thisCollider);
        }
        else if (collider.tag == "Guard" || collider.tag == "Handle")
        {
            Metal.SendMessage("Snap", collider);
        }
    }
}
