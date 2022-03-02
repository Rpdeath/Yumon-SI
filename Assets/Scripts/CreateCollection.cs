using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCollection : MonoBehaviour
{
    GameInstance gi;
    public Object prefab;

    private void Start()
    {
        gi = Object.FindObjectOfType<GameInstance>();

        //Debug.Log(JsonUtility.ToJson(gi.userData));
        foreach (Nft nft in gi.userData.nfts)
        {
            if (JsonUtility.ToJson(nft) != "")
            {
                
                Card card = (Card)ScriptableObject.CreateInstance("Card");
                JsonUtility.FromJsonOverwrite(nft.nft_data, card);
                Debug.Log(JsonUtility.ToJson(card));
                GameObject clone = (GameObject) Instantiate(prefab,transform);
                clone.GetComponent<CarDataManager>().CardData = card;


            }
        }
    }
}
