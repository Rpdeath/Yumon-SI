using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCollectionSelectOnClick : MonoBehaviour,IClickable
{
    bool inDeck=false;
    public CreateCollection collectionCreator;

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
        if (collectionCreator.currentCardsonDeck < collectionCreator.maxCardOnDeck || inDeck)
        {
            inDeck = !inDeck;

            if (inDeck)
            {
                GetComponent<RectTransform>().localScale = new Vector3(1.2f, 1.2f, 1);
                collectionCreator.currentCardsonDeck += 1;
                //Debug.Log(JsonUtility.ToJson(GetComponent<CarDataManager>().CardData));
            }
            else
            {
                GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1);
                collectionCreator.currentCardsonDeck -= 1;

            }
            collectionCreator.count.text = collectionCreator.currentCardsonDeck+"/"+ collectionCreator.maxCardOnDeck;
        }
    }
}
