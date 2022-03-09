using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Difficulty : int
{
    EASY = 5,
    NORMAL = 3,
    HARD = 1
}

public class OponentManager : MonoBehaviour
{

    public Deck startingDeck;

    public Difficulty difficulty;

    public List<Card> cardInHand;
    public GameObject[] columns;
    public List<GameObject> starzPosed;


    public float mana=0;

    private void Start()
    {
        StartCoroutine(LaunchCard());
        StartCoroutine(CheckForHarvest());
        StartCoroutine(AddMana());
    }



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

    public void DropCardOnColumn(int x,int y,Card card)
    {
        DropStarz dropStarz = columns[x + (y * 3)].GetComponentInChildren<DropStarz>();

        GameObject starz = dropStarz.AIDropCard(card);
        starz.GetComponentInChildren<StarzActifSysteme>().UsedByPlayer = false;
        starz.GetComponentInChildren<HypeGenerator>().UsedByPlayer = false;
        starzPosed.Add(starz);

    }

    public bool Harvest(int x, int y)
    {
        if (columns[x + (y * 3)].GetComponentInChildren<DropStarz>().actualStarz.GetComponentInChildren<HypeGenerator>().isReadyToHarvest)
        {
            columns[x + (y * 3)].GetComponentInChildren<DropStarz>().actualStarz.GetComponentInChildren<HypeGenerator>().OnClick();
            return true;
        }
        return false;
    }


    IEnumerator LaunchCard()
    {
        yield return new WaitForSeconds((float)difficulty);
        bool canLaunchCard = true;
        foreach (EffectOnUser effect in GameInstance.instance.gameManager.lEffectEnnemy)
        {
            if (effect.name == "PreventSpawnStarz")
            {
                canLaunchCard = false;
            }
        }
        if (canLaunchCard)
        {
            foreach (Card card in cardInHand)
            {
                if (mana >= card.propertie.cost)
                {
                    foreach (GameObject colu in columns)
                    {
                        if (colu.GetComponentInChildren<DropStarz>().actualStarz == null)
                        {
                            DropCardOnColumn(colu.GetComponent<ColumnPosition>().x, colu.GetComponent<ColumnPosition>().y, card);
                            mana -= card.propertie.cost;
                            break;
                        }
                    }
                }
            }
        }
        StartCoroutine(LaunchCard());



    }

    IEnumerator CheckForHarvest()
    {
        yield return new WaitForSeconds(0.7f);
        int nb = 0;
        foreach (GameObject colu in columns)
        {
            if (colu.GetComponentInChildren<DropStarz>().actualStarz != null)
            {
                if(Harvest(colu.GetComponent<ColumnPosition>().x, colu.GetComponent<ColumnPosition>().y))
                {
                    nb += 1;
                    if(nb>=2)break;
                }
                
            }
        }
        StartCoroutine(CheckForHarvest());
    }


    IEnumerator AddMana()
    {
        yield return new WaitForSeconds((float)difficulty/2);
        float boost = 1;
        foreach (EffectOnUser effect in GameInstance.instance.gameManager.lEffectEnnemy)
        {
            if (effect.name == "ManaProduction")
            {
                boost = boost - effect.floatBuff;
            }
        }
        mana += 1 * boost;
        StartCoroutine(AddMana());
    }


}
