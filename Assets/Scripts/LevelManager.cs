using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public GameObject LevelMan;
    public LevelManager levelmanager;

    [SerializeField] internal NumberOffOrder numberOffOrder;
    [SerializeField] public List<FoodType.foodtype> orderList;

    [Space(5)]
    [Space(20)]
    [Header("Two Order")]
    [SerializeField] internal bool isOrdercompleted;
    [SerializeField] List<FoodType.foodtype> TwoOrderList;
    [SerializeField] List<FoodType.foodtype> TwoOrder;
    [SerializeField] List<String> TwoNameOrder;

    //    int numberoforders = 10;
    public int ordercount = 1;

    // Start is called before the first frame update
    void Start()
    {
        //  Application.targetFrameRate = 60;
        // put this block in for loop;

        //for(int o =0; o < numberoforders; o++)
        //{
        //    int totalnumberoffood = (int)FoodType.foodtype.NumberOfTypes;
        //    int foodindex = Random.RandomRange(1, totalnumberoffood);


        //    Debug.Log(foodindex);
        //    //Debug.Log((int)FoodType.foodtype.NumberOfTypes);

        //    FoodType.foodtype foodType = (FoodType.foodtype)foodindex;

        //    Debug.Log(foodType + "??????????");

        //    GenrateFood(foodType);
        //}

        //LevelMan = GameObject.Find("LevelManager");
        //levelmanager = LevelMan.GetComponent<LevelManager>();

        isOrdercompleted = true;

        //Move this to LevelManager 
        GetOrder();

    }
    public int GetOrderCount()
    {
        return ordercount;
    }

    public void GetOrder()
    {
        if (numberOffOrder == NumberOffOrder.OneOrder)
        {
            UIOneOrderUpdate();
        }

        if (numberOffOrder == NumberOffOrder.TwoOrder)
        {
            if (isOrdercompleted == true)             
                UItwoOrderUpdate();
        }
    }

    void UItwoOrderUpdate()
    {

        UpdateOrderNumber();


        for (int i = 0; i < TwoOrder.Count; i++)
        {
            TwoOrder[i] = TwoOrderList[getIntOrder()];
        }

        String OrderString = String.Empty;
        TwoNameOrder = new List<String>();

        for (int i = 0; i < TwoOrder.Count; i++)
        {
            TwoNameOrder.Add(TwoOrder[i].ToString());
        }
        Debug.Log(OrderString);

        for (int i = 0; i < TwoNameOrder.Count; i++)
        {
            if (TwoNameOrder[i] == "VadaPav")
            {
                OrderString += " " + TwoNameOrder[i] + " " + "X" + " " + "1" + "--Rs10".ToString() + "\n";
            }
            else if (TwoNameOrder[i] == "Sandwich")
            {
                OrderString += " " + TwoNameOrder[i] + " " + "X" + " " + "1" + "--Rs30".ToString() + "\n";
            }
            else if (TwoNameOrder[i] == "Pizza") 
            {
                OrderString += " " + TwoNameOrder[i] + " " + "X" + " " + "1" + "--Rs50".ToString() + "\n";
            }
            
        }
        Debug.Log(OrderString);
        UIManager.instance.orderDetails.text = OrderString;

        isOrdercompleted = false;
    }
    
    public void UIOneOrderUpdate()
    {
        UpdateOrderNumber();
        // UIManager.instance.orderDetails.text = GetFoodName() + " " + "X" + " " + "1" + "--Rs" + 0010;
        if (orderList[0] == FoodType.foodtype.VadaPav)
        {
            UIManager.instance.orderDetails.text = GetFoodName() + " " + "X" + " " + "1" + "--Rs10".ToString();
        }
        else if (orderList[0] == FoodType.foodtype.Sandwich)
        {
            UIManager.instance.orderDetails.text = GetFoodName() + " " + "X" + " " + "1" + "--Rs30".ToString();
        }
        else if (orderList[0] == FoodType.foodtype.Pizza)
        {
            UIManager.instance.orderDetails.text = GetFoodName() + " " + "X" + " " + "1" + "--Rs50".ToString();
        }
    }
    void UpdateOrderNumber() { UIManager.instance.orderid.text = "Order No-" + " " + GetOrderCount().ToString(); }
    public void GenrateFood(FoodType.foodtype food)
    {
        switch (food)
        {
            case FoodType.foodtype.Pizza:
                Debug.Log("Make pizza");
                orderList.Add(FoodType.foodtype.Pizza);
                break;
            case FoodType.foodtype.VadaPav:
                Debug.Log("Make VadaPav");
                orderList.Add(FoodType.foodtype.VadaPav);
                break;
            case FoodType.foodtype.Sandwich:
                Debug.Log("Make Sandwhich");
                orderList.Add(FoodType.foodtype.Sandwich);
                break;
            default:
                break;
        }
    }

    int getIntOrder() { return UnityEngine.Random.Range(0, TwoOrderList.Count); }
    public string GetFoodName() { return orderList[0].ToString(); }

    [System.Serializable]
    public enum NumberOffOrder
    {
        OneOrder = 1,
        TwoOrder = 2,
        ThreeOrder = 3
    }




}
