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
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("C_Sandwich"))
        {
            Debug.Log("VadaPawComplete2");
            GameManager.vadaitemspawn = false;
            GameManager.vadapawcount = 0;
            Destroy(collision.gameObject);
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
