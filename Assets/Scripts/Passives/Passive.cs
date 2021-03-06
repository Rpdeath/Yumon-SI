using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IPassive
{
    void UpdatePassiveOnNewCard(Card generator, List<Card> Ally, List<Card> Ennemy);
    void ProcPassive(Card generator, List<Card> Ally, List<Card> Ennemy);
}

public class Passive : MonoBehaviour, IPassive
{

    float speedRatio = 1f;
    
    private void Start()
    {
        GetComponent<HypeGenerator>().boost = speedRatio;
    }

    public void UpdatePassiveOnNewCard(Card generator, List<Card> Ally, List<Card> Ennemy)
    {

    }

    public void ProcPassive(Card generator, List<Card> Ally, List<Card> Ennemy)
    {
        
    }

}
