using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandInZone : MonoBehaviour
{
    public JobItem currentJob;
    public static PlayerHandInZone instance;
    public bool isActive = false;
    public ParticleSystem activeParticle;
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
            if(currentJob != null)
            {
                foreach (string requiredItem in currentJob.requireItems)
                {
                    currentJob.requireItems.Remove(requiredItem);
                }

                if(currentJob.requireItems.Count <= 0)
                {
                    isActive = false;
                    activeParticle.Stop();
                    PlayerManager.instance.playerJobList.Remove(currentJob);
                    PlayerManager.instance.money += currentJob.Reward;
                    currentJob = null;
                }
            }

        }
    }
}
