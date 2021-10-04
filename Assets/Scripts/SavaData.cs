﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavaData : MonoBehaviour
{
    public static SavaData instance;

    string odercount_key="odercount_key";
    string totalmoney_key = "toalmoney_key";

    public int ordercount;
    public int money;

    int higestorders =0;
    int totalmoney =0;
    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

    }
    // Start is called before the first frame update
    void Start()
    {
      if(PlayerPrefs.HasKey(odercount_key))
        {
            GetInt(odercount_key);
            Debug.Log(GetInt(odercount_key)+ "GGG");
        }
      else
        {
            SetInt(odercount_key,higestorders);
            
      }



      if(PlayerPrefs.HasKey(totalmoney_key))
        {
            GetInt(totalmoney_key);
        }
      else
        {
            SetInt(totalmoney_key, totalmoney);
        }

    }

    public int TotalOrderCompleted()
    {
        
        return ordercount;
    }   

    public int TotalAmount()
    {
        //score = totalamount;
        return money;
    }


    public void SetInt(string keyname, int value)
    {
        PlayerPrefs.SetInt(keyname, value);
    }

    public int GetInt(string keyname)
    {
        return PlayerPrefs.GetInt(keyname);
    }

    private void Update()
    {
        
    }

    public void Save_TotalOrdrsandDisplay()
    {
        if (ordercount > GetInt(odercount_key))
        {
            higestorders += ordercount;
            SetInt(odercount_key, higestorders);
            Debug.Log(GetInt(odercount_key) + "---------------");
        }
        else
        {
            Debug.Log(GetInt(odercount_key) + "//////");
        }
    }


    public void Save_TotalMoney()
    {

        totalmoney = GetInt(totalmoney_key);
        totalmoney = totalmoney + money;
        SetInt(totalmoney_key, totalmoney);
        GetInt(totalmoney_key);
        Debug.Log(GetInt(totalmoney_key));
    }

}