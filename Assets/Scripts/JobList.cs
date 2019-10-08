/*
* Copyright (c) Dylan Faith (Whipflash191)
* https://twitter.com/Whipflash191
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Job List", menuName = "Job System/Job List")]
public class JobList : ScriptableObject
{
    public List<JobItem> jobs = new List<JobItem>();
}
