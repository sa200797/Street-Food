using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
  //  GameObject Droppoint;
   // [SerializeField]
   // Transform point;

    private void Start()
    {
        //Droppoint = GameObject.Find("Toast DropPoint");
       // point.transform.position = Droppoint.transform.position;
      
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Toast"))
        {
           // Vector3.MoveTowards(collision.gameObject.transform.position, point.transform.position, 1);
            StartCoroutine(ChangeToastMaterial());
        }
    }

    IEnumerator ChangeToastMaterial()
    {
       
        yield return new WaitForSeconds(2.0f);
        GameManager.instance.DropToast();

    }

}
