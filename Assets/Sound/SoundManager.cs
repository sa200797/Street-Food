using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField]
    AudioClip OrderCompleted;
    [SerializeField]
    AudioClip FoodDrop;
    [SerializeField]
    AudioSource audiosource;
    

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SoundPlay_OC( )
    {
        audiosource.PlayOneShot(OrderCompleted);
    }


    public void SoundPlay_FD()
    {
        audiosource.PlayOneShot(FoodDrop);
    }

}
