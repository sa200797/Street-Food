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
    [Header("Two Order")]
    [Space(5)]
    [SerializeField] internal bool isOrdercompleted;
    [SerializeField] List<FoodType.foodtype> TwoOrderList;
    [SerializeField] List<LevelList> levelList;
    [SerializeField] internal List<String> TwoNameOrder;

    [Space(10)]
    public int LevelOrderCount = 0;

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
        return LevelOrderCount;
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
            {
                //UItwoOrderUpdate();
                ApplyLevelIndex(LevelOrderCount);
            }
        }
    }
    [ContextMenu("OrderUpdate")]
    void UItwoOrderUpdate()
    {
        UpdateOrderNumber();
        for (int j = 0; j < levelList.Count; j++)
        {
            for (int i = 0; i < levelList[j].TwoOrderList.Count; i++)
            {
                levelList[j].TwoOrderList[i] = TwoOrderList[getIntOrder()];
            }
        }

        //Level Order Count
        ApplyLevelIndex(LevelOrderCount);
    }

    public void ApplyLevelIndex(int LevelIndex)
    {
        String OrderString = String.Empty;
        TwoNameOrder = new List<String>();

        for (int i = 0; i < levelList[LevelIndex].TwoOrderList.Count; i++)
        {
            if (levelList[LevelIndex].TwoOrderList[i] == FoodType.foodtype.VadaPav)
            {
                OrderString += levelList[LevelIndex].TwoOrderList[i] + " " + "X" + " " + "1" + "--Rs10".ToString() + "\n";
            }
            else if (levelList[LevelIndex].TwoOrderList[i] == FoodType.foodtype.Sandwich)
            {
                OrderString += levelList[LevelIndex].TwoOrderList[i] + " " + "X" + " " + "1" + "--Rs30".ToString() + "\n";
            }
            else if (levelList[LevelIndex].TwoOrderList[i] == FoodType.foodtype.Pizza)
            {
                OrderString += levelList[LevelIndex].TwoOrderList[i] + " " + "X" + " " + "1" + "--Rs50".ToString() + "\n";
            }
            TwoNameOrder.Add(levelList[LevelIndex].TwoOrderList[i].ToString());
        }
        Debug.Log(OrderString);
        UIManager.instance.orderDetails.text = OrderString;
        isOrdercompleted = false;
    }
    public void OnLevelCompleted() { }
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

    [System.Serializable]
    public class LevelList
    {
        public List<FoodType.foodtype> TwoOrderList;
    }



}
