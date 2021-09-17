using JMRSDK.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VadaSpawn : MonoBehaviour
{
    public GameObject breadprefab, masalaprefab, vadapawprefab;

    public int whatToSpawn;
    public Transform dropppoint;

    public GameObject vadapaw; // to delete th clones;


   public static bool foodtemspawn; //only to spawn vadapaw;
   public static int vadapawcount = 0; //to check the foodcount for vadapav;

    // Start is called before the first frame update
    void Start()
    {
        foodtemspawn = false;
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
        

        if (!foodtemspawn)
        {
            switch (whatToSpawn)
            {

                case 1:
                    if(vadapawcount == 0)
                    {
                        GameObject bomb = Instantiate(breadprefab, dropppoint.transform.position, Quaternion.identity);
                        vadapaw = bomb;
                        vadapawcount++;
                        Debug.Log(vadapawcount);
                    }
                    break;
                case 2:
                    if(vadapawcount == 1)
                    {
                        Destroy(vadapaw);
                        GameObject bomb2 = Instantiate(masalaprefab, dropppoint.transform.position, Quaternion.identity);
                        vadapaw = bomb2;
                        vadapawcount++;
                        Debug.Log(vadapawcount);
                    }
                    break;
                case 3:
                    if(vadapawcount== 2)
                    {
                        Destroy(vadapaw);
                        Instantiate(vadapawprefab, dropppoint.transform.position, Quaternion.identity);
                        vadapawcount++;
                        Debug.Log(vadapawcount);

                    }
                    break;
                default:
                    Debug.Log("Please follow the food itme menu");
                    break;

                  

            }

       }    
    }
        
}
