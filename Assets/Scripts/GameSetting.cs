using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetting : Singleton<GameSetting>
{
   public bool doneTutorial;  //Set or get
   public bool checkFreeTimeMods;  //Set or get
   public bool timeMods;  //Set or get
    public bool comboMods;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CheckTutorial()
    {
        return doneTutorial;
    }
    public bool CheckFreeTimeMods()
    {
        return checkFreeTimeMods;
    }
    public bool TimeMods()
    {
        return timeMods;
    }
    public bool CheckComboMods()
    {
        return comboMods;
    }
}
