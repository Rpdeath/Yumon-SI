using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HypeGenerator : MonoBehaviour, IClickable
{
    #region Variable

    

    [Header("Player 1 Colors")]
    public Color loadingColor;
    public Color harvestReadyColor;

    [Header("Player 2 Colors")]
    public Color loadingColor2;
    public Color harvestReadyColor2;

    [Header("Feedback")]
    public GameObject particuleOnHarvest;

    [Header ("Setup unity")]
    public Image generatorFill;

    [HideInInspector] public int maxFill;
    [HideInInspector] public float timeToCompletion;
    [HideInInspector] public float boost;
    [HideInInspector] public bool UsedByPlayer = true;



    private float actualTime;
    public bool isReadyToHarvest = false;

    private User userData;
    private Deck_Place_Manager place;

    #endregion

    private void Start()
    {
        userData = GameInstance.instance.userData;

        InitGenerator();
    }

    public void Update()
    {
        if (isReadyToHarvest == false)
        {
            StartGeneratingHype();
        }
    }

    public void InitGenerator()
    {
        actualTime = 0;
        generatorFill.color = loadingColor;
    }
    public void StartGeneratingHype()
    {
        if (actualTime <= timeToCompletion)
        {
            actualTime += Time.deltaTime * boost;
            generatorFill.fillAmount =  actualTime / timeToCompletion;
        }
        else
        {
            isReadyToHarvest = true;
            generatorFill.color = harvestReadyColor;
        }
    }



    public void OnClick()
    {
        
        if (isReadyToHarvest)
        {
            if (!UsedByPlayer)
            {
                ResetGenerator(false);
                GameObject obj = Instantiate(particuleOnHarvest, transform.position, transform.rotation);
                obj.GetComponent<HypeParticule>().currentHandle = GameInstance.instance.actualGameInfo.handle2;

            }
            else
            {
                ResetGenerator(true);
                Instantiate(particuleOnHarvest, transform.position, transform.rotation);
            }
        }
    }
    public void ResetGenerator(bool User)
    {
        int scoreToAdd = maxFill;
        foreach(EffectOnUser effect in GameInstance.instance.gameManager.lEffect)
        {
            if(effect.name == "HypeProductionSameLine")
            {
                int line = 0;
                foreach(GameObject gobj in GameInstance.instance.gameManager.columns)
                {
                    if(gobj.GetComponentInChildren<StarzData>().data.pathOfImage == effect.stringBuff)
                    {
                        line = gobj.GetComponent<ColumnPosition>().x;
                    }
                }
                if(GameInstance.instance.gameManager.columns[line * 3 + 0].GetComponent<DropStarz>().actualStarz.GetComponentInChildren<StarzData>().data.id == GetComponent<StarzData>().data.id)
                {
                    scoreToAdd = (int)(scoreToAdd * (1 + effect.floatBuff));
                }
                if (GameInstance.instance.gameManager.columns[line * 3 + 1].GetComponent<DropStarz>().actualStarz.GetComponentInChildren<StarzData>().data.id == GetComponent<StarzData>().data.id)
                {
                    scoreToAdd = (int)(scoreToAdd * (1 + effect.floatBuff));
                }
                if (GameInstance.instance.gameManager.columns[line * 3 + 2].GetComponent<DropStarz>().actualStarz.GetComponentInChildren<StarzData>().data.id == GetComponent<StarzData>().data.id)
                {
                    scoreToAdd = (int)(scoreToAdd * (1 + effect.floatBuff));
                }


            }
        }
        if (User)
        {

            GameInstance.instance.AddScore(userData.users_id, maxFill);
        }
        else
        {

            GameInstance.instance.AddScore(GameInstance.instance.userDataEnemy.users_id, maxFill);
        }
            actualTime = 0;
            isReadyToHarvest = false;

            generatorFill.color = loadingColor;
        
    }
}
