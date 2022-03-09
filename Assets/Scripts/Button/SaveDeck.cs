using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
<<<<<<< HEAD


class SerializedDeck
{
    public List<int> listOfCardId;
}
=======
>>>>>>> parent of 2fe7cd3 (ColonneLumiereStillWIP)

public class SaveDeck : MonoBehaviour
{
    bool canclick = true;
    public void onClick()
    {
     
        CreateCollection creator =  GameObject.FindObjectOfType<CreateCollection>();
        if (creator.currentCardsonDeck < creator.maxCardOnDeck) return;
<<<<<<< HEAD
        Debug.Log(GameInstance.instance.userData.deck);
        GameInstance.instance.userData.deck.listOfCard = new List<Card>();
        GameInstance.instance.userData.deck.listOfCard.Clear();
        SerializedDeck sDeck = new SerializedDeck();
        sDeck.listOfCardId = new List<int>();
        foreach (Card card in creator.listofSCards)
        {
            GameInstance.instance.userData.deck.listOfCard.Add(card);
            sDeck.listOfCardId.Add(card.id);
        }


        
        if (canclick)
        {
            

            Debug.Log("Save Clicked : " + JsonUtility.ToJson(GameInstance.instance.userData.deck));

            StartCoroutine(Request("yumon.rpdeath.com/edit/decks", sDeck));
            canclick = false;
        }


    }

    IEnumerator Request(string url, SerializedDeck data)
=======
        Deck dc = GameInstance.instance.userData.deck;
        dc.listOfCard.Clear();
        foreach (Card card in creator.listofSCards)
        {
            dc.listOfCard.Add(card);
        }


        
        if (canclick)
        {
            Debug.Log("Card Clicked : " + JsonUtility.ToJson(dc));

            StartCoroutine(Request("yumon.rpdeath.com/edit/deck", dc));
            canclick = false;
        }


    }

    IEnumerator Request(string url, Deck data)
>>>>>>> parent of 2fe7cd3 (ColonneLumiereStillWIP)
    {
        Debug.Log(url + "?owner=" + GameInstance.instance.userData.users_id +"&deck_id="+ GameInstance.instance.userData.deck.deck_id + "&data=" + JsonUtility.ToJson(data));
        UnityWebRequest uwr = UnityWebRequest.Get(url + "?owner=" + GameInstance.instance.userData.users_id + "&deck_id=" + GameInstance.instance.userData.deck.deck_id + "&data=" + JsonUtility.ToJson(data));

        yield return uwr.SendWebRequest();
        canclick = true;
        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Received: " + uwr.downloadHandler.text);
            SceneManager.LoadScene("MainMenu");
        }
        



    }


}
