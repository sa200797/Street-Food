using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCounter : MonoBehaviour
{

    public GameObject LevelMan;
    public LevelManager levelmanager;

    [SerializeField] int OrderIndex;
    [SerializeField] LevelManager.NumberOffOrder numberOffOrder;

    bool move;

    public static int ordervalidity;
    public Transform transformPoint;

    int score;
    [Header("Drop Objects")]
    [SerializeField]
    GameObject foodParcel;
    [SerializeField]
    GameObject pizzaBox;
    int itemtype = 0;


    [Space(20)]
    [SerializeField] GameObject PointOne;
    [SerializeField] GameObject PointTwo;
    [SerializeField] GameObject PointThree;


    Timer GetTime;

    void Awake()
    {
        SetupPoint();
    }

    private void SetupPoint()
    {
        numberOffOrder = GameObject.Find("LevelManager").GetComponent<LevelManager>().numberOffOrder;

        if (numberOffOrder == LevelManager.NumberOffOrder.OneOrder)
        {
            PointOne.SetActive(true);

            PointOne.SetActive(false);
            PointThree.SetActive(false);
        }
        else if (numberOffOrder == LevelManager.NumberOffOrder.TwoOrder)
        {
            PointOne.SetActive(true);
            PointTwo.SetActive(true);

            PointThree.SetActive(false);
        }
        else if (numberOffOrder == LevelManager.NumberOffOrder.ThreeOrder)
        {
            PointOne.SetActive(true);
            PointTwo.SetActive(true);
            PointThree.SetActive(true);
        }
    }

    void Start()
    {
        LevelMan = GameObject.Find("LevelManager");
        levelmanager = LevelMan.GetComponent<LevelManager>();
        move = true;

        GetTime = FindObjectOfType<Timer>();
        //Move this to LevelManager 
        //levelmanager.UiUpdate();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (numberOffOrder == LevelManager.NumberOffOrder.OneOrder)
        {
            if (collision.gameObject.CompareTag("C_Vadapav"))
            {
                GameManager.amount = 10;
                Debug.Log("VadaPawComplete2");
                GameManager.vadaitemspawn = false;
                GameManager.vadapawcount = 0;
                //  collision.gameObject.GetComponent<JMRManipulation2>().enabled = false;
                // collision.gameObject.transform.position = Vector3.MoveTowards(collision.gameObject.transform.position, transform.position, 1);

                Destroy(collision.gameObject);

                // CheckFood(FoodType.foodtype.vadapav);
                MakeFood(FoodType.foodtype.VadaPav);

                //Debug.Log(CheckFood(FoodType.foodtype.vadapav)+ "11225");

                //check that list here which contain food type
                // if its not there than its wrong food;



            }
            if (collision.gameObject.CompareTag("C_Sandwich"))
            {
                GameManager.amount = 30;
                Debug.Log("Sandwich Complete");
                GameManager.sandwichitemsspawn = false;
                GameManager.sandwichcount = 0;

                Destroy(collision.gameObject);
                //CheckFood(FoodType.foodtype.sandwich);
                // MakeFood();
                MakeFood(FoodType.foodtype.Sandwich);

                // TostSandwich.active_sandcol = true;
                TostSandwich.sandwich_coll.enabled = true;

                //Debug.Log(CheckFood(FoodType.foodtype.sandwich) + "11225");
            }
            if (collision.gameObject.CompareTag("C_Pizza"))
            {
                GameManager.amount = 50;
                Debug.Log("Pizza Complete");
                GameManager.pizzaitemspawn = false;
                GameManager.pizzacount = 0;
                Destroy(collision.gameObject);

                //CheckFood(FoodType.foodtype.pizza);
                MakeFood(FoodType.foodtype.Pizza);
                // MakeFood();

                //Debug.Log(CheckFood(FoodType.foodtype.pizza) + "11225");
            }
        }

        //Rushabh
        if (numberOffOrder == LevelManager.NumberOffOrder.TwoOrder)
        {
            Debug.Log("Two Name");
            if (collision.gameObject.CompareTag("C_Vadapav"))
            {
                GameManager.amount = 30;
                Debug.Log("Sandwich Complete");
                GameManager.sandwichitemsspawn = false;
                GameManager.sandwichcount = 0;
                
                Destroy(collision.gameObject);

                //collision.gameObject.SetActive(false);                                
                //CheckFood(FoodType.foodtype.sandwich);
                //MakeFood();
                //MakeFood(FoodType.foodtype.Sandwich);
                // TostSandwich.active_sandcol = true;
                //TostSandwich.sandwich_coll.enabled = true;

                if (OrderIndex == 2)
                {
                    MakeFood(FoodType.foodtype.VadaPav);
                    Debug.Log("One user Order Complelete ");
                }
                else
                {
                    OrderIndex++;
                }

            }
            if (collision.gameObject.CompareTag("C_Sandwich")) 
            {
                GameManager.amount = 30;
                Debug.Log("Sandwich Complete");
                GameManager.sandwichitemsspawn = false;
                GameManager.sandwichcount = 0;

                Destroy(collision.gameObject);

                /*if (OrderIndex == 0)
                {
                    collision.gameObject.transform.SetParent(PointOne.transform);
                }
                else if (OrderIndex == 1)
                {
                    collision.gameObject.transform.SetParent(PointOne.transform);
                }
                */

                //collision.gameObject.SetActive(false);                                
                //CheckFood(FoodType.foodtype.sandwich);
                //MakeFood();
                //MakeFood(FoodType.foodtype.Sandwich);
                //TostSandwich.active_sandcol = true;
                //TostSandwich.sandwich_coll.enabled = true;

                if (OrderIndex == 2)
                {
                    Debug.Log("One user Order Complelete ");
                    MakeFood(FoodType.foodtype.Sandwich);
                }
                else
                {
                    OrderIndex++;
                }
            }
            if (collision.gameObject.CompareTag("C_Pizza"))
            {
                GameManager.amount = 30;
                Debug.Log("Sandwich Complete");
                GameManager.sandwichitemsspawn = false;
                GameManager.sandwichcount = 0;

                Destroy(collision.gameObject);

                /*if (OrderIndex == 0)
                {
                    collision.gameObject.transform.SetParent(PointOne.transform);
                }
                else if (OrderIndex == 1)
                {
                    collision.gameObject.transform.SetParent(PointOne.transform);
                }
                */

                //collision.gameObject.SetActive(false);                                
                //CheckFood(FoodType.foodtype.sandwich);
                //MakeFood();
                //MakeFood(FoodType.foodtype.Sandwich);
                //TostSandwich.active_sandcol = true;
                //TostSandwich.sandwich_coll.enabled = true;

                if (OrderIndex == 2)
                {
                    Debug.Log("One user Order Complelete ");
                    MakeFood(FoodType.foodtype.Pizza);
                }
                else
                {
                    OrderIndex++;
                }
            }
        }
    }
    bool CheckFood(FoodType.foodtype checkfood)
    {
        return levelmanager.orderList.Contains(checkfood);
    }

    void MakeFood(FoodType.foodtype food)
    {
        SoundManager.instance.SoundPlay_OC();

        if (levelmanager.orderList[0] == food)
        {
            if (levelmanager.orderList[0] == FoodType.foodtype.VadaPav)
            {
                itemtype = 1;
            }
            else if (levelmanager.orderList[0] == FoodType.foodtype.Sandwich)
            {
                itemtype = 2;
            }
            else if (levelmanager.orderList[0] == FoodType.foodtype.Pizza)
            {
                itemtype = 3;
            }
            else
            {

            }
            levelmanager.orderList.Remove(food);
            score += GameManager.amount;
            SavaData.instance.money = score;
            // SavaData.instance.TotalAmount(score);
            UIManager.instance.totalAmoumt.text = score.ToString();

            levelmanager.ordercount++;
            SavaData.instance.ordercount = levelmanager.ordercount - 1;
            //SavaData.instance.TotalOrderCompleted();

            ordervalidity = 1;
            UIManager.instance.ordercomplete.text = "Order Complete!! Thankyou ";


            UIManager.instance.ChangeMaterial();
            StartCoroutine(FoodDropComplete());
            // StartCoroutine(IncreaseLevel());
            //Invoke("IncreaseLevel", 1.0f);

            switch (itemtype)
            {
                case 1:
                    foodParcel.SetActive(true);
                    GetTime.AddTimer(5);
                    break;
                case 2:
                    foodParcel.SetActive(true);
                    GetTime.AddTimer(15);
                    break;
                case 3:
                    pizzaBox.SetActive(true);
                    GetTime.AddTimer(25);
                    break;
                default:
                    //foodParcel.SetActive(false);
                    // pizzaBox.SetActive(false);
                    break;
            }
        }
        else
        {

            Debug.Log("Wrong Food");
            ordervalidity = 2;
            UIManager.instance.ordercomplete.text = "Wrong Order Delivered";
            UIManager.instance.ChangeMaterial();
            StartCoroutine(FoodDropComplete());
        }

        // void  IncreaseLevel()
        //{

        //   // yield return new WaitForSeconds(4.0f);
        //    levelmanager.UiUpdate();
        //    ordervalidity = 1;
        //    UIManager.instance.ordercomplete.text = "New Order";


        //}


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

    IEnumerator FoodDropComplete()
    {
        //yield return new WaitForSeconds(1.0f);
        yield return new WaitForSeconds(4.0f);
        levelmanager.GetOrder();
        UIManager.instance.ordercomplete.text = "New Order";
        ordervalidity = 0;
        foodParcel.SetActive(false);
        pizzaBox.SetActive(false);
        itemtype = 0;
        // UIManager.instance.ChangeMaterial();
    }
    public void MakeStartingFood()
    {
        //  levelmanager.orderList.Contains(checkfood)
    }

    
}

public class parcel 
{

}
/*
public abstract class Compnentss
{
    public string name;
    protected Compnentss(string name) { this.name = name; }
    public abstract void add(Compnentss c);
    public abstract void remove(Compnentss c);
    public abstract void Display(Compnentss c);
     
}
public class comoposit : Compnentss
{
    [SerializeField] List<Compnentss> compnents;
    public comoposit(string name) : base(name) 
    {
    }
    public override void add(Compnentss c)
    {
        throw new System.NotImplementedException();
    }

    public override void Display(Compnentss c)
    {
        throw new System.NotImplementedException();
    }

    public override void remove(Compnentss c)
    {
        throw new System.NotImplementedException();
    }
}*/