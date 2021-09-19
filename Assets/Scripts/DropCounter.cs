using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCounter : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("VadaPawComplete1");
        if (collision.gameObject.CompareTag("C_Vadapav")&& GameManager.instance.vadapavText.text == "Vadapav x 1")
        {
            Debug.Log("VadaPawComplete2");
            GameManager.vadaitemspawn = false;
            GameManager.vadapawcount = 0;
            Destroy(collision.gameObject,3f);
            StartCoroutine(ChangeText("Sandwich x 1"));
            //GameManager.instance.vadapavText.text = "Sandwich x 1";
        }
        else
        {
            GameManager.instance.vadapavText.text = "Wrong Recepie try again";
            Destroy(collision.gameObject, 3f);
            GameManager.instance.vadapavText.text = "Vadapav x 1";
        }
        if (collision.gameObject.CompareTag("C_Sandwich") && GameManager.instance.vadapavText.text == "Sandwich x 1")
        {
            Debug.Log("Sandwich Complete");
            GameManager.sandwichitemsspawn = false;
            GameManager.sandwichcount = 0;
            Destroy(collision.gameObject,3f);
            StartCoroutine(ChangeText("Pizza x 1"));
        }
        else
        {
            GameManager.instance.vadapavText.text = "Wrong Recepie try again";
            Destroy(collision.gameObject, 3f);
            GameManager.instance.vadapavText.text = "Sandwich x 1";
        }

        if (collision.gameObject.CompareTag("C_Pizza") && GameManager.instance.vadapavText.text == "Pizza x 1")
        {
            Debug.Log("Pizza Complete");
            GameManager.pizzaitemspawn = false;
            GameManager.pizzacount = 0;
            Destroy(collision.gameObject, 3f);
            StartCoroutine(ChangeText("Good Job!"));
        }
        else
        {
            GameManager.instance.vadapavText.text = "Wrong Recepie try again";
            Destroy(collision.gameObject, 3f);
            GameManager.instance.vadapavText.text = "Pizza x 1";
        }
    }

    IEnumerator ChangeText(string a)
    {
        Debug.Log("corotune started");
        GameManager.instance.vadapavText.text = "Completed";
        yield return new WaitForSeconds(4f);
        GameManager.instance.vadapavText.text = a;

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
