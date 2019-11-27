using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSnapper : MonoBehaviour
{

    public Transform snapPoint1;
    public Transform snapPoint2;

    public GameObject testObjToSnap;

    public bool isBlade;
    public bool isHandle;
    public bool isPommel;
    
    // Start is called before the first frame update
    void Start()
    {
     if(testObjToSnap !=null)
      SnapToObject(testObjToSnap, snapPoint1);
  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SnapToObject(GameObject objToSnapTo, Transform snapPoint)
    {
        transform.rotation = objToSnapTo.GetComponent<TestSnapper>().snapPoint1.rotation;

        if(isBlade || isHandle)
            transform.position = objToSnapTo.GetComponent<TestSnapper>().snapPoint1.position + (transform.position - snapPoint1.position);
        if(isPommel)
            transform.position = objToSnapTo.GetComponent<TestSnapper>().snapPoint2.position + (transform.position - snapPoint1.position);

        transform.SetParent(objToSnapTo.transform);
    }
}
