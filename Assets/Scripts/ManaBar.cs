using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    #region Variable
    [Header ("Stats of mana")]
    public int manaMax;
    public int startMana;
    public float timeForGainMana;
    public float boost;
    [Space]
    public bool startGenerateMana;

    [Header ("UI")]
    public Image fillSprite;
    public Text manaCounter;

    [HideInInspector]
    public int actualMana;
    private float actualTime;
    #endregion

    private void Start()
    {
        actualMana = startMana;
        actualTime = timeForGainMana;
    }

    private void Update()
    {
        ManaGenerationLogic();
    }

    private void ManaGenerationLogic()
    {
        if (startGenerateMana)
        {
            if (actualMana < manaMax)
            {
                if (actualTime >= 0)
                {
                    actualTime -= Time.deltaTime * boost;
                }
                else
                {
                    actualMana += 1;
                    actualTime = timeForGainMana;
                }
            }
        }
    }



    
}
