using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActifButtonUi : MonoBehaviour, IClickable
{
    #region Variable

    [Header("1st Square Info")]
    public Image realBackGround;
    public Image coolDownActifImage;
    public GameObject pictoHolderInfo;

    [Header("Effect Square Info")]
    public GameObject effectSquareObj;
    public GameObject pictoHolderEffect;

    [Header("Slider Actif Duration Info")]
    public GameObject sliderObj;
    public Slider selfSlider;

    [Header("Color")]
    public Color playableColor;
    public Color notPlayableColor;
    public Color actifRunningColor;
    public Color emptyActifColor;

    [Header ("Unity setup")]
    public BoxCollider selfCollider;
    public Transform squareEffectDownPos;
    public Transform sliderDownPos;

    [HideInInspector] public Transform startSliderPos;
    [HideInInspector] public Transform startSquareEffectPos;

    [HideInInspector] public StarzActifSysteme selfStarzActif;

    #endregion

    private void Start()
    {
        Ininit();
    }


    private void Update()
    {
        SetActifDurationUi();

        SetActifCooldownUi();

        CheckColor();
    }

    private void Ininit()
    {
        coolDownActifImage.fillAmount = 0f;
        realBackGround.color = emptyActifColor;

        selfSlider.value = 0f;
        startSliderPos = sliderObj.transform;
        startSquareEffectPos = effectSquareObj.transform;
    }


    public void OnClick()
    {
        if (selfStarzActif != null)
        {
            selfStarzActif.StartActifEffect(selfStarzActif.actifId);
        }
    }


    private void SetActifDurationUi()
    {
        if (selfStarzActif != null)
        {
            if (selfStarzActif.actualActifDuration < selfStarzActif.actifDuration)
            {
                selfSlider.value = selfStarzActif.actualActifDuration / selfStarzActif.actifDuration;
            }
        }
    }
    private void SetActifCooldownUi()
    {
        if (selfStarzActif != null)
        {
            if (selfStarzActif.actualCooldown != 0f)
            {
                coolDownActifImage.fillAmount = selfStarzActif.actualCooldown / selfStarzActif.cooldownActif;
            }
        }
    }

    private void CheckColor()
    {
        if (!selfStarzActif.actifIsRunning)
        {
            if (GameInstance.instance.actualGameInfo.manaPlayer1 >= selfStarzActif.actifCost)
            {
                realBackGround.color = playableColor;
            }
            else
            {
                realBackGround.color = notPlayableColor;
            }
        }
        else
        {
            realBackGround.color = actifRunningColor;
        }
    }
}