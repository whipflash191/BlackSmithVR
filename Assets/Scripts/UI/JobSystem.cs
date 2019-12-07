using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobSystem : MonoBehaviour
{
    public static JobSystem instance;
    public GameObject JobSystemPanel;
    public List<JobItem> availableJobs = new List<JobItem>();
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        updateJobSlots();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void updateJobSlots()
    {
        int index = 0;
        foreach  (Transform child in JobSystemPanel.transform)
        {
            JobSlotController instance = child.GetComponent<JobSlotController>();
            if (instance != null)
            {
                if (index < availableJobs.Count)
                {
                    instance.job = availableJobs[index];
                }
                else
                {
                    instance.job = null;
                }
                instance.UpdateInfo();
                index++;
            }
        }
    }

    public void RemoveJob(JobItem job)
    {
        availableJobs.Remove(job);
        updateJobSlots();
    }
}
