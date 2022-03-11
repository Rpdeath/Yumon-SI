using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Difficulty : int
{
    EASY = 4,
    NORMAL = 3,
    HARD = 2
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
       
        
    }


    public void StartAI()
    {
        startingDeck = GameInstance.instance.userDataEnemy.deck;
        StartCoroutine(LaunchCard());
        StartCoroutine(CheckForHarvest());
        StartCoroutine(AddMana());
        difficulty = GameInstance.instance.difficulty;

    }


    public void DeckReady()
    {
        cardInHand = new List<Card>(startingDeck.listOfCard);
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
            bool cardplaced = false;
            int cardToRemove = -1;
            foreach (Card card in cardInHand)
            {

                if (mana >= card.properties.cost && !cardplaced)
                {
                    foreach (GameObject colu in columns)
                    {
                        if (colu.GetComponentInChildren<DropStarz>().actualStarz == null && !cardplaced)
                        {
                            DropCardOnColumn(colu.GetComponent<ColumnPosition>().x, colu.GetComponent<ColumnPosition>().y, card);
                            mana -= card.properties.cost;
                            
                            cardplaced = true;
                            break;
                        }
                    }
                    if (cardplaced == true)
                    {
                        cardToRemove = cardInHand.IndexOf(card);
                    }
                }
            }
            if(cardToRemove != -1 )
            {
                cardInHand.RemoveAt(cardToRemove);
            }
        }
        StartCoroutine(LaunchCard());



    }

    IEnumerator CheckForHarvest()
    {
        yield return new WaitForSeconds((float)difficulty*0.5f);
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
        switch (difficulty)
        {
            case Difficulty.EASY:
                yield return new WaitForSeconds(4f);
                break;
            case Difficulty.NORMAL:
                yield return new WaitForSeconds(3f);
                break;
            case Difficulty.HARD:
                yield return new WaitForSeconds(2f);
                break;
            default:
                yield return new WaitForSeconds(3f);
                break;
        }
        
        float boost = 1;
        foreach (EffectOnUser effect in GameInstance.instance.gameManager.lEffectEnnemy)
        {
            if (effect.name == "ManaProduction")
            {
                boost = boost - effect.floatBuff;
            }
        }
        mana += 1 ;
        StartCoroutine(AddMana());
    }


}
