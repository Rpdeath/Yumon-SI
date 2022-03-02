using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Networking;
using UnityEngine.UI;
public class CarDataManager : MonoBehaviour,IClickable
{
    // Start is called before the first frame update

    public Card CardData;

    void Start()
    {
        Image image = this.GetComponent<Image>();
        image.sprite = (Sprite)CardData.assetReference;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {

        //Debug.Log("Card Clicked : "+ JsonUtility.ToJson(CardData));

        StartCoroutine(Request("localhost:8080/YumonAPI/create/nft", CardData));
    }

    IEnumerator Request(string url, Card data)
    {
        WWWForm form = new WWWForm();
/*        string myData = "?";
        myData += "\"name\"=\"" + data.name + "\"&";
        myData += "\"inGameAssetReference\"=" + data.assetReference.GetInstanceID() + "&";
        myData += "listOfTags={";
        int i = 0;
        foreach (Tags tags in data.listOfTags)
        {
            i++;
            myData += tags.ToString();
            if(i<data.listOfTags.Count) myData+=",";
            
        }
        myData += "}&";
        myData += "\"rarity\"=" + data.rarity + "&";
        myData += "";*/
        Debug.Log(JsonUtility.ToJson(data));
        UnityWebRequest uwr = UnityWebRequest.Get(url+"?data="+JsonUtility.ToJson(data));

        yield return uwr.SendWebRequest();

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
