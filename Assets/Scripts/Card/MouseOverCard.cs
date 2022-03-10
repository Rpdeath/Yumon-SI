using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverCard : MonoBehaviour,IHover
{
    public RectTransform cardTransform;
    public bool isHover;
    public GameObject visual;
    public void Hover()
    {
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
