using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="IngredienData", menuName = "IndredientData",order =0)]
public class IngredientData : ScriptableObject
{
    public IngredientType type;

    [Header("Visuals")]
    public Mesh Mesh;



    [Tooltip("UI Usage")]
    public Sprite sprite;
     

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
