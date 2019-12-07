using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(PartIdentifier))]
public class TestSnapper : MonoBehaviour
{

    public Transform snapPoint1;
    public Transform snapPoint2;

    bool isSnapped;
    public bool isHandle;
    public bool isPommel;
    
    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SnapToObject(GameObject objToSnapTo)
    {
        isSnapped = true;
        Destroy(gameObject.GetComponent<Throwable>());
        Destroy(gameObject.GetComponent<VelocityEstimator>());
        Destroy(gameObject.GetComponent<Interactable>());
        Destroy(gameObject.GetComponent<Rigidbody>());
        if (isHandle)
        {
            
            transform.rotation = objToSnapTo.GetComponent<MaterialInteraction>().GuardPos.rotation;
            transform.position = objToSnapTo.GetComponent<MaterialInteraction>().GuardPos.position + (transform.position - snapPoint1.position);
            transform.SetParent(objToSnapTo.transform);
        }
        if (isPommel)
        {
            transform.rotation = objToSnapTo.GetComponent<TestSnapper>().snapPoint1.rotation;
            transform.position = objToSnapTo.GetComponent<TestSnapper>().snapPoint2.position + (transform.position - snapPoint1.position);
            transform.SetParent(objToSnapTo.transform);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("SnapCollided");
        MaterialInteraction bladeTest = collision.collider.gameObject.GetComponent<MaterialInteraction>();
        TestSnapper handleTest = collision.collider.gameObject.GetComponent<TestSnapper>();
        if (isHandle && bladeTest != null)
        {
            SnapToObject(collision.collider.gameObject);
            collision.collider.gameObject.GetComponent<MaterialInteraction>().weaponHandle = gameObject;
        } else if (isPommel && handleTest != null && handleTest.isSnapped == true)
        {
            SnapToObject(collision.collider.gameObject);
            collision.collider.gameObject.transform.parent.GetComponent<MaterialInteraction>().weaponPommel = gameObject;
        }
    }
}
