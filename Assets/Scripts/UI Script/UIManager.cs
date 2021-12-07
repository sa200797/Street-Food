using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject UI_canvas;
    public GameObject jioGlasses;

    [SerializeField]
    GameObject openShop_btn;

    [Header("Main Game UI")]
    [SerializeField]
    GameObject MainUIPannel;


    [Header("How To Play")]
    [SerializeField]
    GameObject howtoplay1;
    [SerializeField]
    GameObject howtoplay2;
    [SerializeField]
    GameObject howtoPlay_GamePlayCanvas;

    [Header("Order Details")]
    public TextMeshProUGUI orderid;
    public TextMeshProUGUI orderDetails;
    public TextMeshProUGUI orderAmountDetails;
    public TextMeshProUGUI TotalorderAmount;


    [Header("Sound ON/OFF Data")]
    [SerializeField] Image counterSound;
    [SerializeField] Sprite muteImage;
    [SerializeField] Sprite soundImage;
    bool sound;

    [Header("Sound Data")]
    public AudioSource[] sources;
    bool backscreen;
    public GameObject pause_backpannel;


    [Header("Food Dekliver Option")]
    public GameObject Display;
    [SerializeField] Material current_mat;
    [SerializeField] Material[] mat;



    [Header("Timer UI")]
    public TextMeshProUGUI timertext;

    [Header("Total Amount")]
    public TextMeshProUGUI totalAmoumt;


    [Header("Order Complete")]
    public TextMeshProUGUI ordercomplete;


    [Header("Coins")]
    [Space(10)]
    public TextMeshProUGUI CurrountBalance;
    public TextMeshProUGUI newAddBalance;

    bool fooddrop = false;

    float scrollSpeed = 0.5f;


    bool howtoplay_cc;
    bool gameplaycanvas_howtoplay;

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
        howtoplay_cc = false;
        gameplaycanvas_howtoplay = false;
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

        // UI_canvas = GameObject.Find("GamePlay Canvas");

        jioGlasses = GameObject.Find("JMRRenderer");
        // UI_canvas.transform.parent = jioGlasses.transform;


        //if (jioGlasses != null)
        //{
        //    UI_canvas.transform.parent = jioGlasses.transform;
        //    //UI_canvas.transform.localPosition = new Vector3(transform.position.x, -0.025f, transform.position.z);
        //}


    }

    // Update is called once per frame
    void Update()
    {
        if (fooddrop)
        {
            ChangeMaterial();
        }
        // Dropfood_Timer(5.0f);
        if (Input.GetKeyDown(KeyCode.P))
        {
            JioBackButton();
        }
    }
    public void PlayGame()
    {
        //Debug.Log("Call ho Raha hai baba");
        openShop_btn.SetActive(false);
     
        //Time.timeScale = 1;
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
    public void JioBackButton()
    {
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("OnBackAction");
        if (scene.name == "Environment full")
        {
            if (howtoplay_cc == true)
            {
                UIManager.instance.Deactivied_HowTOPlayPannel();
            }
            else
            {
                if (gameplaycanvas_howtoplay == true)
                {
                    deactive_GamePlayCanvasHTP();
                }
                else
                {
                    UIManager.instance.BackButton();
                }
            }
        }
        else
        {
            Application.Quit();
        }
    }
    public void BackButton()
    {
        ///pause_backpannel = GameObject.FindGameObjectWithTag("Pause");

        backscreen = !backscreen;

        if (backscreen)
        {
            Time.timeScale = 0;

            GameManager.instance.playgame = false;
            pause_backpannel.SetActive(true);

        }
        else
        {
            Time.timeScale = 1;
            GameManager.instance.playgame = true;
            pause_backpannel.SetActive(false);
        }
    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        // UI_canvas.transform.parent = null;
        GameManager.vadapawcount = 0;
        GameManager.sandwichcount = 0;
        GameManager.pizzacount = 0;
        SavaData.instance.ordercount = 0;
        SavaData.instance.money = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    #region How To Pannel Mech 
    public void Deactivied_HowTOPlayPannel()
    {
        howtoplay_cc = false;

        howtoplay1.SetActive(false);
        howtoplay2.SetActive(false);
        MainUIPannel.SetActive(true);

    }

    public void Active_HowToPlay()
    {
        howtoplay_cc = true;

        howtoplay1.SetActive(true);
        howtoplay2.SetActive(true);
        MainUIPannel.SetActive(false);

    }

    public void deactive_GamePlayCanvasHTP()
    {
        gameplaycanvas_howtoplay = false;
        howtoPlay_GamePlayCanvas.SetActive(false);

    }

    public void active_GamePlayCanvasHTP()
    {
        gameplaycanvas_howtoplay = true;
        howtoPlay_GamePlayCanvas.SetActive(true);
    }

    #endregion

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
        // Debug.Log("Thankyou" + ">>>>>>>>>>>>>>>><<<<<<<<<<<");
    }
    #endregion


    public void OneOrderPlay()
    {
        Debug.Log("is work  fasfasdasfdasd");
        openShop_btn.SetActive(false);
        GameManager.instance.playgame = true;
        timertext.transform.parent.transform.gameObject.SetActive(false);

        LevelManager.levelmanager.numberOffOrder = LevelManager.NumberOffOrder.OneOrder;
        LevelManager.levelmanager.GetOrder();

    }
    public void OneOrderWithTime()
    {
        openShop_btn.SetActive(false);
        GameManager.instance.playgame = true;
        Timer.timerIsRunning = true;
        timertext.transform.parent.transform.gameObject.SetActive(true);

        LevelManager.levelmanager.numberOffOrder = LevelManager.NumberOffOrder.OneOrder;
        LevelManager.levelmanager.GetOrder();
    }
    public void multipleOrder()
    {
        openShop_btn.SetActive(false);
        GameManager.instance.playgame = true;
        //Timer.timerIsRunning = true;
        timertext.transform.parent.transform.gameObject.SetActive(false);

        LevelManager.levelmanager.numberOffOrder = LevelManager.NumberOffOrder.TwoOrder;
        LevelManager.levelmanager.GetOrder();
    }
    public void multipleOrderWithtime()
    {
        openShop_btn.SetActive(false);
        GameManager.instance.playgame = true;
        Timer.timerIsRunning = true;
        timertext.transform.parent.transform.gameObject.SetActive(true);

        LevelManager.levelmanager.numberOffOrder = LevelManager.NumberOffOrder.TwoOrder;
        LevelManager.levelmanager.GetOrder();
    }

    public void OnTutorial()
    {
        openShop_btn.SetActive(false);
        GameManager.instance.playgame = true;
        //Timer.timerIsRunning = true;
        timertext.transform.parent.transform.gameObject.SetActive(true);

        LevelManager.levelmanager.numberOffOrder = LevelManager.NumberOffOrder.TwoOrder;
        LevelManager.levelmanager.GetOrder();
        Tutorial.tutorial.SetupSaggatation(0);
        Tutorial.tutorial.SetupOrderIndexSaggatation();
    }

}
