using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCounter : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("VadaPawComplete");
        }
    }


    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("VadaPawComplete");
    //    if (other.gameObject.CompareTag("Finish"))
    //    {
    //        Debug.Log("VadaPawComplete++++");
    //    }
    //}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
