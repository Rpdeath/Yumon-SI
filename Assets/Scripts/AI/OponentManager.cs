using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OponentManager : MonoBehaviour
{

    public Deck startingDeck;

    public List<Card> cardInHand;
    public GameObject[] columns;
    public List<GameObject> starzPosed;


    public void DeckReady()
    {
        cardInHand = startingDeck.listOfCard;
        columns = new GameObject[6];
        foreach (GameObject columnItem in GameObject.FindGameObjectsWithTag("ColumnOponent"))
        {
            ColumnPosition columnPos = columnItem.GetComponent<ColumnPosition>();
            columns[columnPos.x + (columnPos.y * 3)]= columnItem;
        }
    }

    public void DropCardOnColumn(int x,int y)
    {

    }



}
