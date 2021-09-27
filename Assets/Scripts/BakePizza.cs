using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakePizza : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bake"))
        {

            StartCoroutine(BakedPizza());
        }
    }

    IEnumerator BakedPizza()
    {
        yield return new WaitForSeconds(3.0f);
        GameManager.instance.BakePizza();

    }
}
