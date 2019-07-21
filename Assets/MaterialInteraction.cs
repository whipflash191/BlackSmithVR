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
    public SkinnedMeshRenderer mesh;
    [Header("Heating")]
    public float heatTime;
    public float coolTime;
    public float heatingProgress = 0;
    public float coolingProgress = 0;
    public float temp;
    public float currentTime;
    public bool heating = false;
    public bool cooling = false;
    public bool isHardened = false;
    public bool canHarden = false;
    public bool debug = false;

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

        if(debug)
        {
            coolingProgress = 2;
            material.SetFloat("_HeatLerp", coolingProgress);
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
            if(mesh.GetBlendShapeWeight(0) > 0)
            {
                mesh.SetBlendShapeWeight(0, (mesh.GetBlendShapeWeight(0) - 20));
            }
            //transform.localPosition = new Vector3(0, -0.103f, transform.localPosition.z);
            //transform.localScale = new Vector3(transform.localScale.x, 0.03f, transform.localScale.z);
        }
        else if (collider == colliders[1])
        {
            if (mesh.GetBlendShapeWeight(0) > 0)
            {
                mesh.SetBlendShapeWeight(0, (mesh.GetBlendShapeWeight(0) - 20));
            }
            //transform.localPosition = new Vector3(0, 0.103f, transform.localPosition.z);
            //transform.localScale = new Vector3(transform.localScale.x, 0.03f, transform.localScale.z);
        }
        else if (collider == colliders[2])
        {
            mesh.SetBlendShapeWeight(0, (mesh.GetBlendShapeWeight(0) + 20));
            //transform.localPosition = new Vector3(0.103f, 0, transform.localPosition.z);
            //transform.localScale = new Vector3(0.03f, transform.localScale.y, transform.localScale.z);
        }
        else if (collider == colliders[3])
        {
            mesh.SetBlendShapeWeight(0, (mesh.GetBlendShapeWeight(0) + 20));
            //transform.localPosition = new Vector3(-0.103f, 0, transform.localPosition.z);
            //transform.localScale = new Vector3(0.03f, transform.localScale.y, transform.localScale.z);
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
        if (heatingProgress > 1 && isHardened == false || coolingProgress > 1 && isHardened == false)
        {
            if (currentForgeStage == Stage.Flatten)
            {
                if (mesh.GetBlendShapeWeight(0) < 100)
                {
                    ForgeFlatten(collider);
                }
                else
                {
                    //currentForgeStage = Stage.Lengthen;
                }
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
                } else
                {
                    canHarden = true;
                }
            } else if (currentForgeStage == Stage.Tip)
            {
                ForgeTip(collider);
                canHarden = true;
            }
            else if (currentForgeStage == Stage.Tang)
            {
                ForgeTang(collider);
                canHarden = true;
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Fire")
        {
            cooling = false;
            heating = true;
        }

        if (collision.gameObject.tag == "Quench")
        {
            if (canHarden == true && heatingProgress > 1 || canHarden == true && coolingProgress > 1)
            {
                isHardened = true;
                heatingProgress = 0;
                coolingProgress = 0;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Fire")
        {
            cooling = true;
            heating = false;
            currentTime = 0;
        }
    }
}
