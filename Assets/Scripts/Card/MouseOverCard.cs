using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverCard : MonoBehaviour,IHover
{
    public RectTransform cardTransform;
    public bool isHover;
    RectTransform rectT;

    private void Start()
    {
        rectT = GetComponent<RectTransform>();
    }
    public void Hover()
    {
        if (!isHover)
        {
            isHover = true;
            
            rectT.transform.position += Vector3.up * 10f;
        }
        


    }

    public void StopHover()
    {
        isHover = false;
        rectT.transform.position -= Vector3.up * 10f;
    }
    
}
