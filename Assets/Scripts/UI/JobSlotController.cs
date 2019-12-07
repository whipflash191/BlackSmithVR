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
    public TextMeshProUGUI clientName;
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
            clientName.SetText("");
            jobName.SetText("");
            jobImage.color = Color.clear;
        } else
        {
            jobName.SetText(job.jobName);
            clientName.SetText(job.clientName);
            jobImage.sprite = job.jobIcon;
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
