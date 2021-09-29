using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FoodType", menuName = "FoodType", order = 0)]
public class FoodType : ScriptableObject
{

    
    public enum foodtype
    {
        VadaPav =1,
        Sandwich =2,
        Pizza =3,
        NumberOfTypes  //to get the number of elements
    }

   

    public foodtype f_type;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
