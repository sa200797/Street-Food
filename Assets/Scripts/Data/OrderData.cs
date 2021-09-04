﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OrderData",menuName ="OrderData", order =0)]
public class OrderData : ScriptableObject
{
    public List<IngredientData> ingredients;
}
