using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Tags
{
    Standard,
    Start,
    KCorp,
    AmongUs,
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
    public int id=0;
    public string name;
    public string pathOfImage;
    public List<Tags> listOfTags;
    public Rarity rarity;
    public Properties propertie;
    

}
