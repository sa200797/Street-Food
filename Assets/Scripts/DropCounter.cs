using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCounter : MonoBehaviour
{

    public GameObject LevelMan;
    public LevelManager levelmanager;

    

     public Transform startpoint;

    public Transform snapPoint;

    

    void Start()
    {
        LevelMan = GameObject.Find("LevelManager");
        levelmanager = LevelMan.GetComponent<LevelManager>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        
       
        if (collision.gameObject.CompareTag("C_Vadapav"))
        {
                    
            Debug.Log("VadaPawComplete2");
            GameManager.vadaitemspawn = false;
            GameManager.vadapawcount = 0;

            //tartpoint.position = collision.gameObject.transform.position;
            //startpoint.position = GameObject.FindGameObjectWithTag("C_Vadapav").transform.position;
           // startpoint.position = collision.transform.position;

            //collision.gameObject.transform.position = Vector3.Lerp(startpoint.position, snapPoint.position, 2f);

            //collision.gameObject.transform.position = snapPoint.transform.position;

            //Destroy(collision.gameObject,10f);

            CheckFood(FoodType.foodtype.vadapav);



            //check that list here which contain food type
            // if its not there than its wrong food;



        }
        if (collision.gameObject.CompareTag("C_Sandwich"))
        {
            Debug.Log("Sandwich Complete");
            GameManager.sandwichitemsspawn = false;
            GameManager.sandwichcount = 0;
            Destroy(collision.gameObject,3f);
        }

        if(collision.gameObject.CompareTag("C_Pizza"))
        {
            Debug.Log("Pizza Complete");
            GameManager.pizzaitemspawn = false;
            GameManager.pizzacount = 0;
            Destroy(collision.gameObject, 3f);
        }
    }



    bool CheckFood(FoodType.foodtype checkfood)
    {
       return  levelmanager.orderList.Contains(checkfood); // bool return lar; 
    }
  

    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}
