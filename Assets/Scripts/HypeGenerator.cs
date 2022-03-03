using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HypeGenerator : MonoBehaviour
{
    private Deck_Place_Manager place;
    public Image generatorFill;

    public float actualTime;
    public float maxFill;
    public float timeToCompletion;
    public float boost;

    [HideInInspector] public bool isReadyToHarvest = false;

    private void Start()
    {
        place = GetComponent<Deck_Place_Manager>();
    }

    public void InitGenerator(float time)
    {
        timeToCompletion = time;
        actualTime = timeToCompletion;
    }

    public void Update()
    {
        if (place.CardPlaced != null && isReadyToHarvest == false)
        {
            StartGeneratingHype();
        }
    }

    public void StartGeneratingHype()
    {
        if (actualTime >= 0)
        {
            actualTime -= Time.deltaTime * boost;
            generatorFill.fillAmount = 1 - (1 / actualTime);
        }
        else
        {
            isReadyToHarvest = true;
        }
    }

    // Appeler quand on click sur le Starz et qu'il est ready to harvest
    public void ResetGenerator()
    {      
        actualTime = timeToCompletion;
        isReadyToHarvest = false;
    }
}
