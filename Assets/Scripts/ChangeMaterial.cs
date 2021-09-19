using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    
   

    private void Start()
    {
      
      
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Toast"))
        {

            StartCoroutine(ChangeToastMaterial());
        }
    }

    IEnumerator ChangeToastMaterial()
    {
        yield return new WaitForSeconds(0.5f);
        GameManager.instance.DropToast();

    }

}
