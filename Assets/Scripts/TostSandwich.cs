using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TostSandwich : MonoBehaviour
{
     public  Animator toast_anim;

    public static Collider sandwich_coll;

   
    


    // Start is called before the first frame update
    void Start()
    {
        sandwich_coll = GetComponent<Collider>();
        toast_anim = GetComponentInChildren<Animator>();    
    }

    private void OnCollisionEnter(Collision collision)
    {
       
        if(collision.gameObject.CompareTag("BakeSandwich"))
        {
            sandwich_coll.enabled = false;
            //Vector3.MoveTowards(collision.gameObject.transform.position, point.transform.position, 1);
        
            toast_anim.SetBool("c_toaster", true);
            StartCoroutine(OpenLid());
        }
    }

    // Update is called once per frame
    void Update()
    {
      
    }


    IEnumerator OpenLid()
    {
        yield return new WaitForSeconds(1.5f);
        toast_anim.SetBool("c_toaster", false);
        

        

    }
}
