using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCounter : MonoBehaviour
{

    public GameObject LevelMan;
    public LevelManager levelmanager;

    
    bool move;

    public static int ordervalidity;


    public Transform transformPoint;

    void Start()
    {
        LevelMan = GameObject.Find("LevelManager");
        levelmanager = LevelMan.GetComponent<LevelManager>();
        move = true;


        //Move this to LevelManager 
        levelmanager.UiUpdate();
    }

    private void OnCollisionEnter(Collision collision)
    {
        
       
        if (collision.gameObject.CompareTag("C_Vadapav"))
        {
                    
            Debug.Log("VadaPawComplete2");
            GameManager.vadaitemspawn = false;
            GameManager.vadapawcount = 0;

            GameManager.amount = 10;
          //  collision.gameObject.GetComponent<JMRManipulation2>().enabled = false;
            collision.gameObject.transform.position = Vector3.MoveTowards(collision.gameObject.transform.position, transform.position, 1);

            //Destroy(collision.gameObject,3f);

           // CheckFood(FoodType.foodtype.vadapav);
            MakeFood(FoodType.foodtype.VadaPav);

            //Debug.Log(CheckFood(FoodType.foodtype.vadapav)+ "11225");

            //check that list here which contain food type
            // if its not there than its wrong food;



        }
        if (collision.gameObject.CompareTag("C_Sandwich"))
        {
            Debug.Log("Sandwich Complete");
            GameManager.sandwichitemsspawn = false;
            GameManager.sandwichcount = 0;
            Destroy(collision.gameObject,3f);
            //CheckFood(FoodType.foodtype.sandwich);
            // MakeFood();
            MakeFood(FoodType.foodtype.Sandwich);
            GameManager.amount = 30;
            // TostSandwich.active_sandcol = true;
            TostSandwich.sandwich_coll.enabled = true;

            //Debug.Log(CheckFood(FoodType.foodtype.sandwich) + "11225");
        }

        if(collision.gameObject.CompareTag("C_Pizza"))
        {
            Debug.Log("Pizza Complete");
            GameManager.pizzaitemspawn = false;
            GameManager.pizzacount = 0;
            Destroy(collision.gameObject, 3f);
            //CheckFood(FoodType.foodtype.pizza);
            MakeFood(FoodType.foodtype.Pizza);
            GameManager.amount = 50;



            // MakeFood();

            //Debug.Log(CheckFood(FoodType.foodtype.pizza) + "11225");
        }
    }

    


    bool CheckFood(FoodType.foodtype checkfood)
    {
        
        return  levelmanager.orderList.Contains(checkfood); // bool return lar; 
        

    }

    void MakeFood(FoodType.foodtype food)
    {
        SoundManager.instance.SoundPlay_OC();

        if (levelmanager.orderList[0] == food)
        {
            levelmanager.orderList.Remove(food);
            levelmanager.ordercount++;

            //Move this to level Manager and Make a function then call here;
            levelmanager.UiUpdate();
            ordervalidity = 1;
            StartCoroutine(FoodDropComplete());
        }
        else
        {
            Debug.Log("Wrong Food");
            ordervalidity = 2;
            StartCoroutine(FoodDropComplete());
        }
       

        //if (CheckFood(FoodType.foodtype.vadapav) == true)
        //{
        //    levelmanager.orderList.Remove(FoodType.foodtype.vadapav);
        //    //levelmanager.orderList.Remove(0);
        //}
        //else
        //{
        //    Debug.LogError("Wrong Food");
        //}
        //if(CheckFood(FoodType.foodtype.sandwich) == true)
        //{
        //    levelmanager.orderList.Remove(FoodType.foodtype.sandwich);
        //   // levelmanager.orderList.Remove(0);
        //}
        //if(CheckFood(FoodType.foodtype.pizza) == true)
        //{
        //    levelmanager.orderList.Remove(FoodType.foodtype.pizza);
        //    //levelmanager.orderList.Remove(0);
        //}
        //else
        //{
        //    Debug.LogError("Wrong Food");
        //}
    }

    

    // Start is called before the first frame update
    //void Start()
    //{
            
    //}


    IEnumerator FoodDropComplete()
    {
        UIManager.instance.ChangeMaterial();

        yield return new WaitForSeconds(3.0f);
        ordervalidity = 0;
        UIManager.instance.ChangeMaterial();
       
       
    }
   

    public void MakeStartingFood()
    {
      //  levelmanager.orderList.Contains(checkfood)

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
