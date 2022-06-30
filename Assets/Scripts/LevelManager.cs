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
     [SerializeField] internal NumberOffOrder1 numberOffOrder1;
    [SerializeField] public List<FoodType.foodtype> orderList;
    [SerializeField] public List<FoodType.foodtype> orderList1;

    [Space(5)]
    [Header("Two Order")]
    [Space(5)]
    [SerializeField] internal bool isOrdercompleted;
    [SerializeField] internal bool isOrdercompleted1;

    [SerializeField] List<FoodType.foodtype> TwoOrderList;
    [SerializeField] List<FoodType.foodtype> TwoOrderList1;

    [SerializeField] internal int NumerofOrder;
    [SerializeField] internal int NumerofOrder1;

    [SerializeField] List<LevelList> levelList;
    [SerializeField] List<LevelList1> levelList1;

    [SerializeField] List<LevelList> TutorialList;
    [SerializeField] internal List<String> TwoNameOrder;
     [SerializeField] internal List<String> TwoNameOrder1;
    [SerializeField] internal List<int> moneyOrder;

    [Space(10)]
    public int LevelOrderCount = 0;
    [Space(10)]
    public int LevelOrderCount1 = 0;

    public float addTime;
    public static bool freetimemodui=false;
    public static bool timemodui=false;
    public static bool cobomodeui=false;
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
        isOrdercompleted1 = true;

        //isOrdercompleted = false;

        //Move this to LevelManager 
        //GetOrder();

    }
    public int GetOrderCount()
    {
        return LevelOrderCount;
    }
     public int GetOrderCount1()
    {
        return LevelOrderCount1;
    }
 
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
     public void GetOrder1()
    {
        Debug.Log("get oder1 0");
        if (numberOffOrder1 == NumberOffOrder1.OneOrder1)
        {
            Debug.Log("get oder1 1");
            UIOneOrderUpdate1();
        }

        if (numberOffOrder1 == NumberOffOrder1.TwoOrder1)
        {
            Debug.Log("get oder1 2");
            if (isOrdercompleted1 == true)
            {
                Debug.Log("get oder1 3");
                //UItwoOrderUpdate();   
                if (GameManager.instance.isTutorialOn == true)
                {
                    Debug.Log("get oder1 4");
                    //UItwoOrderUpdate();
                    ApplyLevelIndex1(LevelOrderCount1);
                }
                else
                {
                    Debug.Log("get oder1 5");
                    //UItwoOrderUpdate();
                    ApplyLevelIndex1(LevelOrderCount1);
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
     [ContextMenu("OrderUpdate1")]
    void UItwoOrderUpdate1()
    {
        Debug.Log("UItwoOrderUpdate1");
        UpdateOrderNumber1();
        for (int j = 0; j < levelList1.Count; j++)
        {
            Debug.Log("UItwoOrderUpdate1");
            levelList1[j].TwoOrderList1 = new List<FoodType.foodtype>();
            for (int k = 0; k < NumerofOrder1; k++)
            {
                Debug.Log("UItwoOrderUpdate 1");
                levelList1[j].TwoOrderList1.Add(TwoOrderList1[getIntOrder1()]);
            }
        }

        //Level Order Count
        ApplyLevelIndex1(LevelOrderCount1);
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
        #endregion
        
        #region Normal
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
        
        
        Debug.Log(OrderString);
        UIManager.instance.orderDetails.text = OrderString;
        UIManager.instance.orderAmountDetails.text = OrderAmountString;

        int AllSum = moneyOrder.Take(moneyOrder.Count).Sum();
        UIManager.instance.TotalorderAmount.text = AllSum.ToString();

        isOrdercompleted = false;
        #endregion
    }
    //Hiral
     public void ApplyLevelIndex1(int LevelIndex1)
    {
        Debug.Log("called 1");

        String OrderString = String.Empty;
        String OrderAmountString = String.Empty;
        TwoNameOrder1 = new List<String>();
        moneyOrder = new List<int>();
        //Debug.Log("called 2");

        #region Tutorial
        // Tutorial 
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
                    TwoNameOrder1.Add(TutorialList[j].TwoOrderList[k].ToString());
                }
            }
            Debug.Log(OrderString);
            UIManager.instance.orderDetails.text = OrderString;
            UIManager.instance.orderAmountDetails.text = OrderAmountString;
            isOrdercompleted1 = false;
            return;
        }
        #endregion
        
        #region Normal
            Debug.Log("Not Tutorial");
            // Debug.Log("Normal Ismods" + isMods);
            for (int i = 0; i < levelList1[LevelIndex1].TwoOrderList1.Count; i++)
            {
                Debug.Log("Normal1 1");
                if (levelList1[LevelIndex1].TwoOrderList1[i] == FoodType.foodtype.VadaPav)
                {
                    Debug.Log("Normal1 2");

                    moneyOrder.Add(10);
                    //OrderString += levelList[LevelIndex].TwoOrderList[i] + " " + "X" + " " + "1" + "--Rs10".ToString() + "\n";
                    OrderString += levelList1[LevelIndex1].TwoOrderList1[i] + "\n";
                    OrderAmountString += 10 + "\n";
                }
                else if (levelList1[LevelIndex1].TwoOrderList1[i] == FoodType.foodtype.Sandwich)
                {   
                    Debug.Log("Normal1 3");

                    moneyOrder.Add(30);
                    //OrderString += levelList[LevelIndex].TwoOrderList[i] + " " + "X" + " " + "1" + "--Rs30".ToString() + "\n";
                    OrderString += levelList1[LevelIndex1].TwoOrderList1[i].ToString() + "\n";
                    OrderAmountString += 30 + "\n";
                }
                else if (levelList1[LevelIndex1].TwoOrderList1[i] == FoodType.foodtype.Pizza)
                {
                    Debug.Log("Normal1 4");

                    moneyOrder.Add(50);
                    //OrderString += levelList[LevelIndex].TwoOrderList[i] + " " + "X" + " " + "1" + "--Rs50".ToString() + "\n";
                    OrderString += levelList1[LevelIndex1].TwoOrderList1[i].ToString() + "\n";
                    OrderAmountString += 50 + "\n";
                }
                TwoNameOrder1.Add(levelList1[LevelIndex1].TwoOrderList1[i].ToString());
            }
        
        
        Debug.Log(OrderString);
        UIManager.instance.orderDetails.text = OrderString;
        UIManager.instance.orderAmountDetails.text = OrderAmountString;

        int AllSum = moneyOrder.Take(moneyOrder.Count).Sum();
        UIManager.instance.TotalorderAmount.text = AllSum.ToString();

        isOrdercompleted1 = false;
        #endregion
    }
    public void OnLevelCompleted()
    {

    }
    public void OnTutorialBtn()
    {
       // Debug.Log("Tutorial Btn Click");
        PlayerPrefs.SetInt("isMods", 1);
       // isMods = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void OnFreeTimeModsBtn()
    {
        Debug.Log("OnFreeTimeMods Btn Click");
       GameSetting.Instance.doneTutorial = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameSetting.Instance.checkFreeTimeMods = true;
        freetimemodui=true                                                               ;
          MainPannel.Instance.takeMultipleOrderTime.SetActive(false);
            MainPannel.Instance.takeMultipleOrderCombo.SetActive(false);
        MainPannel.Instance.takeMultipleOrder.SetActive(true);
      
    }
    public void OnTimeModsBtn()
    {
      //  Debug.Log("OnFreeTimeMods Btn Click");
        GameSetting.Instance.doneTutorial = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameSetting.Instance.timeMods = true;
        timemodui=true;
        MainPannel.Instance.takeMultipleOrder.SetActive(false);
          MainPannel.Instance.takeMultipleOrderCombo.SetActive(false);
        MainPannel.Instance.takeMultipleOrderTime.SetActive(true);
    }

    public void OnComboModsBtn()
    {
        Debug.Log("OnComboModsbtn");
        GameSetting.Instance.doneTutorial = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        GameSetting.Instance.comboMods = true;
         cobomodeui=true;
         MainPannel.Instance.takeMultipleOrderTime.SetActive(false);
          MainPannel.Instance.takeMultipleOrder.SetActive(false);
        MainPannel.Instance.takeMultipleOrderCombo.SetActive(true);
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
     public void UIOneOrderUpdate1()
    {
        UpdateOrderNumber1();
        // UIManager.instance.orderDetails.text = GetFoodName() + " " + "X" + " " + "1" + "--Rs" + 0010;
        if (orderList1[0] == FoodType.foodtype.VadaPav)
        {
            UIManager.instance.orderDetails.text = GetFoodName1() + " " + "X" + " " + "1" + "--Rs10".ToString();
        }
        else if (orderList1[0] == FoodType.foodtype.Sandwich)
        {
            UIManager.instance.orderDetails.text = GetFoodName1() + " " + "X" + " " + "1" + "--Rs30".ToString();
        }
        else if (orderList1[0] == FoodType.foodtype.Pizza)
        {
            UIManager.instance.orderDetails.text = GetFoodName1() + " " + "X" + " " + "1" + "--Rs50".ToString();
        }
    }
    void UpdateOrderNumber() { UIManager.instance.orderid.text = "Order No-" + " " + GetOrderCount().ToString(); }
    void UpdateOrderNumber1() { UIManager.instance.orderid.text = "Order Num-" + " " + GetOrderCount1().ToString(); }
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
     int getIntOrder1() { return UnityEngine.Random.Range(0, TwoOrderList1.Count); }
    public string GetFoodName() { return orderList[0].ToString(); }
    public string GetFoodName1() { return orderList1[0].ToString(); }

    [System.Serializable]
    public enum NumberOffOrder
    {
        OneOrder = 1,
        TwoOrder = 2
    }
     public enum NumberOffOrder1
    {
        OneOrder1 = 1,
        TwoOrder1 = 2
    }

    [System.Serializable]
    public class LevelList
    {
        public List<FoodType.foodtype> TwoOrderList;
    }
      [System.Serializable]
    public class LevelList1
    {
        public List<FoodType.foodtype> TwoOrderList1;
    }
}