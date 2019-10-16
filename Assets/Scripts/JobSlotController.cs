using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JobSlotController : MonoBehaviour
{
    public GameObject jobPanel;
    public JobItem job;
    public TextMeshProUGUI jobName;
    public Image jobImage;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateInfo()
    {
        if (job == null)
        {
            jobName.SetText("");
            jobImage.color = Color.clear;
        } else
        {
            jobName.SetText(job.jobName);
            jobImage.sprite = job.jobImage;
            jobImage.color = Color.white;
        }
    }

    public void OpenPanel()
    {
        if(job != null)
        {
            jobPanel.SetActive(true);
            JobPanelController instance = jobPanel.GetComponent<JobPanelController>();
            instance.job = job;
            instance.UpdatePanel();
        }
    }
    
}
