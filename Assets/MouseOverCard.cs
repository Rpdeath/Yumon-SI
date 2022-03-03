using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverCard : MonoBehaviour,IHover
{
    public RectTransform cardTransform;
    public bool isHover;
    public void Hover()
    {
        if (isHover == false)
        {
            float initialRotation = cardTransform.rotation.z;
            Vector3 initialPosition = cardTransform.anchoredPosition;
            isHover = true;
        }
        Debug.Log("coucou");
        cardTransform.rotation = Quaternion.identity;
        cardTransform.anchoredPosition -= 200 * Vector2.up; 
    }
}
