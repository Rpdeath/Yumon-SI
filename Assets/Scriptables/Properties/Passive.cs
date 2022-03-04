using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IPassive
{
    void ProcPassive(Card generator,Deck Ally,Deck Ennemy);
}

public class Passive : MonoBehaviour, IPassive
{
   

    public void ProcPassive(Card generator,Deck Ally, Deck Ennemy)
    {
        
    }

}
