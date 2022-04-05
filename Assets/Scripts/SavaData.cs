using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavaData : MonoBehaviour
{
    public static SavaData instance;

    string odercount_key = "odercount_key";
    string totalmoney_key = "toalmoney_key";

    public int ordercount;
    public int money;

    [SerializeField] int higestorders = 0;
    [SerializeField] int totalmoney = 0;

    [SerializeField] int CurrountMoney;

    private void Awake()
    {
        if (instance == null)
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
        if (PlayerPrefs.HasKey(odercount_key))
        {
            GetInt(odercount_key);
            Debug.Log(GetInt(odercount_key) + "GGG");
        }
        else
        {
            SetInt(odercount_key, higestorders);
        }

        if (PlayerPrefs.HasKey(totalmoney_key))
        {
            GetInt(totalmoney_key);
        }
        else
        {
            SetInt(totalmoney_key, totalmoney);
        }
        updataMoney();
    }

    void updataMoney() 
    {
        Debug.Log("odercount_key : " + GetInt(odercount_key));
        Debug.Log("totalmoney_key : " + GetInt(totalmoney_key));

        UIManager.instance.CurrountBalance.SetText(GetInt(totalmoney_key).ToString());
        CurrountMoney = GetInt(totalmoney_key);
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
        Debug.Log("KEYNAME : " + keyname);
        return PlayerPrefs.GetInt(keyname);
    }
    
    public string Save_TotalOrdrsandDisplay()
    {
        if (ordercount > GetInt(odercount_key))
        {
            higestorders += ordercount;
            SetInt(odercount_key, higestorders);
            GetInt(odercount_key);
            Debug.Log(GetInt(odercount_key) + "---------------");
        }
        else
        {
            Debug.Log(GetInt(odercount_key) + "//////");
        }
        string to = GetInt(odercount_key).ToString();
        return to;
    }

    public void AddMoney(int CoinAmount)
    {
        var newMoneyAmount= GetInt(totalmoney_key) + CoinAmount;
        SetInt(totalmoney_key, newMoneyAmount);
        updataMoney();
    }

    [ContextMenu("Save Money")]
    public int Save_TotalMoney()
    {
        if (money > GetInt(totalmoney_key))
        {
            totalmoney += money;
            SetInt(totalmoney_key, totalmoney);
            GetInt(totalmoney_key);

        }
        else
        {
            GetInt(totalmoney_key);
        }
        int s_tm = GetInt(totalmoney_key);
        return s_tm;
        // Debug.Log(GetInt(totalmoney_key));
    }

}
