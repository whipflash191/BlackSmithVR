﻿/*
* Copyright (c) Dylan Faith (Whipflash191)
* https://twitter.com/Whipflash191
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class MaterialInteraction : MonoBehaviour
{
    public ScriptableMaterial partMaterial;
    public GameObject weaponBlade;
    public GameObject weaponHandle;
    public GameObject weaponPommel;
    public string bladeName;
    public enum Stage {Flatten, Lengthen, Tip, Tang, Grind};
    public Stage currentForgeStage;
    Material material;
    public SkinnedMeshRenderer mesh;
    public GameObject nextModel;

    [Header("Heating")]
    public float tempratureProgress = 0;
    public float currentTime;
    public bool heating = false;
    public bool isHardened = false;

    [Header("Forging")]
    Forging forge = new Forging();
    public List<Collider> colliders = new List<Collider>();
    public GameObject anvil;
    Collider furtherestFromAnvil = null;
    float farestDistance = 1000000;

    [Header("Weapon Construction")]
    public Transform GuardPos;
    public bool isTang = false;
    public bool HasGuard = false;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if(heating)
        {
            if(tempratureProgress < 2)
            {
                tempratureProgress += Time.deltaTime * partMaterial.heatTime;
                if(tempratureProgress > 2)
                {
                    tempratureProgress = 2;
                }
                material.SetFloat("_HeatLerp", tempratureProgress);
            } 
        } else
        {
            if(tempratureProgress > 0)
            {
                tempratureProgress -= Time.deltaTime * partMaterial.coolTime;
                if(tempratureProgress < 0)
                {
                    tempratureProgress = 0;
                }
                material.SetFloat("_HeatLerp", tempratureProgress);
            }
        }
    }

    private void FixedUpdate()
    {
        /*
        int notTouchingCount = 0;
       // FindFurestSideFromAnvil();
       for(int i = 0; i < colliders.Count; i++)
        {
            if(colliders[i].GetComponent<IngotCollidePoints>())
            {
                if (colliders[i].GetComponent<IngotCollidePoints>().onAnvil)
                {
                    transform.parent.GetComponent<Rigidbody>().isKinematic = true;
                    break;
                }
                else notTouchingCount++;
            }
            if(notTouchingCount == colliders.Count)
            {
                transform.parent.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
        */
    }

    private void FindFurestSideFromAnvil()
    {
        farestDistance = 0;

        for (int i = 0; i < 4; i++)
        {
            float d = Vector3.Distance(colliders[i].bounds.center, anvil.transform.position);
            if (d > farestDistance)
            {
                furtherestFromAnvil = colliders[i];
                farestDistance = d;
            }
        }

        for (int i = 0; i < 4; i++)
        {
            if (colliders[i] != furtherestFromAnvil)
            {
                colliders[i].enabled = false;
            }
            else colliders[i].enabled = true;
        }
    }

    private void Forge(Collider collider)
    {
         //Should bee on a seperate event manager but meeh

        if (tempratureProgress > partMaterial.hitTempMin && isHardened == false)
        {
            if (currentForgeStage == Stage.Flatten)
            {
                FXManager.instance.AnvilHit(collider);
                print("Flattening");
                forge.ForgeFlatten(collider, colliders, mesh, tempratureProgress, gameObject, nextModel);
            }
            else if (currentForgeStage == Stage.Lengthen)
            {
                FXManager.instance.AnvilHit(collider);
                print("Lengthening");
                forge.ForgeLengthen(collider, colliders, mesh, tempratureProgress, gameObject, nextModel);
            }
            else if (currentForgeStage == Stage.Tip)
            {
                FXManager.instance.AnvilHit(collider);
                forge.ForgeTip(collider, colliders, mesh, tempratureProgress, gameObject, nextModel);
            }
            else if (currentForgeStage == Stage.Tang)
            {
                FXManager.instance.AnvilHit(collider);
                forge.ForgeTang(collider, colliders, mesh, tempratureProgress, gameObject, nextModel);
            }
        }
        else if (currentForgeStage == Stage.Grind && isHardened == true)
        {
            FXManager.instance.AnvilHit(collider);
            forge.ForgeGrind(collider, colliders, mesh, tempratureProgress, gameObject, nextModel);
        }
        else
        {
            //Bad hit
            FXManager.instance.AnvilBadHit(collider);
        }
    }

    private void Snap(GameObject objToSnapTo, Transform snapPoint)
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.tag == "Fire")
        {
            heating = true;
        }

        if (collision.gameObject.tag == "Quench")
        {
            Debug.Log("Got Here");
            if (partMaterial.needsHardening == true && tempratureProgress > partMaterial.hitTempMin)
            {
                isHardened = true;
                tempratureProgress = 0;
                material.SetFloat("_HeatLerp", tempratureProgress);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Fire")
        {
            heating = false;
        }
    }
}
