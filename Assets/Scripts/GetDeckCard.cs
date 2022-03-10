using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDeckCard : MonoBehaviour
{
    public Deck playerDeck;
    public List<GameObject> blankCards;
    public CarHandPostions handManager;

    private void Start()
    {
        CarHandPostions carHand = GetComponent<CarHandPostions>();
        for (int i=0;i<playerDeck.listOfCard.Count; i++)
        {
            blankCards[i].GetComponent<CarDataManager>().CardData = playerDeck.listOfCard[i];
            blankCards[i].GetComponent<CarDataManager>().UpdateCArd();
            blankCards[i].GetComponent<CardHandDragable>().cardHand = carHand;
            blankCards[i].GetComponent<CardHandDragable>().card = playerDeck.listOfCard[i];
        }
        handManager.hand = blankCards;
        handManager.StartHand();
    }
}
