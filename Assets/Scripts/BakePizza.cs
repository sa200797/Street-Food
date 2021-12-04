using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakePizza : MonoBehaviour
{
    [SerializeField] GameObject BakePlatfrom;
    [SerializeField] GameObject finishBakePlatfrom;
    [SerializeField] GameObject prefabUncooked;
    [SerializeField] GameObject prefabcooked;
    [SerializeField] GameObject PizzaDrag; 
    

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("object Enter");
        PizzaDrag = null;
        if (collision.gameObject.CompareTag("UncookedPizza"))
        {
            Debug.Log("Pizza is available" + collision.gameObject.name);
            GetComponent<Collider>().enabled = false;            
            StartCoroutine(Baked(collision.contacts));
            Destroy(collision.gameObject);            
            //StartCoroutine(BakedPizza());
        }
    }
    IEnumerator Baked(ContactPoint[] contacts) 
    {
        
        //hitFoodObject.transform.DOMove(BakePlatfrom.transform.position, 0.5f); //contacts[0].point
        GameObject GenratedObject = Instantiate(prefabUncooked, contacts[0].point, Quaternion.identity) as GameObject;
        GenratedObject.transform.localPosition = contacts[0].point;
        GenratedObject.SetActive(true);
        GenratedObject.transform.DOMove(BakePlatfrom.transform.position, 0.25f).onComplete += delegate 
        {
            StartCoroutine(BakedPizza(GenratedObject));
        };
        yield return new WaitForEndOfFrame();
    }
    IEnumerator BakedPizza(GameObject genratedObject)
    {
        yield return new WaitForSeconds(1.2f);
        Destroy(genratedObject, 0.1f);
        GameObject GenratedObject  = Instantiate(prefabcooked, BakePlatfrom.transform.position, Quaternion.identity)as GameObject;
        SoundManager.instance.SoundPlay_FD();
        yield return new WaitForSeconds(2f);
        GenratedObject.transform.DOMove(finishBakePlatfrom.transform.position,0.5f);
        //GameManager.instance.BakePizza();

    }
}
