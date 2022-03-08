using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarzActifSysteme : MonoBehaviour
{
    #region Variable
    public HypeGenerator hypeScript;

    public ActifButtonUi selfActifUi;

    public int actifId;

    [Header ("Stats")]
    public float cooldownActif;
    public int actifCost;
    public float actifDuration;

    [HideInInspector]public float actualActifDuration;
    [HideInInspector]public float actualCooldown;

    [HideInInspector] public bool actifIsRunning;
    [HideInInspector] public bool coolDownIsRunning;

    #endregion

    private void Start()
    {
        selfActifUi.selfStarzActif = this;
        actualActifDuration = actifDuration;
        actualCooldown = 0f;
    }

    private void Update()
    {
        CheckActifCooldown();
        CheckActifDuration();
    }
    

    public void StartActifEffect(int id)
    {
        if (!coolDownIsRunning && !actifIsRunning && GameInstance.instance.actualGameInfo.manaPlayer1 >= actifCost)
        {
            // Cherché l'effet de l'actif dans le script qui stock tous les actif

            actifIsRunning = true;

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

}
