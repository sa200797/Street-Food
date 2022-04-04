using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager levelmanager;
    [SerializeField] internal NumberOffOrder numberOffOrder;
    [SerializeField] public List<FoodType.foodtype> orderList;

    [Space(5)]
    [Header("Two Order")]
    [Space(5)]
    [SerializeField] internal bool isOrdercompleted;
    [SerializeField] List<FoodType.foodtype> TwoOrderList;
    [SerializeField] internal int NumerofOrder;
    [SerializeField] List<LevelList> levelList;
    [SerializeField] List<LevelList> TutorialList;
    [SerializeField] internal List<String> TwoNameOrder;
    [SerializeField] internal List<int> moneyOrder;

    [Space(10)]
    public int LevelOrderCount = 0;

    //public bool isMods =true;
    void Awake()
    {
        if (levelmanager == null)
        {
            levelmanager = this;
        }
    }
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
        //isOrdercompleted = false;

        //Move this to LevelManager 
        //GetOrder();

    }
    public int GetOrderCount()
    {
        return LevelOrderCount;
    }
    /*public void tutorial()
    {
        String OrderString = String.Empty;
        String OrderAmountString = String.Empty;
        TwoNameOrder = new List<String>();
        moneyOrder = new List<int>();
        Debug.Log("called 2");
        Debug.Log("isTutorialOn : " + GameManager.instance.isTutorialOn);
        // Tutorial 
        if (GameManager.instance.isTutorialOn == true)
        {
            Debug.Log("called 3");

            for (int j = 0; j < TutorialList.Count; j++)
            {
                Debug.Log("called 4");
                Debug.Log("Tutorial");
                for (int k = 0; k < TutorialList[j].TwoOrderList.Count; k++)
                {
                    Debug.Log("called 5");

                    Debug.Log("Tutorial" + TutorialList[j].TwoOrderList[k]);

                    if (TutorialList[j].TwoOrderList[k] == FoodType.foodtype.VadaPav)
                    {
                        Debug.Log("called 6");

                        moneyOrder.Add(10);
                        //OrderString += TutorialList[j].TwoOrderList[k] + " " + "X" + " " + "1" + "--Rs10".ToString() + "\n";
                        OrderString += TutorialList[j].TwoOrderList[k].ToString() + "\n";
                    }
                    else if (TutorialList[j].TwoOrderList[k] == FoodType.foodtype.Sandwich)
                    {
                        moneyOrder.Add(30);
                        //OrderString += TutorialList[j].TwoOrderList[k] + " " + "X" + " " + "1" + "--Rs30".ToString() + "\n";
                        OrderString += TutorialList[j].TwoOrderList[k].ToString() + "\n";
                    }
                    else if (TutorialList[j].TwoOrderList[k] == FoodType.foodtype.Pizza)
                    {
                        moneyOrder.Add(50);
                        //OrderString += TutorialList[j].TwoOrderList[k] + " " + "X" + " " + "1" + "--Rs50".ToString() + "\n";
                        OrderString += TutorialList[j].TwoOrderList[k].ToString() + "\n";
                    }
                    TwoNameOrder.Add(TutorialList[j].TwoOrderList[k].ToString());
                }
            }
            Debug.Log(OrderString);
            UIManager.instance.orderDetails.text = OrderString;
            UIManager.instance.orderAmountDetails.text = OrderAmountString;
            isOrdercompleted = false;
            return;
        }
    }*/
    public void GetOrder()
    {
        Debug.Log("get oder");
        if (numberOffOrder == NumberOffOrder.OneOrder)
        {
            Debug.Log("get oder 1");
            UIOneOrderUpdate();
        }

        if (numberOffOrder == NumberOffOrder.TwoOrder)
        {
            Debug.Log("get oder 2");
            if (isOrdercompleted == true)
            {
                Debug.Log("get oder 3");
                //UItwoOrderUpdate();
                if (GameManager.instance.isTutorialOn == true)
                {
                    Debug.Log("get oder 4");
                    //UItwoOrderUpdate();
                    ApplyLevelIndex(LevelOrderCount);
                }
                else
                {
                    Debug.Log("get oder 5");
                    //UItwoOrderUpdate();
                    ApplyLevelIndex(LevelOrderCount);
                }
            }
        }
    }
    [ContextMenu("OrderUpdate")]
    void UItwoOrderUpdate()
    {
        Debug.Log("UItwoOrderUpdate");
        UpdateOrderNumber();
        for (int j = 0; j < levelList.Count; j++)
        {
            Debug.Log("UItwoOrderUpdate");
            levelList[j].TwoOrderList = new List<FoodType.foodtype>();
            for (int k = 0; k < NumerofOrder; k++)
            {
                Debug.Log("UItwoOrderUpdate 1");
                levelList[j].TwoOrderList.Add(TwoOrderList[getIntOrder()]);
            }
        }

        //Level Order Count
        ApplyLevelIndex(LevelOrderCount);
    }
    public void ApplyLevelIndex(int LevelIndex)
    {
        Debug.Log("called 1");

        String OrderString = String.Empty;
        String OrderAmountString = String.Empty;
        TwoNameOrder = new List<String>();
        moneyOrder = new List<int>();
        //Debug.Log("called 2");

        #region Tutorial
        // Tutorial 
        if (PlayerPrefs.GetInt("isMods")==1)
        {
            PlayerPrefs.SetInt("isMods", 0);

            Debug.Log("Tutorial");
            if (GameManager.instance.isTutorialOn == true)
            {
                Debug.Log("Tutorial");
                Debug.Log("called 3");

                for (int j = 0; j < TutorialList.Count; j++)
                {
                    Debug.Log("called 4");
                    Debug.Log("Tutorial");
                    for (int k = 0; k < TutorialList[j].TwoOrderList.Count; k++)
                    {
                        Debug.Log("called 5");

                        Debug.Log("Tutorial" + TutorialList[j].TwoOrderList[k]);

                        if (TutorialList[j].TwoOrderList[k] == FoodType.foodtype.VadaPav)
                        {
                            Debug.Log("called 6");

                            moneyOrder.Add(10);
                            //OrderString += TutorialList[j].TwoOrderList[k] + " " + "X" + " " + "1" + "--Rs10".ToString() + "\n";
                            OrderString += TutorialList[j].TwoOrderList[k].ToString() + "\n";
                        }
                        else if (TutorialList[j].TwoOrderList[k] == FoodType.foodtype.Sandwich)
                        {
                            moneyOrder.Add(30);
                            //OrderString += TutorialList[j].TwoOrderList[k] + " " + "X" + " " + "1" + "--Rs30".ToString() + "\n";
                            OrderString += TutorialList[j].TwoOrderList[k].ToString() + "\n";
                        }
                        else if (TutorialList[j].TwoOrderList[k] == FoodType.foodtype.Pizza)
                        {
                            moneyOrder.Add(50);
                            //OrderString += TutorialList[j].TwoOrderList[k] + " " + "X" + " " + "1" + "--Rs50".ToString() + "\n";
                            OrderString += TutorialList[j].TwoOrderList[k].ToString() + "\n";
                        }
                        TwoNameOrder.Add(TutorialList[j].TwoOrderList[k].ToString());
                    }
                }
                Debug.Log(OrderString);
                UIManager.instance.orderDetails.text = OrderString;
                UIManager.instance.orderAmountDetails.text = OrderAmountString;
                isOrdercompleted = false;
                return;
            }
        }
        #endregion
        
        #region Normal
        else if (PlayerPrefs.GetInt("isMods")==0)
        {
            Debug.Log("Not Tutorial");
            // Debug.Log("Normal Ismods" + isMods);
            for (int i = 0; i < levelList[LevelIndex].TwoOrderList.Count; i++)
            {
                Debug.Log("Normal 1");
                if (levelList[LevelIndex].TwoOrderList[i] == FoodType.foodtype.VadaPav)
                {
                    Debug.Log("Normal 2");

                    moneyOrder.Add(10);
                    //OrderString += levelList[LevelIndex].TwoOrderList[i] + " " + "X" + " " + "1" + "--Rs10".ToString() + "\n";
                    OrderString += levelList[LevelIndex].TwoOrderList[i] + "\n";
                    OrderAmountString += 10 + "\n";
                }
                else if (levelList[LevelIndex].TwoOrderList[i] == FoodType.foodtype.Sandwich)
                {
                    Debug.Log("Normal 3");

                    moneyOrder.Add(30);
                    //OrderString += levelList[LevelIndex].TwoOrderList[i] + " " + "X" + " " + "1" + "--Rs30".ToString() + "\n";
                    OrderString += levelList[LevelIndex].TwoOrderList[i].ToString() + "\n";
                    OrderAmountString += 30 + "\n";
                }
                else if (levelList[LevelIndex].TwoOrderList[i] == FoodType.foodtype.Pizza)
                {
                    Debug.Log("Normal 4");

                    moneyOrder.Add(50);
                    //OrderString += levelList[LevelIndex].TwoOrderList[i] + " " + "X" + " " + "1" + "--Rs50".ToString() + "\n";
                    OrderString += levelList[LevelIndex].TwoOrderList[i].ToString() + "\n";
                    OrderAmountString += 50 + "\n";
                }
                TwoNameOrder.Add(levelList[LevelIndex].TwoOrderList[i].ToString());
            }
        }
        Debug.Log(OrderString);
        UIManager.instance.orderDetails.text = OrderString;
        UIManager.instance.orderAmountDetails.text = OrderAmountString;

        int AllSum = moneyOrder.Take(moneyOrder.Count).Sum();
        UIManager.instance.TotalorderAmount.text = AllSum.ToString();

        isOrdercompleted = false;
        #endregion
    }
    public void OnLevelCompleted()
    {

    }
    public void OnTutorialBtn()
    {
        Debug.Log("Tutorial Btn Click");
        PlayerPrefs.SetInt("isMods", 1);
       // isMods = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void OnFreeTimeModsBtn()
    {
        Debug.Log("OnFreeTimeMods Btn Click");
        //isMods = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
        TwoOrder = 2
    }

    [System.Serializable]
    public class LevelList
    {
        public List<FoodType.foodtype> TwoOrderList;
    }
}