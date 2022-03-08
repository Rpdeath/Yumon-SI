using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;


class SerializedDeck
{
    public List<int> listOfCardId;
}

public class SaveDeck : MonoBehaviour
{
    bool canclick = true;
    public void onClick()
    {
     
        CreateCollection creator =  GameObject.FindObjectOfType<CreateCollection>();
        if (creator.currentCardsonDeck < creator.maxCardOnDeck) return;
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
