using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

   
    public List<FoodType.foodtype> orderList;

//    int numberoforders = 10;

    public int ordercount =1;
  


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



    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public int GetOrderCount()
    {
        return ordercount;
    }

    public string GetFoodName()
    {
        return orderList[0].ToString();
    }


    public void UiUpdate()
    {
        UIManager.instance.orderid.text = "Order No-" + " " + GetOrderCount().ToString();

        // UIManager.instance.orderDetails.text = GetFoodName() + " " + "X" + " " + "1" + "--Rs" + 0010;

        if (orderList[0] == FoodType.foodtype.VadaPav)
        {
            UIManager.instance.orderDetails.text = GetFoodName() + " " + "X" + " " + "1" + "--Rs10".ToString();
            //Debug.Log("10-----------");
        }
        else if (orderList[0] == FoodType.foodtype.Sandwich)
        {
            UIManager.instance.orderDetails.text = GetFoodName() + " " + "X" + " " + "1" + "--Rs30".ToString();
           // Debug.Log("30-----------");
        }
        else if (orderList[0] == FoodType.foodtype.Pizza)
        {
            UIManager.instance.orderDetails.text = GetFoodName() + " " + "X" + " " + "1" + "--Rs50".ToString();
            
        }
    }
    public void GenrateFood(FoodType.foodtype food)
    {
        switch(food)
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
    
   
    
}
