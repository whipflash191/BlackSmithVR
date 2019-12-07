/*
* Copyright (c) Dylan Faith (Whipflash191)
* https://twitter.com/Whipflash191
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandInZone : MonoBehaviour
{
    public JobItem currentJob;
    public static PlayerHandInZone instance;
    public bool isActive = false;
    public ParticleSystem activeParticle;
    public JobPanelController playerJobDisplay;
    public GameObject portalOrigin;
    public Transform[] path;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        activeParticle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(isActive)
        {
            if (other.GetComponent<Valve.VR.InteractionSystem.Interactable>())
            {
                other.GetComponent<Rigidbody>().useGravity = false;
                iTween.MoveTo(other.gameObject, iTween.Hash("position", portalOrigin.transform.position, "easeType", "easeOutCirc", "time", 4, "path", path));
            }

            if(currentJob != null)
            {
                foreach (WeaponItem requiredItem in currentJob.requiredItems)
                {
                    MaterialInteraction test = requiredItem.weaponBlade.GetComponentInChildren<MaterialInteraction>(true);
                    if (test.bladeName == other.gameObject.GetComponentInChildren<MaterialInteraction>().bladeName)
                    {
                        if(requiredItem.weaponHandle.GetComponent<PartIdentifier>().isHandle && requiredItem.weaponHandle.GetComponent<PartIdentifier>().handleName == other.gameObject.GetComponentInChildren<MaterialInteraction>().weaponHandle.GetComponent<PartIdentifier>().handleName)
                        {
                            if (requiredItem.weaponPommel.GetComponent<PartIdentifier>().isPommel && requiredItem.weaponPommel.GetComponent<PartIdentifier>().pommelName == other.gameObject.GetComponentInChildren<MaterialInteraction>().weaponPommel.GetComponent<PartIdentifier>().pommelName)
                            {
                                currentJob.requiredItems.Remove(requiredItem);
                            }
                        } 
                    }
                }

                if(currentJob.requiredItems.Count <= 0)
                {
                    isActive = false;
                    activeParticle.Stop();
                    PlayerManager.instance.money += currentJob.Reward;
                    playerJobDisplay.RemoveJobPlayer();
                    Destroy(other.gameObject);
                }
            }

        }
    }

}
