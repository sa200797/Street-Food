using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TostSandwich : MonoBehaviour
{
    public Animator toast_anim;


    // Start is called before the first frame update
    void Start()
    {
        toast_anim = GetComponentInChildren<Animator>();    
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("BakeSandwich"))
        {
            toast_anim.SetBool("c_toaster", true);
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
