using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngotCollider : MonoBehaviour
{
    public MaterialInteraction Metal;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMetal()
    {

        foreach (MaterialInteraction item in transform.GetComponentsInChildren<MaterialInteraction>(false))
        {
            if(item.gameObject.activeInHierarchy == true)
            {
                Metal = item;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        SetMetal();
        Metal.SendMessage("CollisionStart", collision);
    }

    private void OnCollisionExit(Collision collision)
    {
        SetMetal();
        Metal.SendMessage("CollisionStop", collision);
    }
}
