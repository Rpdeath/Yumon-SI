using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HypeTrain : MonoBehaviour
{
    #region Variable    

    public int maxHypeValue = 1000;
    public int currentHypeValue;

    public Slider slider; 

    #endregion

    public void AddHypeToTrain(int value)
    {
        currentHypeValue += value;
        slider.value = currentHypeValue / maxHypeValue;

        if(currentHypeValue >= maxHypeValue)
        {
            //win
        }
    }

}
