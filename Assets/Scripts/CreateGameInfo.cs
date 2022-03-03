using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu (fileName = "GameInfo", menuName = "GameInfo")]
public class CreateGameInfo : ScriptableObject
{
    public int scorePlayer1;
    public int scorePlayer2;

    public int manaPlayer1;
    public int manaPlayer2;

    public List<Card> actualStarzPlayer1;
    public List<Card> actualStarzPlayer2;

}
