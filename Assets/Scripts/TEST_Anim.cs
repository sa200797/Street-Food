using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class TEST_Anim : MonoBehaviour
{

    public Image black;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Spacebar pressed");
            StartCoroutine(Fading());
        }
    }

    public void PlayAnimationInObject()
    {
        
    }

    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        Debug.Log("Coroutine Started");
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene(1);
        
    }
}
