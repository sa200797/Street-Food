using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavaData : MonoBehaviour
{
    public static SavaData instance;

    public int ordercount;
    public int money;

    //higestorders
    //total money
    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
      
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
}
