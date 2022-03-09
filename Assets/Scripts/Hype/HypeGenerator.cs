using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HypeGenerator : MonoBehaviour, IClickable
{
    #region Variable

<<<<<<< HEAD
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
=======
    [Header ("Stats")]
    public int maxFill;
    public float timeToCompletion;
    public float boost;

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

>>>>>>> parent of 2fe7cd3 (ColonneLumiereStillWIP)
    
    private float actualTime;
    private bool isReadyToHarvest = false;

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
            ResetGenerator();

            Instantiate(particuleOnHarvest, transform.position, transform.rotation);
        }
    }
    public void ResetGenerator()
    {
        GameInstance.instance.AddScore(userData.users_id, maxFill);

        actualTime = 0;
        isReadyToHarvest = false;

        generatorFill.color = loadingColor;
    }
}
