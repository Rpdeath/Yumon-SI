using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Tags
{
    Standard,
    Start,
    ZEvent
}

public enum Rarity
{
    Common,
    Limited,
    Rare,
    Epic,
    Unique
}

[CreateAssetMenu(fileName = "Card_0", menuName = "Create a Card", order = 1)]
public class Card : ScriptableObject
{
    public string name;
    public Object assetReference;
    public List<Tags> listOfTags;
    public Rarity rarity;

}
