using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMods : MonoBehaviour
{
    public GameObject freemod;
    public GameObject timemod;
     public GameObject combomod;

    // Start is called before the first frame update
    void Start()
    {
        if(LevelManager.freetimemodui==true)
        {
            freemod.SetActive(true);
        }
         if(LevelManager.timemodui==true)
        {
            timemod.SetActive(true);
        }
        if(LevelManager.cobomodeui==true)
        {
            combomod.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
