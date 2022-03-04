using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverCard : MonoBehaviour,IHover
{
    public RectTransform cardTransform;
    public bool isHover;
    public void Hover()
    {
        if (!isHover)
        {
            isHover = true;
            transform.position += Vector3.up * 5f;
        }
        


    }

    public void StopHover()
    {
        isHover = false;
        transform.position -= Vector3.up * 5f;
    }
    
}
