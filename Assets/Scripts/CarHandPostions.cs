using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHandPostions : MonoBehaviour
{
    public List<GameObject> hand = new List<GameObject>();
    public int handLenght;
    public Vector2 cardSize;


    private void Update()
    {
        if (hand.Count != handLenght)
        {
            UpdateHandPoses();
        }
    }

    public void RemoveCard(GameObject card)
    {
        hand.Remove(card);
        handLenght -= 1;
        UpdateHandPoses();
        Destroy(card);
    }

    public void UpdateHandPoses()
    {
        
        handLenght = hand.Count;
        float angle = 3;
        if (handLenght == 0)
            return;


            for (int i = 0; i < handLenght; i++)
        {
            if (i < handLenght / 2)
            {
                hand[i].GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition - cardSize * i - cardSize/2;

                hand[i].GetComponent<RectTransform>().rotation = Quaternion.identity;
                hand[i].GetComponent<RectTransform>().rotation = Quaternion.Euler(25, 0, angle + angle * i + (handLenght % 2)*angle);

                hand[i].GetComponent<RectTransform>().anchoredPosition -= Vector2.up * (10 + 10*i);
            }
            else
            {
                hand[i].GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition + cardSize * (handLenght - i) - cardSize/2;
                hand[i].GetComponent<RectTransform>().rotation = Quaternion.identity;
                hand[i].GetComponent<RectTransform>().rotation = Quaternion.Euler(25, 0, -angle * (handLenght - i) + (handLenght % 2) * angle);
                hand[i].GetComponent<RectTransform>().anchoredPosition -= Vector2.up * ( 10 * (handLenght - i));
            }
        }
    }
    public void StartHand()
    {
        cardSize = Vector2.right * (hand[0].GetComponent<RectTransform>().rect.width + 2f);
        handLenght = hand.Count;
        UpdateHandPoses();
    }
}
