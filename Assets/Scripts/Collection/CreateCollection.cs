using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateCollection : MonoBehaviour
{
    GameInstance gi;
    public Object prefab;
    public List<GameObject> listofCards;
    public int maxCardOnDeck=10;
    public int currentCardsonDeck=0;
    public Text count;

    public User usData;

    // {"id":"83","name":"Bob Lennon","pathOfImage":"bob_lennon","listOfTags":[2],"rarity":1}
    private void Start()
    {
<<<<<<< Updated upstream
        gi = GameInstance.instance;
        if (gi == null)
        {
            gi = new GameInstance();
            gi.userData = usData;
        }
        int perline = 6;
=======
        gi = Object.FindObjectOfType<GameInstance>();
        int perline = 5;
>>>>>>> Stashed changes
        Vector3 pos = transform.position- (Vector3.right*((perline/2)+3));
        
        int i = 0;
        Debug.Log(JsonUtility.ToJson(gi.userData));
        foreach (Nft nft in gi.userData.nfts)
        {
            if (JsonUtility.ToJson(nft) != "")
            {
                
                Card card = (Card)ScriptableObject.CreateInstance("Card");
                JsonUtility.FromJsonOverwrite(nft.nft_data, card);
                //Debug.Log(JsonUtility.ToJson(card));
                GameObject clone = (GameObject) Instantiate(prefab,transform);
                clone.GetComponent<CarDataManager>().CardData = card;
                clone.GetComponent<CardCollectionSelectOnClick>().collectionCreator = this;
<<<<<<< Updated upstream
                clone.transform.position = pos+(Vector3.right*3f);
=======
                clone.transform.position = pos + Vector3.right*2f;
>>>>>>> Stashed changes
                pos = clone.transform.position;
                listofCards.Add(clone);
                i++;
            }
            if (i >= perline)
            {
                i = 0;
                pos.x = transform.position.x - ((perline / 2) + 3);
<<<<<<< Updated upstream
                pos.y -= 3f;
=======
                pos.y -= 4f;
>>>>>>> Stashed changes
            }
        }

        //transform.position = new Vector3(0, 0, 0);
        

    }
}
