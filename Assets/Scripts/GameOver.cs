using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI orderCompletd;
    public TextMeshProUGUI totalAmount;

   
    private void Awake()
    {
         //Debug.Log(SavaData.instance.TotalOrderCompleted());
        //Debug.Log(SavaData.instance.TotalAmount());

    }
    // Start is called before the first frame update
    void Start()
    {
        orderCompletd.text="Orders Completed --" + SavaData.instance.TotalOrderCompleted().ToString();
        totalAmount.text = "Total Amount--" + SavaData.instance.TotalAmount();
        //orderCompletd.text = 
        SavaData.instance.Save_TotalOrdrsandDisplay();
        SavaData.instance.Save_TotalMoney();
    }

    public void RestartGame()
    {
        GameManager.vadapawcount = 0;
        GameManager.sandwichcount = 0;
        GameManager.pizzacount = 0;
        SavaData.instance.ordercount = 0;
        SavaData.instance.money = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
