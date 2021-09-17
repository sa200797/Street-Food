using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCounter : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("VadaPawComplete1");
        if (collision.gameObject.CompareTag("Finish"))
        {
            Debug.Log("VadaPawComplete2");
            GameManager.foodtemspawn = false;
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
