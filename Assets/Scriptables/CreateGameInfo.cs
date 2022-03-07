using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[CreateAssetMenu (fileName = "GameInfo", menuName = "GameInfo")]
public class CreateGameInfo : ScriptableObject
{
    public int maxScore = 1000;

    public Slider sliderPlayer1;
    public Slider sliderPlayer2;

    public Image handle1;


    public int scorePlayer1;
    public int scorePlayer2;

    public int manaPlayer1;
    public int manaPlayer2;

    public List<Card> actualStarzPlayer1;
    public List<Card> actualStarzPlayer2;

}
