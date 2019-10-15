using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JobPanelController : MonoBehaviour
{
    public JobItem job;
    public Image jobImage;
    public TextMeshProUGUI jobName;
    public TextMeshProUGUI jobDescription;
    public TextMeshProUGUI clientName;
    public TextMeshProUGUI rewardDescription;
    // Start is called before the first frame update
    void Start()
    {
        UpdatePanel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdatePanel()
    {
        if(job == null)
        {
            jobImage.color = Color.clear;
            jobName.SetText("");
            jobDescription.SetText("");
            clientName.SetText("");
            rewardDescription.SetText("");
        } else
        {
            jobImage.sprite = job.jobImage;
            jobImage.color = Color.white;
            jobName.SetText(job.jobName);
            jobDescription.SetText(job.jobDescription);
            clientName.SetText("Issued By: " + job.clientName);
            rewardDescription.SetText("Reward: " + job.Reward);
        }
    }

    public void AddJob()
    {
        if (job != null)
        {
            PlayerManager.instance.playerJobList.Add(job);
            JobSystem.instance.RemoveJob(job);
        }
    }
    public void RemoveJob()
    {
        if (job != null)
        {
            if (PlayerManager.instance.playerJobList.Contains(job))
            {
                PlayerManager.instance.playerJobList.Remove(job);
            }
            JobSystem.instance.RemoveJob(job);
        }
        job = null;
        UpdatePanel();
        gameObject.SetActive(false);
    }

}
