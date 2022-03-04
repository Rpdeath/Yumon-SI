using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IPassive
{
    void ProcPassive(Card generator,Deck Ally,Deck Ennemy);
}

public class Passive : MonoBehaviour, IPassive
{

    float speedRatio = 1f;
    Card generator;
    Deck Ally;
    Deck Ennemy;
    private void Start()
    {
        GetComponent<HypeGenerator>().boost = speedRatio;
    }

    public void UpdatePassiveOnNewCard()
    {

    }

    public void ProcPassive(Card generator,Deck Ally, Deck Ennemy)
    {
        
    }

}
