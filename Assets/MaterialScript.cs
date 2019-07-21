using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialScript : MonoBehaviour
{
    public List<MaterialInteraction> materialPoints = new List<MaterialInteraction>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Fire")
        {
            foreach (MaterialInteraction item in materialPoints)
            {
                item.cooling = false;
                item.heating = true;
            }
        }

        if(collision.gameObject.tag == "Quench")
        {
            foreach (MaterialInteraction item in materialPoints)
            {
                if(item.canHarden == true && item.heatingProgress > 1 || item.canHarden == true && item.coolingProgress > 1)
                {
                    item.isHardened = true;
                    item.heatingProgress = 0;
                    item.coolingProgress = 0;
                }
            }
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Fire")
        {
            foreach (MaterialInteraction item in materialPoints)
            {
                item.cooling = true;
                item.heating = false;
                item.currentTime = 0;
            }
        }
    }
}
