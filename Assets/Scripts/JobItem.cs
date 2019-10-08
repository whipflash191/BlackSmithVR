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
    public string jobDescription = null;
    public Texture jobImage = null;
    public float Reward = 0;
    public List<string> requireItems = new List<string>();
}
