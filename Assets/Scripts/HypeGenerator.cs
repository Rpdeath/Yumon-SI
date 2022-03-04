using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HypeGenerator : MonoBehaviour, IClickable
{
    #region Variable

    private Deck_Place_Manager place;
    public Image generatorFill;

    public float maxFill;
    public float timeToCompletion;
    public float boost;

    [HideInInspector]
    public float actualTime;

    [HideInInspector] public bool isReadyToHarvest = false;

    #endregion

    private void Start()
    {
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
    }
    public void StartGeneratingHype()
    {
        if (actualTime <= maxFill)
        {
            actualTime += Time.deltaTime * boost;
            generatorFill.fillAmount =  actualTime / maxFill;
        }
        else
        {
            isReadyToHarvest = true;
        }
    }



    public void OnClick()
    {
        if (isReadyToHarvest)
        {
            ResetGenerator();
        }
    }
    public void ResetGenerator()
    {
        actualTime = 0;
        isReadyToHarvest = false;
    }
}
