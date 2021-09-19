using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public int ordercount;

    public string vada, sandwhich, pizza;

    public int foodcout;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseLevel()
    {
        switch(ordercount)
        {
            case 1:
                //Make Vada Paw;


            break;

                case 2:
                //Make 2 vada pav;
                break;
        }
    }
}
