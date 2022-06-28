using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPannel : Singleton<MainPannel>
{

    public static MainPannel instance;

    public GameObject takeMultipleOrder;
    public GameObject takeMultipleOrderTime;
    public GameObject takeMultipleOrderCombo;
    private void Awake()
    {
      // if (instance == null)
      // {
      //     instance = this;
      //}
      //
      //     Destroy(this);
      // }
   }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
