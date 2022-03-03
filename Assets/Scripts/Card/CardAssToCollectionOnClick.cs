using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Networking;
public class CardAssToCollectionOnClick : MonoBehaviour,IClickable
{
    public Card CardData;
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

        Debug.Log("Card Clicked : "+ JsonUtility.ToJson(CardData));

        StartCoroutine(Request("localhost:8080/YumonAPI/create/nft", CardData));
    }

    IEnumerator Request(string url, Card data)
    {
        //Debug.Log(JsonUtility.ToJson(data));
        UnityWebRequest uwr = UnityWebRequest.Get(url + "?data=" + JsonUtility.ToJson(data));

        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            //Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            //Debug.Log("Received: " + uwr.downloadHandler.text);
        }




    }

}
