using JMRSDK.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VadaSpawn : MonoBehaviour
{
    public GameObject breadprefab, masalaprefab, vadapawprefab;

    public int whatToSpawn;
    public Transform dropppoint;

    public GameObject vadapaw;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetInfo();
            // JMRPointerManager.Instance.GetCurrentRay();
        }

        

       
    }

    //private void OnMouseDown()
    //{


    //    whatToSpawn = FooCheck.instance.foodvalue;
    //    MakeVadapaw();



    //}

    void GetInfo()
    {
        var ray = JMRPointerManager.Instance.GetCurrentRay();
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxDistance: 100))
        {
            if (hit.collider.tag == "Player")
            {
                whatToSpawn = hit.collider.GetComponent<FooCheck>().Foodvalue;
                MakeVadapaw();
                //Debug.Log("Shubham");
            }
        }
    }

    public void MakeVadapaw()
    {
       

        switch(whatToSpawn)
        {
            case 1:
                
               GameObject bomb =Instantiate(breadprefab, dropppoint.transform.position, Quaternion.identity) ;
               vadapaw = bomb;
                
                break;
            case 2:

                Destroy(vadapaw);
                GameObject bomb2= Instantiate(masalaprefab, dropppoint.transform.position, Quaternion.identity);
                vadapaw = bomb2;

                break;
            case 3:
                Destroy(vadapaw);
                Instantiate(vadapawprefab, dropppoint.transform.position, Quaternion.identity);
                break;

        }
    }
        
}
