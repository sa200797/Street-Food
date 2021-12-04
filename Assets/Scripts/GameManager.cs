using JMRSDK.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool playgame;
    public IngredientData vadapaw_I;
    public IngredientData sandwich_I;
    public IngredientData pizza_I;

    

    // [Header("Object For Vada Pav")]
    // public GameObject breadprefab, masalaprefab, vadapawprefab;
    // [Header("Object For SandWich")]
    // public GameObject san_breadprefab, breadsauce_prefab, veggie_prefab, toast_prefab;
    //[Header("Object For Pizza")]
    // public GameObject pizzadough_prefab, pizzakint_prefab, pizzabase_prefab, pizzasauce_prefab, pizzapep_prefab, pizzachesse_prefab, pizzaready_prefab;

    public int whatToSpawn;
    public Transform vada_dropppoint;
    public Transform san_droppoint;
    public Transform toast_droppoint;
    public Transform pizza_droppoint;

    GameObject vadapaw; // to delete th clones;
    GameObject sandwichclone;
    GameObject pizzaclone;


    public static bool vadaitemspawn; //only to spawn vadapaw;
    public static int vadapawcount = 0; //to check the foodcount for vadapav;

    public static bool sandwichitemsspawn;
    public static int sandwichcount = 0;

    public static bool pizzaitemspawn;
    public static int pizzacount = 0;
    
    public Transform playerspawnPoint;
    public GameObject player;

    [Header("Score Value")]
    public static int amount;
    public int price
    {
        get { return amount; }

        set
        {
            amount = value;
        }
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("JMRMixedReality");
        player.transform.position = playerspawnPoint.position;

        vadaitemspawn = false;
        sandwichitemsspawn = false;
        playgame = false;

        CoinBalanceUpdata();
    }

    // Update is called once per frame
    void Update()
    {
        //TO Check on The Laptop or Unity Editor;
        if (Input.GetMouseButtonDown(0))
        {
            GetInfo();
            // playgame = true;
            // JMRPointerManager.Instance.GetCurrentRay();
        }
    }

    public void GetInfo()
    {
        if (playgame == true)
        {
            var ray = JMRPointerManager.Instance.GetCurrentRay();
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, maxDistance: 100))
            {
                if (hit.collider.tag == "VadaPav")
                {
                    whatToSpawn = hit.collider.GetComponent<ItemCount>().Foodvalue;
                    MakeVadapaw();
                    //Debug.Log("Shubham---Vaada");
                }

                if (hit.collider.tag == "Sandwich")
                {
                    whatToSpawn = hit.collider.GetComponent<ItemCount>().Foodvalue;
                    MakeSandwich();
                    //  Debug.Log("Shubham---Sand");
                }

                if (hit.collider.tag == "Pizza")
                {
                    whatToSpawn = hit.collider.GetComponent<ItemCount>().Foodvalue;
                    MakePizza();
                }
            }
        }
    }

    #region Make Vada Pav
    public void MakeVadapaw()
    {
        Debug.Log("Mack Vadapaw");
        if (!vadaitemspawn)
        {
            switch (whatToSpawn)
            {

                case 1:
                    if (vadapawcount == 0)
                    {
                        GameObject bomb = Instantiate(vadapaw_I.foodIngredient[0], vada_dropppoint.transform.position, Quaternion.identity);
                        vadapaw = bomb;
                        vadapawcount++;
                        Debug.Log(vadapawcount);
                    }
                    break;
                case 2:
                    if (vadapawcount == 1)
                    {
                        Destroy(vadapaw);
                        GameObject bomb2 = Instantiate(vadapaw_I.foodIngredient[1], vada_dropppoint.transform.position, Quaternion.identity);
                        vadapaw = bomb2;
                        vadapawcount++;
                        Debug.Log(vadapawcount);
                    }
                    break;
                case 3:
                    if (vadapawcount == 2)
                    {
                        Destroy(vadapaw);
                        Instantiate(vadapaw_I.foodIngredient[2], vada_dropppoint.transform.position, Quaternion.identity);
                        vadapawcount++;
                        SoundManager.instance.SoundPlay_FD();
                        Debug.Log(vadapawcount);

                    }
                    break;
                default:
                    Debug.Log("Please follow the food itme menu");
                    break;
            }
        }
    }
    #endregion

    #region MakeSandwhich
    public void MakeSandwich()
    {
        if (!sandwichitemsspawn)
        {
            switch (whatToSpawn)
            {

                case 1:
                    if (sandwichcount == 0)
                    {
                        GameObject bread = Instantiate(sandwich_I.foodIngredient[0], san_droppoint.transform.position, Quaternion.identity);
                        sandwichclone = bread;
                        sandwichcount++;

                    }
                    break;
                case 2:
                    if (sandwichcount == 1)
                    {
                        Destroy(sandwichclone);
                        GameObject breadsauce = Instantiate(sandwich_I.foodIngredient[1], san_droppoint.transform.position, Quaternion.identity);
                        sandwichclone = breadsauce;
                        sandwichcount++;

                    }
                    break;
                case 3:
                    if (sandwichcount == 2)
                    {
                        Destroy(sandwichclone);
                        GameObject veggeprefab = Instantiate(sandwich_I.foodIngredient[2], san_droppoint.transform.position, Quaternion.identity);

                        sandwichclone = veggeprefab;


                        sandwichcount++;
                    }
                    break;
                default:
                    Debug.Log("Please follow the food item menu");
                    break;

            }
        }
    }


    public void DropToast()
    {
        //Destroy(sandwichclone,0f);
        Instantiate(sandwich_I.foodIngredient[3], toast_droppoint.transform.position, Quaternion.Euler(new Vector3(0, -70, 0)));
        SoundManager.instance.SoundPlay_FD();
    }


    #endregion

    #region Make Pizza
    public void MakePizza()
    {
        if (!pizzaitemspawn)
        {
            switch (whatToSpawn)
            {

                case 1:
                    if (pizzacount == 0)
                    {
                        GameObject dough = Instantiate(pizza_I.foodIngredient[0], pizza_droppoint.transform.position, Quaternion.identity);
                        pizzaclone = dough;
                        pizzacount++;

                    }
                    break;
                case 2:
                    if (pizzacount == 1)
                    {
                        Destroy(pizzaclone);
                        GameObject pizzakint = Instantiate(pizza_I.foodIngredient[1], pizza_droppoint.transform.position, Quaternion.Euler(new Vector3(0, 90, 0)));
                        pizzaclone = pizzakint;
                        pizzacount++;

                    }
                    break;
                case 3:
                    if (pizzacount == 2)
                    {
                        Destroy(pizzaclone);
                        GameObject pizzabase = Instantiate(pizza_I.foodIngredient[2], pizza_droppoint.transform.position, Quaternion.identity);
                        pizzaclone = pizzabase;
                        pizzacount++;
                    }
                    break;
                case 4:
                    if (pizzacount == 3)
                    {
                        Destroy(pizzaclone);
                        GameObject pizzasauce = Instantiate(pizza_I.foodIngredient[3], pizza_droppoint.transform.position, Quaternion.identity);
                        pizzaclone = pizzasauce;
                        pizzacount++;
                    }
                    break;
                case 5:
                    if (pizzacount == 4)
                    {
                        Destroy(pizzaclone);
                        GameObject pizzapep = Instantiate(pizza_I.foodIngredient[4], pizza_droppoint.transform.position, Quaternion.identity);
                        pizzaclone = pizzapep;
                        pizzacount++;
                    }
                    break;
                case 6:
                    if (pizzacount == 5)
                    {
                        Destroy(pizzaclone);
                        GameObject chezse = Instantiate(pizza_I.foodIngredient[5], pizza_droppoint.transform.position, Quaternion.identity);
                        pizzaclone = chezse;
                        pizzacount++;
                    }
                    break;
                default:
                    Debug.Log("Please follow the food itme menu");
                    break;

            }
        }
    }


    public void BakePizza()
    {
        Destroy(pizzaclone);
        Instantiate(pizza_I.foodIngredient[6], pizza_droppoint.transform.position, Quaternion.identity);
        SoundManager.instance.SoundPlay_FD();

    }

    #endregion

    #region CoinBalance

    internal void CoinAddBalance(int CoinMoney) 
    {
        StartCoroutine(CoinBalance(CoinMoney));        
        //CoinBalanceUpdata();
    }
    IEnumerator CoinBalance(int CoinMoney)
    {
        UIManager.instance.newAddBalance.gameObject.SetActive(true);
        UIManager.instance.newAddBalance.text = CoinMoney.ToString();
        yield return new WaitForSeconds(1f);
        UIManager.instance.newAddBalance.gameObject.SetActive(false);
        CoinBalanceUpdata();
        SavaData.instance.AddMoney(CoinMoney);
        GameManager.instance.gameObject.GetComponent<Timer>().timeRemaning += 20;


        yield return new WaitForSeconds(8f);
        UIManager.instance.ordercomplete.text = "";
    }
    void CoinBalanceUpdata() 
    {
        UIManager.instance.CurrountBalance.text = SavaData.instance.GetInt("toalmoney_key").ToString();
    }

    #endregion

    public void AddTime(float AddTime)
    {
        if (Timer.timerIsRunning == true) { UIManager.instance.gameObject.GetComponent<Timer>().timeRemaning += AddTime; }
    }
}

