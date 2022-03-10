using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActifButtonUi : MonoBehaviour, IClickable
{
    #region Variable

    [Header("1st Square Info")]
    public Image realBackGround;
    public Image coolDownActifImage;
    public GameObject starCostInfo;
    public TextMeshProUGUI costText;
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
        if (selfStarzActif != null)
        {
            SetActifDurationUi();
            SetActifCooldownUi();
            CheckColor();
            CheckStarCostInfo();
        }
    }

    private void Ininit()
    {
        coolDownActifImage.fillAmount = 0f;
        realBackGround.color = emptyActifColor;

        selfSlider.value = 0f;
        startSliderPos = sliderObj.transform;
        startSquareEffectPos = effectSquareObj.transform;

        starCostInfo.SetActive(false);
    }


    public void OnClick()
    {
        if (selfStarzActif != null)
        {
            selfStarzActif.StartActifEffect(selfStarzActif.selfCard.properties.actifId);
        }
    }


    private void SetActifDurationUi()
    {
        if (selfStarzActif.actualActifDuration < selfStarzActif.selfCard.properties.actifDuration)
        {
            selfSlider.value = selfStarzActif.actualActifDuration / selfStarzActif.selfCard.properties.actifDuration;
        }
    }
    private void SetActifCooldownUi()
    {
        if (selfStarzActif.actualCooldown != 0f)
        {
            coolDownActifImage.fillAmount = selfStarzActif.actualCooldown / selfStarzActif.selfCard.properties.cooldown;
        }
    }

    private void CheckStarCostInfo()
    {
        starCostInfo.SetActive(true);
        costText.text = selfStarzActif.selfCard.properties.actif_cost.ToString();
    }

    private void CheckColor()
    {
        if (!selfStarzActif.actifIsRunning)
        {
            if (GameInstance.instance.actualGameInfo.manaPlayer1 >= selfStarzActif.selfCard.properties.actif_cost)
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
