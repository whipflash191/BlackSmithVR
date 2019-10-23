/*
* Copyright (c) Dylan Faith (Whipflash191)
* https://twitter.com/Whipflash191
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Job", menuName = "Job System/Job")]
public class JobItem : ScriptableObject
{
    public string clientName = null;
    public string jobName = null;
    public string jobDescription = null;
    public Sprite jobIcon = null;
    public float Reward = 0;
    public List<string> requireItems = new List<string>();
}
