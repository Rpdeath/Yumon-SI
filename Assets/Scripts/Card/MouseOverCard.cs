using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverCard : MonoBehaviour,IHover
{
    public RectTransform cardTransform;
    public bool isHover;
    public GameObject visual;
    public Properties cardProperties;
    public bool setHelperOnce;
    public HelperBox helperBox;

    public void Hover()
    {
        if(setHelperOnce == false)
        {
            setHelperOnce = true;
            cardProperties = gameObject.GetComponent<CarDataManager>().CardData.properties;
            helperBox = gameObject.GetComponent<HelperBox>();

            helperBox.allHelpComments.Add("Coût = " + cardProperties.cost);
            helperBox.allHelpComments.Add("Génère " + cardProperties.hype + " hype in " + cardProperties.speed + "sec");
            helperBox.allHelpComments.Add("Actif coût de " + cardProperties.actif_cost + " : " + cardProperties.actifRule);
            helperBox.allHelpComments.Add("Passif : " + cardProperties.passifRule);

        }
        if (!isHover)
        {
            isHover = true;
            gameObject.transform.GetComponentInParent<Transform>().transform.SetSiblingIndex(15);
            visual.transform.localScale *= 3;
            visual.transform.localPosition += Vector3.up *400f;
            visual.transform.localPosition += Vector3.back * 10;
        }
        


    }

    public void StopHover()
    {
        isHover = false;
        visual.transform.localScale /= 3;
        visual.transform.localPosition -= Vector3.up *400f;
        visual.transform.localPosition -= Vector3.back * 10;
    }
    
}
