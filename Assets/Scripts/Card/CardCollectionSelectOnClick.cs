using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCollectionSelectOnClick : MonoBehaviour,IClickable
{
    bool inDeck=false;
    public CreateCollection collectionCreator;
    Vector3 startScale;
    RectTransform rt;
    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();
        startScale = rt.localScale;
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
                GetComponent<RectTransform>().localScale = startScale*1.5f;
                collectionCreator.currentCardsonDeck += 1;
                //Debug.Log(JsonUtility.ToJson(GetComponent<CarDataManager>().CardData));
            }
            else
            {
                GetComponent<RectTransform>().localScale = startScale;
                collectionCreator.currentCardsonDeck -= 1;

            }
            collectionCreator.count.text = collectionCreator.currentCardsonDeck+"/"+ collectionCreator.maxCardOnDeck;
        }
    }
}
