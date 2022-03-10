using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectOnUser
{
    public string name;
    public string stringBuff;
    public float floatBuff;
    public int intBuff;
    
}


public class StarzActifSysteme : MonoBehaviour
{
    #region Variable
    public HypeGenerator hypeScript;

    public ActifButtonUi selfActifUi;

    [HideInInspector] public bool UsedByPlayer = true;
    public string actifId;

    [Header ("Stats")]
    public float cooldownActif;
    public int actifCost;
    public float actifDuration;
    public bool userController = true;

    [HideInInspector]public float actualActifDuration;
    [HideInInspector]public float actualCooldown;

    [HideInInspector] public bool actifIsRunning;
    [HideInInspector] public bool coolDownIsRunning;

    #endregion

    private void Start()
    {
        if (UsedByPlayer)
        {
            selfActifUi.selfStarzActif = this;
            actualActifDuration = actifDuration;
            actualCooldown = 0f;
        }
    }

    private void Update()
    {
        if (UsedByPlayer)
        {
            CheckActifCooldown();
            CheckActifDuration();
        }
    }
    

    public void StartActifEffect(string id)
    {
        if (!coolDownIsRunning && !actifIsRunning && GameInstance.instance.actualGameInfo.manaPlayer1 >= actifCost)
        {
            // Cherché l'effet de l'actif dans le script qui stock tous les actif

            actifIsRunning = true;

            PlayActif(id);

            DragDownUi();
            actualActifDuration = 0f;
            GameInstance.instance.actualGameInfo.manaPlayer1 -= actifCost;
        }
    }

    private void CheckActifDuration()
    {
        if (actifIsRunning)
        {
            if (actualActifDuration < actifDuration)
            {
                actualActifDuration += Time.deltaTime;
            }
            else
            {
                actifIsRunning = false;
                actualActifDuration = actifDuration;

                DragUpUi();

                coolDownIsRunning = true;
                actualCooldown = cooldownActif;
            }
        }
    }
    private void CheckActifCooldown()
    {
        if (coolDownIsRunning)
        {
            if (actualCooldown > 0)
            {
                actualCooldown -= Time.deltaTime;
            }
            else
            {
                actualCooldown = 0f;
                coolDownIsRunning = false;
            }
        }
    }



    private void DragDownUi()
    {
        StartCoroutine(AnimMoveUi(selfActifUi.effectSquareObj, selfActifUi.squareEffectDownPos, 0.1f));

        StartCoroutine(AnimMoveUi(selfActifUi.sliderObj, selfActifUi.sliderDownPos, 0.1f));
    }

    private void DragUpUi()
    {
        StartCoroutine(AnimMoveUi(selfActifUi.effectSquareObj, selfActifUi.coolDownActifImage.gameObject.transform, 0.1f));

        StartCoroutine(AnimMoveUi(selfActifUi.sliderObj, selfActifUi.coolDownActifImage.gameObject.transform, 0.1f));
    }

    IEnumerator AnimMoveUi(GameObject objToMove ,Transform newPos, float speed)
    {
        while (objToMove.transform.position != newPos.position)
        {
            objToMove.transform.position = Vector3.MoveTowards(objToMove.transform.position, newPos.position, Time.deltaTime * speed);

            yield return new WaitForEndOfFrame();
        }
    }
    private void PlayActif(string id)
    {
        switch (id)
        {
            case "zevent_boblennon":
                zevent_boblennon();
                break;
            case "amongus_gomart":
                amongus_gomart();
                break;
            case "amongus_ponce":
                amongus_ponce();
                break;
            case "amongus_baghera":
                amongus_baghera();
                break;
            case "amongus_jdg":
                amongus_jdg();
                break;
            case "amongus_antoinedaniel":
                amongus_antoinedaniel();
                break;
            case "zevent_maghla":
                zevent_maghla();
                break;
            default:
                break;
        }
    }
    private void zevent_maghla()
    {
        EffectOnUser effect = new EffectOnUser();
        effect.name = "HypeProductionSameLine";
        effect.stringBuff = "zevent_maghla";
        effect.floatBuff = 0.5f;
        AssUserEffect(effect, 5, false);
    }
    private void amongus_antoinedaniel()
    {
        EffectOnUser effect = new EffectOnUser();
        effect.name = "StealHypeProduction";
        effect.stringBuff = "All";
        effect.floatBuff = 0.2f;
        AssUserEffect(effect, 5, false);
    }

    private void amongus_jdg()
    {
        EffectOnUser effect = new EffectOnUser();
        effect.name = "HypeProduction";
        effect.stringBuff = "All";
        effect.floatBuff = 0.5f;
        AssUserEffect(effect, 5, false);
    }

    private void amongus_baghera()
    {
        EffectOnUser effect = new EffectOnUser();
        effect.name = "PreventSpawnStarz";
        effect.stringBuff = "All";
        AssUserEffect(effect, 3, false);
    }
    private void amongus_ponce()
    {
        EffectOnUser effect = new EffectOnUser();
        effect.name = "PreventHype"; // A Faire
        effect.stringBuff = "All";
        AssUserEffect(effect, 3,false);
        EffectOnUser effect2 = new EffectOnUser();
        effect2.name = "PreventActif"; // A faire
        effect2.stringBuff = "All";
        AssUserEffect(effect2, 3, false);
    }

    private void amongus_gomart()
    {
        EffectOnUser effect = new EffectOnUser();
        effect.name = "ManaProduction";
        effect.floatBuff = 0.5f;
        AssUserEffect(effect, 4, false);
    }

    private void zevent_boblennon()
    {
        EffectOnUser effect = new EffectOnUser();
        effect.name="ManaCost";
        effect.stringBuff = "ZEvent";
        effect.floatBuff = 0.1f;
        AssUserEffect(effect, 6,true);
    }

    private void AssUserEffect(EffectOnUser effect,float time, bool User)
    {
        if (User)
        {
            GameInstance.instance.gameManager.lEffect.Add(effect);

        }
        else
        {
            GameInstance.instance.gameManager.lEffectEnnemy.Add(effect);

        }
        if (time != 0)
        {
            StartCoroutine(RemoveUserEffect(effect, time, User));
        }
    }

    IEnumerator RemoveUserEffect(EffectOnUser effect, float time, bool User)
    {
        yield return new WaitForSeconds(time);
        if (User && userController)
        {
            GameInstance.instance.gameManager.lEffect.Remove(effect);

        }
        else
        {
            GameInstance.instance.gameManager.lEffectEnnemy.Remove(effect);

        }
        
    }

}
