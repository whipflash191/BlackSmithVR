using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PartIdentifier))]
public class TestSnapper : MonoBehaviour
{

    public Transform snapPoint1;
    public Transform snapPoint2;

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

        if(isHandle)
            transform.rotation = objToSnapTo.GetComponent<MaterialInteraction>().GuardPos.rotation;
            transform.position = objToSnapTo.GetComponent<MaterialInteraction>().GuardPos.position + (transform.position - snapPoint1.position);
        if(isPommel)
            transform.rotation = objToSnapTo.GetComponent<TestSnapper>().snapPoint1.rotation;
            transform.position = objToSnapTo.GetComponent<TestSnapper>().snapPoint2.position + (transform.position - snapPoint1.position);

        transform.SetParent(objToSnapTo.transform);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(isHandle && collision.gameObject.GetComponent<MaterialInteraction>())
        {
            SnapToObject(collision.gameObject);
            collision.gameObject.GetComponent<MaterialInteraction>().weaponHandle = gameObject;
        } else if (isPommel && collision.gameObject.GetComponent<TestSnapper>())
        {
            SnapToObject(collision.gameObject);
            collision.gameObject.transform.parent.GetComponent<MaterialInteraction>().weaponPommel = gameObject;
        }
    }
}
