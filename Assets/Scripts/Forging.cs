using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forging
{
    public void ForgeFlatten(Collider collider, List<Collider> colliders, SkinnedMeshRenderer mesh, float tempratureProgress, GameObject currentModel, GameObject nextModel)
    {
        if (collider == colliders[0])
        {
            if (mesh.GetBlendShapeWeight(0) > 0)
            {
                mesh.SetBlendShapeWeight(0, (mesh.GetBlendShapeWeight(0) - 20));
            }
        }
        else if (collider == colliders[1])
        {
            if (mesh.GetBlendShapeWeight(0) > 0)
            {
                mesh.SetBlendShapeWeight(0, (mesh.GetBlendShapeWeight(0) - 20));
            }
        }
        else if (collider == colliders[2])
        {
            mesh.SetBlendShapeWeight(0, (mesh.GetBlendShapeWeight(0) + 20));
            if (mesh.GetBlendShapeWeight(0) == 100)
            {
                nextModel.GetComponent<MaterialInteraction>().tempratureProgress = tempratureProgress;
                nextModel.transform.position = currentModel.transform.position;
                nextModel.transform.rotation = currentModel.transform.rotation;
                nextModel.SetActive(true);
                currentModel.SetActive(false);
            }
        }
        else if (collider == colliders[3])
        {
            mesh.SetBlendShapeWeight(0, (mesh.GetBlendShapeWeight(0) + 20));
            if (mesh.GetBlendShapeWeight(0) == 100)
            {
                nextModel.GetComponent<MaterialInteraction>().tempratureProgress = tempratureProgress;
                nextModel.transform.position = currentModel.transform.position;
                nextModel.transform.rotation = currentModel.transform.rotation;
                nextModel.SetActive(true);
                currentModel.SetActive(false);
            }
        }
    }

    public void ForgeLengthen(Collider collider, List<Collider> colliders, SkinnedMeshRenderer mesh, float tempratureProgress, GameObject currentModel, GameObject nextModel)
    {
        if (collider == colliders[0])
        {
            Debug.Log("collider 0");
            mesh.SetBlendShapeWeight(0, (mesh.GetBlendShapeWeight(0) + 20));
            if (mesh.GetBlendShapeWeight(0) == 100)
            {
                nextModel.GetComponent<MaterialInteraction>().tempratureProgress = tempratureProgress;
                nextModel.transform.position = currentModel.transform.position;
                nextModel.transform.rotation = currentModel.transform.rotation;
                nextModel.SetActive(true);
                currentModel.SetActive(false);
            }
        }
        else if (collider == colliders[1])
        {
            Debug.Log("collider 1");

            mesh.SetBlendShapeWeight(0, (mesh.GetBlendShapeWeight(0) + 20));
            if (mesh.GetBlendShapeWeight(0) == 100)
            {
                nextModel.GetComponent<MaterialInteraction>().tempratureProgress = tempratureProgress;
                nextModel.transform.position = currentModel.transform.position;
                nextModel.transform.rotation = currentModel.transform.rotation;
                nextModel.SetActive(true);
                currentModel.SetActive(false);
            }
        }
        else if (collider == colliders[2])
        {
            Debug.Log("collider 3");
            if (mesh.GetBlendShapeWeight(0) > 0)
            {
                mesh.SetBlendShapeWeight(0, (mesh.GetBlendShapeWeight(0) - 20));
            }
        }
        else if (collider == colliders[3])
        {
            Debug.Log("collider 4");
            if (mesh.GetBlendShapeWeight(0) > 0)
            {
                mesh.SetBlendShapeWeight(0, (mesh.GetBlendShapeWeight(0) - 20));
            }
        }
    }

    public void ForgeTip(Collider collider, List<Collider> colliders, SkinnedMeshRenderer mesh, float tempratureProgress, GameObject currentModel, GameObject nextModel)
    {
        if (collider == colliders[0])
        {
            mesh.SetBlendShapeWeight(0, (mesh.GetBlendShapeWeight(0) + 20));
            if (mesh.GetBlendShapeWeight(0) == 100)
            {
                nextModel.GetComponent<MaterialInteraction>().tempratureProgress = tempratureProgress;
                nextModel.transform.position = currentModel.transform.position;
                nextModel.transform.rotation = currentModel.transform.rotation;
                nextModel.SetActive(true);
                currentModel.SetActive(false);
            }
        }
        else if (collider == colliders[1])
        {
            mesh.SetBlendShapeWeight(0, (mesh.GetBlendShapeWeight(0) + 20));
            if (mesh.GetBlendShapeWeight(0) == 100)
            {
                nextModel.GetComponent<MaterialInteraction>().tempratureProgress = tempratureProgress;
                nextModel.transform.position = currentModel.transform.position;
                nextModel.transform.rotation = currentModel.transform.rotation;
                nextModel.SetActive(true);
                currentModel.SetActive(false);
            }
        }
        else if (collider == colliders[2])
        {
            if (mesh.GetBlendShapeWeight(0) > 0)
            {
                mesh.SetBlendShapeWeight(0, (mesh.GetBlendShapeWeight(0) - 20));
            }
        }
        else if (collider == colliders[3])
        {
            if (mesh.GetBlendShapeWeight(0) > 0)
            {
                mesh.SetBlendShapeWeight(0, (mesh.GetBlendShapeWeight(0) - 20));
            }
        }
    }

    public void ForgeTang(Collider collider, List<Collider> colliders, SkinnedMeshRenderer mesh, float tempratureProgress, GameObject currentModel, GameObject nextModel)
    {
        if (collider == colliders[0])
        {
            mesh.SetBlendShapeWeight(0, (mesh.GetBlendShapeWeight(0) + 20));
            if (mesh.GetBlendShapeWeight(0) == 100)
            {
                nextModel.GetComponent<MaterialInteraction>().tempratureProgress = tempratureProgress;
                nextModel.transform.position = currentModel.transform.position;
                nextModel.transform.rotation = currentModel.transform.rotation;
                nextModel.SetActive(true);
                currentModel.SetActive(false);
            }
        }
        else if (collider == colliders[1])
        {
            mesh.SetBlendShapeWeight(0, (mesh.GetBlendShapeWeight(0) + 20));
            if (mesh.GetBlendShapeWeight(0) == 100)
            {
                nextModel.GetComponent<MaterialInteraction>().tempratureProgress = tempratureProgress;
                nextModel.transform.position = currentModel.transform.position;
                nextModel.transform.rotation = currentModel.transform.rotation;
                nextModel.SetActive(true);
                currentModel.SetActive(false);
            }
        }
        else if (collider == colliders[2])
        {
            if (mesh.GetBlendShapeWeight(0) > 0)
            {
                mesh.SetBlendShapeWeight(0, (mesh.GetBlendShapeWeight(0) - 20));
            }
        }
        else if (collider == colliders[3])
        {
            if (mesh.GetBlendShapeWeight(0) > 0)
            {
                mesh.SetBlendShapeWeight(0, (mesh.GetBlendShapeWeight(0) - 20));
            }
        }
    }

    public void ForgeGrind(Collider collider, List<Collider> colliders, SkinnedMeshRenderer mesh, float tempratureProgress, GameObject currentModel, GameObject nextModel)
    {
        if (collider == colliders[0])
        {
            if (mesh.GetBlendShapeWeight(0) < 100)
            {
                mesh.SetBlendShapeWeight(0, (mesh.GetBlendShapeWeight(0) + 5));
            }
        }
        else if (collider == colliders[1])
        {
            if (mesh.GetBlendShapeWeight(0) < 100)
            {
                mesh.SetBlendShapeWeight(0, (mesh.GetBlendShapeWeight(0) + 5));
            }
        }
        else if (collider == colliders[2])
        {
            if (mesh.GetBlendShapeWeight(0) < 100)
            {
                mesh.SetBlendShapeWeight(0, (mesh.GetBlendShapeWeight(0) + 5));
            }
        }
        else if (collider == colliders[3])
        {
            if (mesh.GetBlendShapeWeight(0) < 100)
            {
                mesh.SetBlendShapeWeight(0, (mesh.GetBlendShapeWeight(0) + 5));
            }
        }

        if (mesh.GetBlendShapeWeight(1) == 100)
        {
            foreach (Collider item in colliders)
            {
                if (item.gameObject.activeSelf == true)
                {
                    item.gameObject.SetActive(false);
                }
                else
                {
                    item.gameObject.SetActive(true);
                }
            }
        }
    }
}
