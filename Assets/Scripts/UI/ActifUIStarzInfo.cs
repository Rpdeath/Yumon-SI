using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "UiActifInfo", menuName = "UiActifInfo")]
public class ActifUIStarzInfo : ScriptableObject
{
    [Header("1st Square Info")]
    public Image coolDownActifImage;
    public GameObject pictoHolderInfo;

    [Header("Effect Square Info")]
    public GameObject effectSquare;
    public GameObject pictoHolderEffect;

    [Header("Slider Actif Duration Info")]
    public GameObject sliderObj;
    public Slider selfSlider;

}
