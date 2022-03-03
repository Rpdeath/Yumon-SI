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

    public User userData;

    [HideInInspector]
    public int actualMana;
    private float actualTime;
    #endregion

    private void Start()
    {
        userData = GameInstance.instance.userData;

        actualMana = startMana;
        actualTime = 0;

        fillSprite.fillAmount = 0;
        manaCounter.text = startMana.ToString();
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
                if (actualTime <= timeForGainMana)
                {
                    actualTime += Time.deltaTime * boost;
                }
                else
                {
                    actualMana += 1;
                    actualTime = 0;

                    GameInstance.instance.RefreshManaState(userData.users_id, actualMana);
                }
            }
            UiMana();
        }
    }

    private void UiMana()
    {
        fillSprite.fillAmount = actualTime / timeForGainMana;
        manaCounter.text = actualMana.ToString();
    }

}
