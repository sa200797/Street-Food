using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="IngredienData", menuName = "IndredientData",order =0)]
public class IngredientData : ScriptableObject
{
    public FoodType type;


    public GameObject[] foodIngredient;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
