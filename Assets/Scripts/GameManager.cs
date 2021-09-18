using JMRSDK.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    public GameObject breadprefab, masalaprefab, vadapawprefab;

    public GameObject san_breadprefab, breadsauce_prefab, veggie_prefab, toast_prefab;




    public int whatToSpawn;


    public Transform vada_dropppoint;
    public Transform san_droppoint;
    public Transform toast_droppoint;
    
    public GameObject vadapaw; // to delete th clones;

    public GameObject sandwich;


   public static bool vadaitemspawn; //only to spawn vadapaw;
   public static int vadapawcount = 0; //to check the foodcount for vadapav;


    public static bool sandwichitemsspawn;
    public static int sandwichcount=0;



    private void Awake()
    {
        
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        vadaitemspawn = false;
        sandwichitemsspawn = false;

    }

    // Update is called once per frame
    void Update()
    {
     
        //TO Check on The Laptop or Unity Editor;
        if (Input.GetMouseButtonDown(0))
        {
            GetInfo();
            // JMRPointerManager.Instance.GetCurrentRay();
        }
    }



    public void GetInfo()
    {
        var ray = JMRPointerManager.Instance.GetCurrentRay();
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxDistance: 100))
        {
            if (hit.collider.tag == "VadaPav")
            {
                whatToSpawn = hit.collider.GetComponent<ItemCount>().Foodvalue;
                MakeVadapaw();
                //Debug.Log("Shubham");
            }

            if(hit.collider.tag =="Sandwich")
            {
                whatToSpawn = hit.collider.GetComponent<ItemCount>().Foodvalue;
                MakeSandwich();
            }
        }
    }


    #region Make Vada Pav
    public void MakeVadapaw()
    {
       
        if (!vadaitemspawn)
        {
            switch (whatToSpawn)
            {

                case 1:
                    if(vadapawcount == 0)
                    {
                        GameObject bomb = Instantiate(breadprefab, vada_dropppoint.transform.position, Quaternion.identity);
                        vadapaw = bomb;
                        vadapawcount++;
                        Debug.Log(vadapawcount);
                    }
                    break;
                case 2:
                    if(vadapawcount == 1)
                    {
                        Destroy(vadapaw);
                        GameObject bomb2 = Instantiate(masalaprefab, vada_dropppoint.transform.position, Quaternion.identity);
                        vadapaw = bomb2;
                        vadapawcount++;
                        Debug.Log(vadapawcount);
                    }
                    break;
                case 3:
                    if(vadapawcount== 2)
                    {
                        Destroy(vadapaw);
                        Instantiate(vadapawprefab, vada_dropppoint.transform.position, Quaternion.identity);
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
    #endregion

    #region MakeSandwhich
    public void MakeSandwich()
    {
        if(!sandwichitemsspawn)
        {
            switch (whatToSpawn)
            {

                case 1:
                    if (sandwichcount == 0)
                    {
                        GameObject bread = Instantiate(san_breadprefab, san_droppoint.transform.position, Quaternion.identity);
                        sandwich = bread;
                        sandwichcount++;
                        
                    }
                    break;
                case 2:
                    if (sandwichcount == 1)
                    {
                        Destroy(sandwich);
                        GameObject breadsauce = Instantiate(breadsauce_prefab, san_droppoint.transform.position, Quaternion.identity);
                        sandwich = breadsauce;
                        sandwichcount++;
                        
                    }
                    break;
                case 3:
                    if (sandwichcount == 2)
                    {
                        Destroy(sandwich);
                        GameObject veggeprefab= Instantiate(veggie_prefab, san_droppoint.transform.position, Quaternion.identity);
                        sandwich = veggeprefab;
                        sandwichcount++;
                    }
                    break; 
                default:
                    Debug.Log("Please follow the food itme menu");
                    break;

            }
        }
    }


    public void DropToast()
    {
            Destroy(sandwich);
         Instantiate(toast_prefab,toast_droppoint.transform.position, transform.rotation);
    }

    #endregion 



}
