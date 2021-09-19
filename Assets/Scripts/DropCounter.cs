using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCounter : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("VadaPawComplete1");
        if (collision.gameObject.CompareTag("C_Vadapav"))
        {
            Debug.Log("VadaPawComplete2");
            GameManager.vadaitemspawn = false;
            GameManager.vadapawcount = 0;
            Destroy(collision.gameObject,3f);
            Invoke("DestroyText", 2f);
            StartCoroutine(ChangeText("Sandwich x 1"));
            //GameManager.instance.vadapavText.text = "Sandwich x 1";
        }
        if (collision.gameObject.CompareTag("C_Sandwich"))
        {
            Debug.Log("Sandwich Complete");
            GameManager.sandwichitemsspawn = false;
            GameManager.sandwichcount = 0;
            Destroy(collision.gameObject,3f);
            StartCoroutine(ChangeText("Pizza x 1"));


        }

        if (collision.gameObject.CompareTag("C_Pizza"))
        {
            Debug.Log("Pizza Complete");
            GameManager.pizzaitemspawn = false;
            GameManager.pizzacount = 0;
            Destroy(collision.gameObject, 3f);
            StartCoroutine(ChangeText("Good Job!"));


        }
    }

    IEnumerator ChangeText(string a)
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("corotune started");
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
