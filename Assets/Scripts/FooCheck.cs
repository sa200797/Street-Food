﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FooCheck : MonoBehaviour
{
    // public Transform dropppoint;

    // public GameObject prefab;

    // public GameObject[] items;

    public static FooCheck instance;


    public int foodvalue;


    [SerializeField]
    public int Foodvalue
    {
        get { return foodvalue ; }
        set { foodvalue = value; }
    }
  

    private void Awake()
    {
       
    }



    //private void OnMouseDown()
    //{

    //   GameObject vada = (GameObject)Instantiate(prefab, dropppoint.transform.position, Quaternion.identity);   


    //}
}