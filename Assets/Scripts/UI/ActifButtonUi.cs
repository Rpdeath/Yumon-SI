using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActifButtonUi : MonoBehaviour, IClickable
{
    #region Variable

    [Header("1st Square Info")]
    public Image coolDownActifImage;
    public GameObject pictoHolderInfo;

    [Header("Effect Square Info")]
    public GameObject effectSquareObj;
    public GameObject pictoHolderEffect;

    [Header("Slider Actif Duration Info")]
    public GameObject sliderObj;
    public Slider selfSlider;

    [Header ("Unity setup")]
    public BoxCollider selfCollider;
    public Transform squareEffectDownPos;
    public Transform sliderDownPos;

    [HideInInspector]public StarzActifSysteme selfStarzActif;
    #endregion


    public void OnClick()
    {
        selfStarzActif.StartActifEffect(selfStarzActif.actifId);
    }

    private void Update()
    {
        SetActifCooldownUi();
    }

    public void SetActifCooldownUi()
    {
        if (selfStarzActif != null)
        {
            coolDownActifImage.fillAmount = selfStarzActif.actualCooldown / selfStarzActif.cooldownActif;
        }
        else
        {
            coolDownActifImage.fillAmount = 0f;
        }
    }
}
