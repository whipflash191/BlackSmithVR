/* SceneHandler.cs*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;
using Valve.VR.InteractionSystem;

public class SceneHandler : MonoBehaviour
{
    public SteamVR_LaserPointer laserPointer;

    void Awake()
    {
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        if (e.target.name == "Job")
        {
            InputModule.instance.Submit(e.target.gameObject);
        }
        else if (e.target.name == "Accept")
        {
            InputModule.instance.Submit(e.target.gameObject);
        }
        else if (e.target.name == "Decline")
        {
            InputModule.instance.Submit(e.target.gameObject);
        }
    }

    public void PointerInside(object sender, PointerEventArgs e)
    {
        if (e.target.name == "Job")
        {
            InputModule.instance.HoverBegin(e.target.gameObject);
        }
        else if (e.target.name == "Accept")
        {
            InputModule.instance.HoverBegin(e.target.gameObject);
        }
        else if (e.target.name == "Decline")
        {
            InputModule.instance.HoverBegin(e.target.gameObject);
        }
    }

    public void PointerOutside(object sender, PointerEventArgs e)
    {
        if (e.target.name == "Job")
        {
            InputModule.instance.HoverEnd(e.target.gameObject);
        }
        else if (e.target.name == "Accept")
        {
            InputModule.instance.HoverEnd(e.target.gameObject);
        }
        else if (e.target.name == "Decline")
        {
            InputModule.instance.HoverEnd(e.target.gameObject);
        }
    }
}