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
        }
        if (collision.gameObject.CompareTag("C_Sandwich"))
        {
            Debug.Log("Sandwich Complete");
            GameManager.sandwichitemsspawn = false;
            GameManager.sandwichcount = 0;
            Destroy(collision.gameObject,3f);
        }

        if(collision.gameObject.CompareTag("C_Pizza"))
        {
            Debug.Log("Pizza Complete");
            GameManager.pizzaitemspawn = false;
            GameManager.pizzacount = 0;
            Destroy(collision.gameObject, 3f);
        }
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
