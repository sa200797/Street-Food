using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject UI_canvas;
    public GameObject jioGlasses;



    [SerializeField]
    GameObject openShop_btn;




   // float fill_time;



    [Header("Order Details")]
    public TextMeshProUGUI orderid;
    public TextMeshProUGUI orderDetails;


    [Header("Sound ON/OFF Data")]
    [SerializeField]
    Image counterSound;
    [SerializeField]
    Sprite muteImage;
    [SerializeField]
    Sprite soundImage;

    bool sound;
    

    [Header("Sound Data")]
    public AudioSource[] sources;




    bool backscreen;

    [SerializeField]
    GameObject pause_backpannel;


    [Header("Food Dekliver Option")]
    public GameObject Display;
    [SerializeField]
    Material current_mat;
    [SerializeField]
    Material[] mat;



    [Header("Timer UI")]
    public TextMeshProUGUI timertext;

    [Header("Total Amount")]
    public TextMeshProUGUI totalAmoumt;


    [Header("Order Complete")]
    public TextMeshProUGUI ordercomplete;

    bool fooddrop = false;

    float scrollSpeed = 0.5f;
    

    private void Awake()
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
        //image = GetComponent<Image>();
        sound = true;

        current_mat = Display.GetComponent<Renderer>().material;
        sources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];


        totalAmoumt.text = GameManager.amount.ToString();
        ordercomplete.text = " ";
;
            
        ////jioGlasses = GameObject.Find("JMRRenderer");

        ////if(jioGlasses != null)
        ////{
        ////    UI_canvas.transform.parent = jioGlasses.transform;
        ////      UI_canvas.transform.localPosition = new Vector3(transform.position.x, -0.025f, transform.position.z);
        ////}


    }

    // Update is called once per frame
    void Update()
    {
        if(fooddrop)
        ChangeMaterial();

        // Dropfood_Timer(5.0f);



        if (Input.GetKeyDown(KeyCode.P))
        {
            BackButton();
        }


    }




    public void PlayGame()
    {
        Debug.Log("Call ho Raha hai baba");
        openShop_btn.SetActive(false);

        GameManager.instance.playgame = true;
        Timer.timerIsRunning = true;

    }

    public void Dropfood_Timer(float fill_time)
    {
      // Debug.Log("Timer>>>>>>>>>>???????/??");
        //image.fillAmount = Math.Abs(fill_time - 3.0f) / 3.0f;
    }




    public void CounterOnOFFSound()
    {
        sound = !sound;

        if (!sound)
        {
            counterSound.sprite = muteImage;

            sources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
            foreach (AudioSource music in sources)
            {
                music.mute = true;
                // Debug.Log("Sound On");
                
            }
        }
        else
        {
            counterSound.sprite = soundImage;
            sources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
            foreach (AudioSource music in sources)
            {
                music.mute = false;
                // Debug.Log("Sound On");

            }
        }
    }


   

    public void BackButton()
    {
        backscreen = !backscreen;

        if(backscreen)
        {
            Time.timeScale = 0;
            pause_backpannel.SetActive(true);

        }
        else
        {
            Time.timeScale = 1;
            pause_backpannel.SetActive(false);
        }
    }

    public void BackButtonPause()
    {
        Time.timeScale = 1;
    }

    

    #region Dislay Material
    public void ChangeMaterial()
    {
        Debug.Log("Change Material");
        switch (DropCounter.ordervalidity)
        {
            case 1:
                fooddrop = true;
                MoveMaterial(1);
                break;
            case 2:
                fooddrop = true;
                MoveMaterial(2);
                break;
            default:
                fooddrop = false;
                MoveMaterial(0);
                break;

        }

    }

    public void MoveMaterial(int num)
    {
        float offset = Time.time * scrollSpeed;

        current_mat = mat[num];
        Display.GetComponent<Renderer>().material = current_mat;
        current_mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        Debug.Log("Thankyou" + ">>>>>>>>>>>>>>>><<<<<<<<<<<");
    }
    #endregion
}
