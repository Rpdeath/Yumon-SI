using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SaveDeck : MonoBehaviour
{
   
    public void onClick()
    {
        CreateCollection cr = GameObject.FindObjectOfType<CreateCollection>();
        Deck dc = new Deck();

        foreach (GameObject card in cr.listofCards)
        {
            Card c = card.GetComponent<CarDataManager>().CardData;
            Card nc = (Card)ScriptableObject.CreateInstance("Card");
            JsonUtility.FromJsonOverwrite(JsonUtility.ToJson(c), nc);
            dc.listOfCard.Add(nc);
        }

        GameInstance.instance.userData.currentDeck = dc;
        SceneManager.LoadScene("MainMenu");


    }


}
