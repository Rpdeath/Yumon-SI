using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passive_zevent : Passive
{

    public int SpeedBosstPerTrait=0;

    public void UpdatePassiveOnNewCard(Card generator, List<Card> Ally, List<Card> Ennemy)
    {
        int i = 0;
        foreach(Card card in Ally)
        {
            if ((card.listOfTags[0] == Tags.ZEvent || card.listOfTags[1] == Tags.ZEvent) && card != generator)
            {
                i++;
            }
        }

        GetComponent<HypeGenerator>().boost = 1 + (i*SpeedBosstPerTrait);
    }


}
