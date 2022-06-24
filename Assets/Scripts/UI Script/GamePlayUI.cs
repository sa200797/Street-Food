using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayUI : MonoBehaviour
{
    public static GamePlayUI instance;
    // Start is called before the first frame update
    void Start()
    {
       if (instance == null)
           instance = this;
       else
       {
           Destroy(gameObject);
       }

        //DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackButtonPause()
    {
        Time.timeScale = 1;
        GameManager.instance.playgame = true;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        UIManager.instance.pause_backpannel.SetActive(true);

         GameManager.vadapawcount = 0;
        GameManager.sandwichcount = 0;
        GameManager.pizzacount = 0;

        SavaData.instance.ordercount = 0;
        SavaData.instance.money = 0;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
