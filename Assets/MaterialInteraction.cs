/*
* Copyright (c) Dylan Faith (Whipflash191)
* https://twitter.com/Whipflash191
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class MaterialInteraction : MonoBehaviour
{
    public enum Stage {Flatten, Lengthen, Tip, Tang};
    public Stage currentForgeStage;
    Material material;
    
    [Header("Heating")]
    public float heatTime;
    public float coolTime;
    public float heatingProgress = 0;
    public float coolingProgress = 0;
    public float temp;
    public float currentTime;
    public bool heating = false;
    public bool cooling = false;

    [Header("Forging")]
    public Transform GuardPos;
    public Transform HandlePos;
    public bool isTip = false;
    public bool isTang = false;
    public List<Collider> colliders = new List<Collider>();
    public GameObject anvil;
    Collider furtherestFromAnvil = null;
    float farestDistance = 1000000;
    public bool HasGuard = false;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
        currentForgeStage = Stage.Flatten;
    }

    // Update is called once per frame
    void Update()
    {
        if(heating)
        {
            if(currentTime <= heatTime)
            {
                currentTime += Time.deltaTime;
                heatingProgress = Mathf.Lerp(coolingProgress, 2, currentTime / heatTime);
                material.SetFloat("_HeatLerp", heatingProgress);
                temp = (coolingProgress / 200) * 500;
            }
        }

        if(cooling)
        {
            if(currentTime <= coolTime)
            {
                currentTime += Time.deltaTime;
                coolingProgress = Mathf.Lerp(heatingProgress, 0, currentTime / heatTime);
                material.SetFloat("_HeatLerp", coolingProgress);
                temp = (coolingProgress / 200) * 500;

            }
        }
    }

    private void FixedUpdate()
    {
        FindFurestSideFromAnvil();
    }

    private void FindFurestSideFromAnvil()
    {

        farestDistance = 0;

        for (int i = 0; i < colliders.Count; i++)
        {
            float d = Vector3.Distance(colliders[i].bounds.center, anvil.transform.position);
            if (d > farestDistance)
            {
                furtherestFromAnvil = colliders[i];
                farestDistance = d;
            }
        }

        for (int i = 0; i < colliders.Count; i++)
        {
            if (colliders[i] != furtherestFromAnvil)
            {
                colliders[i].enabled = false;
            }
            else colliders[i].enabled = true;
        }
    }

    private void ForgeFlatten(Collider collider)
    {
        if (collider == colliders[0])
        {
            transform.localPosition = new Vector3(0, -0.103f, transform.localPosition.z);
            transform.localScale = new Vector3(transform.localScale.x, 0.03f, transform.localScale.z);
        }
        else if (collider == colliders[1])
        {
            transform.localPosition = new Vector3(0, 0.103f, transform.localPosition.z);
            transform.localScale = new Vector3(transform.localScale.x, 0.03f, transform.localScale.z);
        }
        else if (collider == colliders[2])
        {
            transform.localPosition = new Vector3(0.103f, 0, transform.localPosition.z);
            transform.localScale = new Vector3(0.03f, transform.localScale.y, transform.localScale.z);
        }
        else if (collider == colliders[3])
        {
            transform.localPosition = new Vector3(-0.103f, 0, transform.localPosition.z);
            transform.localScale = new Vector3(0.03f, transform.localScale.y, transform.localScale.z);
        }
    }

    private void ForgeLengthen(Collider collider)
    {
        if (collider == colliders[0])
        {
            transform.localPosition = new Vector3(transform.localPosition.x, -0.073f, transform.localPosition.z);
            transform.localScale = new Vector3(transform.localScale.x, 0.1f, transform.localScale.z);
        }
        else if (collider == colliders[1])
        {
            transform.localPosition = new Vector3(transform.localPosition.x, 0.073f, transform.localPosition.z);
            transform.localScale = new Vector3(transform.localScale.x, 0.1f, transform.localScale.z);
        }
        else if (collider == colliders[2])
        {
            transform.localPosition = new Vector3(0.075f, transform.localScale.y, transform.localPosition.z);
            transform.localScale = new Vector3(transform.localScale.x, 0.1f, transform.localScale.z);
        }
        else if (collider == colliders[3])
        {
            transform.localPosition = new Vector3(0.075f, transform.localScale.y, transform.localPosition.z);
            transform.localScale = new Vector3(0.1f, transform.localScale.y, transform.localScale.z);
        }
    }

    private void ForgeTip(Collider collider)
    {
        //ToBeImplemented 
    }

    private void ForgeTang(Collider collider)
    {
        if (collider == colliders[0])
        {
            transform.localScale = new Vector3(transform.localScale.x, 0.05f, transform.localScale.z);
        }
        else if (collider == colliders[1])
        {
            transform.localScale = new Vector3(transform.localScale.x, 0.05f, transform.localScale.z);
        }
        else if (collider == colliders[2])
        {
            transform.localScale = new Vector3(0.05f, transform.localScale.y, transform.localScale.z);
        }
        else if (collider == colliders[3])
        {
            transform.localScale = new Vector3(0.05f, transform.localScale.y, transform.localScale.z);
        }
    }

    private void Forge(Collider collider)
    {
        if (heatingProgress > 1 || coolingProgress > 1)
        {
            if (currentForgeStage == Stage.Flatten)
            {
                ForgeFlatten(collider);
                currentForgeStage = Stage.Lengthen;
            }
            else if (currentForgeStage == Stage.Lengthen)
            {
                ForgeLengthen(collider);
                if (isTip)
                {
                    currentForgeStage = Stage.Tip;
                }
                else if (isTang)
                {
                    currentForgeStage = Stage.Tang;
                }
            } else if (currentForgeStage == Stage.Tip)
            {
                ForgeTip(collider);
            }
            else if (currentForgeStage == Stage.Tang)
            {
                ForgeTang(collider);
            }
        }
    }

    private void Snap(Collider collider)
    {
        if (collider.tag == "Handle" && HasGuard && isTang)
        {
            Destroy(collider.gameObject.GetComponent<Throwable>());
            Destroy(collider.gameObject.GetComponent<Interactable>());
            Destroy(collider.gameObject.GetComponent<VelocityEstimator>());
            Destroy(collider.gameObject.GetComponent<Rigidbody>());
            collider.transform.SetParent(transform.parent);
            collider.transform.position = HandlePos.transform.position;
            collider.transform.rotation = HandlePos.transform.rotation;
        }
        else if (collider.tag == "Guard" && isTang)
        {
            Debug.Log("Got Here");
            HasGuard = true;
            Destroy(collider.gameObject.GetComponent<Throwable>());
            Destroy(collider.gameObject.GetComponent<Interactable>());
            Destroy(collider.gameObject.GetComponent<VelocityEstimator>());
            Destroy(collider.gameObject.GetComponent<Rigidbody>());
            collider.transform.SetParent(transform.parent);
            collider.transform.position = GuardPos.transform.position;
            collider.transform.rotation = transform.parent.rotation;
        }
    }
}
