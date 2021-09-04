using JMRSDK.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalRaycast : MonoBehaviour
{

 



    public Vector3 raypos;

    public GameObject jiocontroller;


    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {

        
           
        

        
    }

    // Update is called once per frame
    void Update()
    {
        if(jiocontroller == null)
        {
            jiocontroller = GameObject.Find("JioGlassController(Clone)");
            if(jiocontroller != null)
            raypos = jiocontroller.transform.position;
        }


        if(Input.GetMouseButtonDown(0))
        {
            GetInfo();
           // JMRPointerManager.Instance.GetCurrentRay();
        }

    }

    void GetInfo() => RayCast();

    void  RayCast()
    {
       // Debug.DrawRay(raypos, Input.mousePosition);
       // var ray = new Ray(raypos, Input.mousePosition);
        var ray = JMRPointerManager.Instance.GetCurrentRay();
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxDistance: 100))
        {
            string valuename = hit.collider.GetComponent<ItemName>().nameofItem;
            if (hit.collider.name == valuename )
            {
               
                Debug.Log("Shubham");
            }
        }

    }
}
