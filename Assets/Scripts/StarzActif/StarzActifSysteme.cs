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

    [HideInInspector] public float cooldownActif;
    [HideInInspector] public int actifCost;
    [HideInInspector] public float actifDuration;
    public bool userController = true;

    [HideInInspector]public float actualActifDuration;
    [HideInInspector]public float actualCooldown;

    [HideInInspector] public bool actifIsRunning;
    [HideInInspector] public bool coolDownIsRunning;

    [HideInInspector] public Card selfCard;

    public Animator animator;

    public Animator spawnAnim;
    #endregion

    private void Start()
    {
       StartCoroutine(Init());

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

            ReduceActifCooldown();
        }
    }
    

    IEnumerator Init()
    {
        yield return new WaitForEndOfFrame();

        actifDuration = selfCard.properties.actifDuration;
        cooldownActif = selfCard.properties.cooldown;
    }

    public void StartActifEffect(string id)
    {
        bool canActif = true;
        foreach (EffectOnUser effect in GameInstance.instance.gameManager.lEffect)
        {
            if (effect.name == "PreventActif")
            {
                canActif = false;
            }
        }
        if (canActif && !coolDownIsRunning && !actifIsRunning && GameInstance.instance.actualGameInfo.manaPlayer1 >= actifCost)
        {
            actifIsRunning = true;

            PlayActif(id);
            animator.SetBool("isActing", true);
            spawnAnim.Play("ActifUsed",-1,0f);
            DragDownUi();
            actualActifDuration = 0f;
            GameInstance.instance.actualGameInfo.manaPlayer1 -= selfCard.properties.actif_cost;
        }
    }

    private void CheckActifDuration()
    {
        if (actifIsRunning)
        {
            if (actualActifDuration < selfCard.properties.actifDuration)
            {
                actualActifDuration += Time.deltaTime;
            }
            else
            {
                actifIsRunning = false;
                actualActifDuration = selfCard.properties.actifDuration;

                DragUpUi();

                coolDownIsRunning = true;
                actualCooldown = selfCard.properties.cooldown;
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

    private void ReduceActifCooldown()
    {
        foreach (EffectOnUser effect in GameInstance.instance.gameManager.lEffect)
        {
            if (effect.name == "ActifCooldownReduction")
            {
                cooldownActif -= effect.floatBuff;

                if (cooldownActif < 0f)
                {
                    cooldownActif = 0f;
                }
                GameInstance.instance.gameManager.lEffect.Remove(effect);
            }
        }
    }


    private void DragDownUi()
    {
        selfActifUi.animator.SetTrigger("DragDown");

        /*StartCoroutine(AnimMoveUi(selfActifUi.effectSquareObj, selfActifUi.squareEffectDownPos, 3f));
        StartCoroutine(AnimMoveUi(selfActifUi.sliderObj, selfActifUi.sliderDownPos, 3f));*/
    }

    private void DragUpUi()
    {
        selfActifUi.animator.SetTrigger("DragUp");
        /*StartCoroutine(AnimMoveUi(selfActifUi.effectSquareObj, selfActifUi.coolDownActifImage.gameObject.transform, 2f));
        StartCoroutine(AnimMoveUi(selfActifUi.sliderObj, selfActifUi.coolDownActifImage.gameObject.transform, 2f));*/
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
            case "kcorp_kamet0":
                kcorp_kamet0();
                break;
            case "kcorp_sardoche":
                kcorp_sardoche();
                break;
            case "kcorp_adlderiate":
                kcorp_adlderiate();
                break;
            case "kcorp_kotei":
                kcorp_kotei();
                break;
            case "zevent_zerator":
                zevent_zerator();
                break;
            case "zevent_moman":
                zevent_moman();
                break;
            case "zevent_ultia":
                zevent_ultia();
                break;
            case "kcorp_rekkles":
                kcorp_rekkles();
                break;
            default:
                break;
        }
    }

    private void zevent_ultia()
    {
        StartCoroutine(StopActifAnimation(0.5f));
    }

    private void kcorp_rekkles()
    {
        StartCoroutine(StopActifAnimation(0.5f));
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
        effect.floatBuff = 5f;
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


    private void kcorp_kamet0()
    {
        EffectOnUser effect = new EffectOnUser();
        effect.name = "ManaProduction";
        effect.floatBuff = 0.5f;

        AssUserEffect(effect, 7, true);
    }
    private void kcorp_sardoche()
    {
        EffectOnUser effect = new EffectOnUser();
        effect.name = "ActifCooldownReduction";
        effect.floatBuff = 3f;
        AssUserEffect(effect, 0, true);
    }
    private void kcorp_adlderiate()
    {
        EffectOnUser effect = new EffectOnUser();
        effect.name = "BuffNextStarz";
        effect.floatBuff = 1;
        AssUserEffect(effect, 59f, true);
    }
    private void kcorp_kotei()
    {
        EffectOnUser effect = new EffectOnUser();
        effect.name = "HypeConvertor";
        AssUserEffect(effect, 5f, true);
    }
    private void zevent_zerator()
    {
        GameInstance.instance.AddScore(1, GameInstance.instance.actualGameInfo.manaPlayer1 * 15);
        GameInstance.instance.actualGameInfo.manaPlayer1 = 0;
        StartCoroutine(StopActifAnimation(0.5f));
    }

    private void zevent_moman()
    {
        EffectOnUser effect = new EffectOnUser();
        effect.name = "MomanBoost";
        effect.floatBuff = 1.15f;
        AssUserEffect(effect, 6, true);
    }


    IEnumerator StopActifAnimation(float time)
    {
        yield return new WaitForSeconds(time);
        animator.SetBool("isActing", false);
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

        Debug.Log(GameInstance.instance.gameManager.lEffect.Count);

    }

    IEnumerator RemoveUserEffect(EffectOnUser effect, float time, bool User)
    {
        yield return new WaitForSeconds(time);
        if (User && userController)
        {
            animator.SetBool("isActing", false);
            GameInstance.instance.gameManager.lEffect.Remove(effect);

        }
        else
        {
            animator.SetBool("isActing", false);
            GameInstance.instance.gameManager.lEffectEnnemy.Remove(effect);

        }
        
    }

}
