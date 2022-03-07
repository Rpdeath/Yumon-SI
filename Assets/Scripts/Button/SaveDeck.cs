using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SaveDeck : MonoBehaviour
{
   
    public void onClick()
    {
     
        CreateCollection creator =  GameObject.FindObjectOfType<CreateCollection>();
        if (creator.currentCardsonDeck < creator.maxCardOnDeck) return;
        Deck dc = (Deck)ScriptableObject.CreateInstance("Deck");
        foreach (Card card in creator.listofSCards)
        {
            dc.listOfCard.Add(card);
        }

        GameInstance.instance.userData.deck = dc;



    }


}
