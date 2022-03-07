using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Networking;
public class CardAssToCollectionOnClick : MonoBehaviour,IClickable
{
    public Card CardData;
    bool canclick = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        if (canclick)
        {
            Debug.Log("Card Clicked : " + JsonUtility.ToJson(CardData));

            StartCoroutine(Request("portfolio.michaelabid.com/YumonAPI/create/nft", CardData));
            canclick = false;
        }
    }

    IEnumerator Request(string url, Card data)
    {
        Debug.Log(url + "?owner=" + GameInstance.instance.userData.users_id + "&data=" + JsonUtility.ToJson(data));
        UnityWebRequest uwr = UnityWebRequest.Get(url + "?owner="+GameInstance.instance.userData.users_id+"&data=" + JsonUtility.ToJson(data));

        yield return uwr.SendWebRequest();
        canclick = true;
        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Received: " + uwr.downloadHandler.text);
        }




    }

}
