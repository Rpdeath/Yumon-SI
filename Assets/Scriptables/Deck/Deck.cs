using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Deck_AI", menuName = "Create a Deck For Ai", order = 1)]
public class Deck : ScriptableObject
{
    public List<Card> listOfCard;
}
