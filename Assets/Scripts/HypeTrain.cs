using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HypeTrain : MonoBehaviour
{

    #region Variable    
    public int maxHypeValue = 1000;
    public int currentHypeValue;
    private int hypeAddValue;

    private Slider slider; 
    #endregion

    public void Start()
    {
        slider = GetComponent<Slider>();
    }
    
    public void AddHypeToTrain(int value)
    {
        hypeAddValue = value;
        currentHypeValue = currentHypeValue + hypeAddValue;
        slider.value = maxHypeValue / currentHypeValue;

        if(currentHypeValue >= maxHypeValue)
        {
            //win
        }
    }

}
