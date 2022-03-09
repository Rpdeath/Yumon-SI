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
    public bool startGenerateMana = true;

    [Header ("UI")]
    public Image fillSprite;
    public Text manaCounter;

    [HideInInspector]
    public User userData;

    [HideInInspector]
    public int actualMana;
    private float actualTime;
    #endregion

    private void Start()
    {
        userData = GameInstance.instance.userData;
        startGenerateMana = true;
        GameInstance.instance.actualGameInfo.manaPlayer1 = startMana;
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
            if (GameInstance.instance.actualGameInfo.manaPlayer1 < manaMax)
            {
                if (actualTime <= timeForGainMana)
                {
                    
                    foreach (EffectOnUser effect in GameInstance.instance.gameManager.lEffect)
                    {
                        if (effect.name == "ManaProduction")
                        {
                            boost = boost - effect.floatBuff;
                        }
                    }
                    actualTime += Time.deltaTime * boost;
                }
                else
                {
                    GameInstance.instance.actualGameInfo.manaPlayer1 += 1;
                    actualTime = 0;

                    GameInstance.instance.RefreshManaState(userData.users_id, GameInstance.instance.actualGameInfo.manaPlayer1);
                }
            }
            UiMana();
        }
    }

    private void UiMana()
    {
        fillSprite.fillAmount = actualTime / timeForGainMana;
        manaCounter.text = GameInstance.instance.actualGameInfo.manaPlayer1.ToString();
    }

}
