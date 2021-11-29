using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TostSandwich : MonoBehaviour
{
    [SerializeField]
    GameObject VeggieSandwhich;

    

    Animator toast_anim;

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
            Destroy(collision.gameObject);
            VeggieSandwhich.SetActive(true);
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

    void SandWhichBake()
    {
        VeggieSandwhich.SetActive(false);
        GameManager.instance.DropToast();
    }

    IEnumerator OpenLid()
    {
        Invoke("SandWhichBake", 2.1f);
        //VeggieSandwhich.SetActive(false);
        yield return new WaitForSeconds(2f);
        toast_anim.SetBool("c_toaster", false);
        

        

    }
}
