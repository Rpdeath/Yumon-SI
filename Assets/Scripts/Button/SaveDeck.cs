using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class SaveDeck : MonoBehaviour
{
    bool canclick = true;
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


        
        if (canclick)
        {
            Debug.Log("Card Clicked : " + JsonUtility.ToJson(dc));

            StartCoroutine(Request("yumon.rpdeath.com/edit/deck", dc));
            canclick = false;
        }


    }

    IEnumerator Request(string url, Deck data)
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
