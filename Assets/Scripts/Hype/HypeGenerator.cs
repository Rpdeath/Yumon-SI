using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HypeGenerator : MonoBehaviour, IClickable
{
    #region Variable

    private Deck_Place_Manager place;
    public Image generatorFill;
   
    public int maxFill;
    public float timeToCompletion;
    public float boost;

    private float actualTime;

    private bool isReadyToHarvest = false;

    private User userData;

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
        GameInstance.instance.AddScore(userData.users_id, maxFill);

        actualTime = 0;
        isReadyToHarvest = false;
    }
}
