using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SaveDeck : MonoBehaviour
{
   
    public void onClick()
    {
     
        CreateCollection creator =  GameObject.FindObjectOfType<CreateCollection>();
        if (creator.currentCardsonDeck < creator.maxCardOnDeck) return;
        Deck dc = GameInstance.instance.userData.deck;
        dc.listOfCard.Clear();
        foreach (Card card in creator.listofSCards)
        {
            dc.listOfCard.Add(card);
        }

        SceneManager.LoadScene("MainMenu");



    }


}
