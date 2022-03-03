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
        for (int i=0;i<playerDeck.listOfCard.Count; i++)
        {
            blankCards[i].GetComponent<CarDataManager>().CardData = playerDeck.listOfCard[i];
        }
        handManager.hand = blankCards;
        handManager.UpdateHandPoses();
    }
}
