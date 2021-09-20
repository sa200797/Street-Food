using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public List<FoodType.foodtype> orderList;



    // Start is called before the first frame update
    void Start()
    {
        // put this block in for loop;

        int totalnumberoffood = (int)FoodType.foodtype.NumberOfTypes;
        int foodindex = Random.RandomRange(1, totalnumberoffood);
        Debug.Log(foodindex);
        //Debug.Log((int)FoodType.foodtype.NumberOfTypes);

        FoodType.foodtype foodType = (FoodType.foodtype)foodindex;

        Debug.Log(foodType + "??????????");

        GenrateFood(foodType);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenrateFood(FoodType.foodtype food)
    {
        switch(food)
        {
            case FoodType.foodtype.pizza:
                Debug.Log("Make pizza");
                orderList.Add(FoodType.foodtype.pizza);
                break;
            case FoodType.foodtype.vadapav:
                Debug.Log("Make VadaPav");
                orderList.Add(FoodType.foodtype.vadapav);
                break;
            case FoodType.foodtype.sandwich:
                Debug.Log("Make Sandwhich");
                orderList.Add(FoodType.foodtype.sandwich);
                break;
            default:
                break;
        }



    }
  
}
