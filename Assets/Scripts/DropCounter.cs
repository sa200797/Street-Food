﻿using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class DropCounter : MonoBehaviour
{

    public GameObject LevelMan;
    public LevelManager levelmanager;

    [SerializeField] int OrderIndex;
    [SerializeField] LevelManager.NumberOffOrder numberOffOrder;

    bool move;

    public static int ordervalidity;
    public Transform transformPoint;

    [SerializeField] int score;
    [Header("Drop Objects")]
    [SerializeField]
    GameObject foodParcel;
    [SerializeField]
    GameObject pizzaBox;
    [SerializeField] int itemtype = 0;

    [Space(20)]
    [SerializeField] List<GameObject> Point;

    [SerializeField] List<String> OrderName;

    [Space(20)]
    [SerializeField] internal UnityEvent OnOrderCompleted;
    [SerializeField] internal UnityEvent OnOrderWrong;

    [SerializeField] Vector3 Position;
    [SerializeField] List<GameObject> visualiz;
    [SerializeField] [Range(0, 10)] float pathObject;
    [SerializeField] GameObject dustbin;
    [SerializeField] List<GameObject> pathHoder;
    Timer GetTime;

    public GameObject character;
     public GameObject[] ship;
     public Vector3 spawnPosition;
     
      Vector3 pos;
    void Awake()
    {
        SetupPoint();
    }

    private void SetupPoint()
    {
        numberOffOrder = GameObject.Find("LevelManager").GetComponent<LevelManager>().numberOffOrder;
        if (numberOffOrder == LevelManager.NumberOffOrder.OneOrder)
        {
            if (Point[0] != null)
            {
                Point[0].gameObject.SetActive(true);
            }
        }
        else if (numberOffOrder == LevelManager.NumberOffOrder.TwoOrder)
        {
            for (int i = 0; i < Point.Count; i++)
            {
                Point[i].gameObject.SetActive(true);
            }
        }
    }

    void Start()
    {

        LevelMan = GameObject.Find("LevelManager");
        levelmanager = LevelMan.GetComponent<LevelManager>();
        move = true;

        GetTime = FindObjectOfType<Timer>();
        visualiz = new List<GameObject>();
        //Move this to LevelManager 
        //levelmanager.UiUpdate();
       character.SetActive(true);
        // int i = Random.Range(0,ship.Length);
         
        // Instantiate(ship[i],spawnPosition, Quaternion.Euler(new Vector3(0, 180, 0)));
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (numberOffOrder == LevelManager.NumberOffOrder.OneOrder)
        {
            if (collision.gameObject.CompareTag("C_Vadapav"))
            {
                GameManager.amount = 10;
               // Debug.Log("VadaPawComplete2");
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
               // Debug.Log("Sandwich Complete");
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
              //  Debug.Log("Pizza Complete");
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
          //  Debug.Log("Two Name"); 
            if (collision.gameObject.CompareTag("C_Vadapav"))
            {
                GameManager.amount = 10;
               // Debug.Log("VadaPawComplete2");
                GameManager.vadaitemspawn = false;
                GameManager.vadapawcount = 0;

                ContactPoint contact = collision.contacts[0];
                visualization(collision.gameObject, "VadaPav", contact);
                Destroy(collision.gameObject);

                //collision.gameObject.SetActive(false);                                
                //CheckFood(FoodType.foodtype.sandwich);
                //MakeFood();
                //MakeFood(FoodType.foodtype.Sandwich);
                // TostSandwich.active_sandcol = true;
                //TostSandwich.sandwich_coll.enabled = true;

                //Pizza
                //Sandwich
                //VadaPav

                CheckOrdar("VadaPav");
            }
            if (collision.gameObject.CompareTag("C_Sandwich"))
            {
                GameManager.amount = 30;
                Debug.Log("Sandwich Complete");
                GameManager.sandwichitemsspawn = false;
                GameManager.sandwichcount = 0;

                ContactPoint contact = collision.contacts[0];
                visualization(collision.gameObject, "Sandwich", contact);
                Destroy(collision.gameObject);

                //collision.gameObject.SetActive(false);                                
                //CheckFood(FoodType.foodtype.sandwich);
                //MakeFood();
                //MakeFood(FoodType.foodtype.Sandwich);
                //TostSandwich.active_sandcol = true;

                TostSandwich.sandwich_coll.enabled = true;
                CheckOrdar("Sandwich");

            }
            if (collision.gameObject.CompareTag("C_Pizza"))
            {
                GameManager.amount = 50;
               // Debug.Log("Pizza Complete");    
                GameManager.pizzaitemspawn = false;
                GameManager.pizzacount = 0;

                ContactPoint contact = collision.contacts[0];
                visualization(collision.gameObject, "Pizza", contact);
                Destroy(collision.gameObject);

                //collision.gameObject.SetActive(false);                                
                //CheckFood(FoodType.foodtype.sandwich);
                //MakeFood();
                //MakeFood(FoodType.foodtype.Sandwich);
                //TostSandwich.active_sandcol = true;
                //TostSandwich.sandwich_coll.enabled = true;

                CheckOrdar("Pizza");

            }
        }
    }

    void visualization(GameObject Hits, string ObjectName, ContactPoint contact)
    {
        Debug.Log("is Work");
        Position = Hits.transform.position;

        if (ObjectName == "VadaPav" || ObjectName == "Sandwich")
        {
            GameObject GenratedObject = Instantiate(foodParcel, contact.point, Quaternion.identity) as GameObject;
            GenratedObject.transform.localPosition = contact.point;
            GenratedObject.SetActive(true);

            Transform parent = null;
            for (int i = 0; i < Point.Count; i++)
            {
                if (Point[i].transform.childCount == 0)
                {
                    parent = Point[i].transform;
                    break;
                }
            }
            GenratedObject.transform.SetParent(parent);
            GenratedObject.transform.DOScale(1.85f, 0);
            GenratedObject.transform.DOLocalMove(Vector3.zero, 0.8f).onComplete += delegate { OnOrderDropOnMainPlatform(ObjectName); };
            visualiz.Add(GenratedObject);
        }
        else if (ObjectName == "Pizza")
        {
            GameObject GenratedObject = Instantiate(pizzaBox, contact.point, Quaternion.identity) as GameObject;
            GenratedObject.transform.localPosition = contact.point;
            GenratedObject.SetActive(true);

            Transform parent = null;
            for (int i = 0; i < Point.Count; i++)
            {
                if (Point[i].transform.childCount == 0)
                {
                    parent = Point[i].transform;
                    break;
                }
            }
            GenratedObject.transform.SetParent(parent);
            GenratedObject.transform.DOScale(10, 0);
            GenratedObject.transform.DOLocalMove(new Vector3(0, 0.25f, 0), 0.8f).onComplete += delegate { OnOrderDropOnMainPlatform(ObjectName); };
            visualiz.Add(GenratedObject);
        }

    }

    void OnOrderDropOnMainPlatform(string ObjectName)
    {
        //Debug.Log("ObjectName :  " + ObjectName + " is good");

        if (GameManager.instance.isTutorialOn == false)
        {
            return;
        }

        if (ObjectName == "VadaPav")
        {
            LevelManager.levelmanager.numberOffOrder = LevelManager.NumberOffOrder.TwoOrder;
            LevelManager.levelmanager.GetOrder();
            Tutorial.tutorial.SetupSaggatation(1);
            Tutorial.tutorial.OrderIndex = 0;
            Tutorial.tutorial.SetupOrderIndexSaggatation();

        //    Debug.Log("is work in");
        }

        if (ObjectName == "Sandwich")
        {
          //  Debug.Log("ObjectName : " + ObjectName + "is work in");
            LevelManager.levelmanager.numberOffOrder = LevelManager.NumberOffOrder.TwoOrder;
            LevelManager.levelmanager.GetOrder();
            Tutorial.tutorial.SetupSaggatation(2);
            Tutorial.tutorial.OrderIndex = 0;
            Tutorial.tutorial.SetupOrderIndexSaggatation();
        }
        if (ObjectName == "Pizza")
        {

            if (PlayerPrefs.HasKey("TutorialOneTime") == true)          
            {
              //  Debug.Log("Pizza Pizza");
                PlayerPrefs.SetInt("TutorialOneTime", 1);
            }
            //SceneManager.LoadScene(2);
          SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Debug.Log("GetActiveSceneName :"+ SceneManager.GetActiveScene().name);
          //  Debug.Log("123");
        }

    }

    void CheckOrdar(String OrderNames)
    {
        if (OrderIndex != LevelManager.levelmanager.NumerofOrder)
        {
            OrderName.Add(OrderNames);
            OrderIndex++;
        }
        if (OrderIndex == LevelManager.levelmanager.NumerofOrder)
        {
            OrderIsCompleted();
            Debug.Log("One User Order Complelete");
        }
    }

    IEnumerator visualizReset()
    {
        for (int i = 0; i < visualiz.Count; i++)
        {
            yield return new WaitForSeconds(0.1f);
            visualiz[i].transform.DOScale(0, 0.1f).onComplete += delegate { Destroy(visualiz[i].gameObject); };
        }
    }

    void OrderIsCompleted()
    {
        SoundManager.instance.SoundPlay_OC();

        var isWin = Enumerable.SequenceEqual(OrderName.OrderBy(t => t), levelmanager.TwoNameOrder.OrderBy(t => t));
        Debug.Log(" isWin : " + isWin);
        character.SetActive(false);
        int i = Random.Range(0,ship.Length);
         Instantiate(ship[i],spawnPosition, Quaternion.Euler(new Vector3(0, 180, 0)));

        if (isWin == true)
        {
            /*score += GameManager.amount;
            SavaData.instance.money = score;
            UIManager.instance.totalAmoumt.text = score.ToString();*/
            var Amount = GameObject.Find("LevelManager").GetComponent<LevelManager>().moneyOrder;
            int sum = Amount.Take(Amount.Count).Sum();
            GameManager.instance.CoinAddBalance(sum);

            //time add up on Order Completed
            GameManager.instance.AddTime(sum);

            StartCoroutine(visualizReset());

            levelmanager.LevelOrderCount++;
            SavaData.instance.ordercount = levelmanager.LevelOrderCount - 1;

            OrderIndex = 0;
            ordervalidity = 1;
            UIManager.instance.ordercomplete.text = "Order Complete!! Thankyou ";
            UIManager.instance.ChangeMaterial();
            StartCoroutine(FoodDropComplete());
            // StartCoroutine(IncreaseLevel());
            //Invoke("IncreaseLevel", 1.0f);
            UIManager.instance.ChangeMaterial();

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
            OrderName.Clear();
            OnOrderCompleted.Invoke();
            return;
        }

        if (isWin == false)
        {
            Debug.Log("Wrong Food");
            ordervalidity = 2;
            UIManager.instance.ordercomplete.text = "Wrong Order Delivered";
            UIManager.instance.ChangeMaterial();

            StartCoroutine(FoodDropComplete());
            //StartCoroutine(visualizReset());

            OrderName.Clear();
            OrderIndex = 0;

            //pathHoders();
            StartCoroutine(pathHoders());

            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            OnOrderWrong.Invoke();

        }

    }
    IEnumerator pathHoders()
    {
        for (int i = 0; i < visualiz.Count; i++)
        {
            for (int j = 0; j < pathHoder.Count; j++)
            {
                if (i == visualiz.Count - 1 && j == pathHoder.Count - 1)
                {
                    visualiz[i].transform.DOMove(pathHoder[j].transform.position, 0.2f).onComplete += delegate { Destroy(visualiz[i].gameObject); };
                }
                else
                {
                    visualiz[i].transform.DOMove(pathHoder[j].transform.position, 0.2f);
                }

                yield return new WaitForSeconds(0.2f);
            }
        }
    }

    void OnValidate()
    {
        if (pathHoder.Count != 0)
        {
            for (int i = 0; i < pathHoder.Count; i++)
            {
                pathHoder[i].transform.localScale = new Vector3(pathObject, pathObject, pathObject);
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

            levelmanager.LevelOrderCount++;
            SavaData.instance.ordercount = levelmanager.LevelOrderCount - 1;
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
        yield return new WaitForSeconds(4.0f);
        levelmanager.isOrdercompleted = true;
        levelmanager.GetOrder();
        UIManager.instance.ordercomplete.text = "New Order";
        ordervalidity = 0;
        foodParcel.SetActive(false);
        pizzaBox.SetActive(false);
        itemtype = 0;
        yield return new WaitForSeconds(4.0f);
        UIManager.instance.ordercomplete.text = "";
        // UIManager.instance.ChangeMaterial();
    }
    public void MakeStartingFood()
    {
        //  levelmanager.orderList.Contains(checkfood)
    }
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