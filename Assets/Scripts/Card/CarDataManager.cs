using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;
public class CarDataManager : MonoBehaviour
{
    // Start is called before the first frame update

    public Card CardData;
    public AssetReferencement assetref;
    public RarityReferencement commonRef;
    public RarityReferencement limitedRef;
    public RarityReferencement rareRef;
    public RarityReferencement epicRef;
    public RarityReferencement uniqueRef;

    public List<Sprite> listSprite;
    public List<Text> listText;

    public Image portrait;
    public Image frame;
    public Image tagFrame;
    public TextMeshProUGUI tagText;
    public Image passifFrame;
    public TextMeshProUGUI passifText;
    public Image actifFrame;
    public TextMeshProUGUI actifText;
    public TextMeshProUGUI actifCost;
    public Image stroke;
    public Image target;
    public Image allyTargetTOP;
    public Image allyTargetDOWN;
    public Image enemyTargetTOP;
    public Image enemyTargetDown;
    public Image nameFrame;
    public TextMeshProUGUI nameText;
    public Image powerFrame;
    public Image powerHype;
    public Image powerSpeed;
    public TextMeshProUGUI hypeText;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI cardCost;
    



    void Start()
    {
        Image image = portrait;
        //Sprite sp = Resources.Load<Sprite>(CardData.pathOfImage);
        if(assetref.AssetList_id.IndexOf(CardData.pathOfImage)!=-1) image.sprite = assetref.AssetList_sprite[assetref.AssetList_id.IndexOf(CardData.pathOfImage)] as Sprite;        

        switch (CardData.rarity)
        {
            case Rarity.Common:
                listSprite = commonRef.AssetList_sprite;
                break;
            case Rarity.Limited:
                listSprite = limitedRef.AssetList_sprite;
                break;
            case Rarity.Rare:
                listSprite = rareRef.AssetList_sprite;
                break;
            case Rarity.Epic:
                listSprite = epicRef.AssetList_sprite;
                break;
            case Rarity.Unique:
                listSprite = uniqueRef.AssetList_sprite;
                break;
        }        

        ApplySprites();
        ApplyProperties();
        ApplyTargets();
    }

    public void UpdateCArd()
    {
        Image image = portrait;
        //Sprite sp = Resources.Load<Sprite>(CardData.pathOfImage);
        if (assetref.AssetList_id.IndexOf(CardData.pathOfImage) != -1) image.sprite = assetref.AssetList_sprite[assetref.AssetList_id.IndexOf(CardData.pathOfImage)] as Sprite;

        switch (CardData.rarity)
        {
            case Rarity.Common:
                listSprite = commonRef.AssetList_sprite;
                break;
            case Rarity.Limited:
                listSprite = limitedRef.AssetList_sprite;
                break;
            case Rarity.Rare:
                listSprite = rareRef.AssetList_sprite;
                break;
            case Rarity.Epic:
                listSprite = epicRef.AssetList_sprite;
                break;
            case Rarity.Unique:
                listSprite = uniqueRef.AssetList_sprite;
                break;
        }

        ApplySprites();
        ApplyProperties();
        ApplyTargets();
    }

    public void ApplyProperties()
    {
        cardCost.text = CardData.properties.cost.ToString();
        hypeText.text = CardData.properties.hype.ToString();
        speedText.text = CardData.properties.speed.ToString();
        actifCost.text = CardData.properties.actif_cost.ToString();
        nameText.text = CardData.name;
        tagText.text = CardData.listOfTags[0].ToString();
        passifText.text = CardData.properties.passifRule;
        actifText.text = CardData.properties.actifRule;
    }

    public void ApplySprites()
    {
        frame.sprite = listSprite[0];
        tagFrame.sprite = listSprite[1];
        passifFrame.sprite = listSprite[2];
        actifFrame.sprite = listSprite[3];
        stroke.sprite = listSprite[4];
        target.sprite = listSprite[5];
        nameFrame.sprite = listSprite[6];
        powerFrame.sprite = listSprite[7];
        powerHype.sprite = listSprite[8];
        powerSpeed.sprite = listSprite[9];
    }

    public void ApplyTargets()
    {
        switch (CardData.properties.actifId)
        {
            case "amongus_antoinedaniel" :
                allyTargetDOWN.color = Color.grey;
                allyTargetTOP.color = Color.grey;
                enemyTargetDown.color = Color.white;
                enemyTargetTOP.color = Color.white;
                break;
            case "amongus_baghera":
                allyTargetDOWN.color = Color.grey;
                allyTargetTOP.color = Color.grey;
                enemyTargetDown.color = Color.white;
                enemyTargetTOP.color = Color.white;
                break;
            case "amongus_gomart":
                allyTargetDOWN.color = Color.grey;
                allyTargetTOP.color = Color.grey;
                enemyTargetDown.color = Color.white;
                enemyTargetTOP.color = Color.white;
                break;
            case "amongus_jdg":
                allyTargetDOWN.color = Color.grey;
                allyTargetTOP.color = Color.grey;
                enemyTargetDown.color = Color.white;
                enemyTargetTOP.color = Color.white;
                break;
            case "amongus_ponce":
                allyTargetDOWN.color = Color.grey;
                allyTargetTOP.color = Color.grey;
                enemyTargetDown.color = Color.white;
                enemyTargetTOP.color = Color.white;
                break;
            case "kcorp_alderiate":
                allyTargetDOWN.color = Color.white;
                allyTargetTOP.color = Color.white;
                enemyTargetDown.color = Color.grey;
                enemyTargetTOP.color = Color.grey;
                break;
            case "kcorp_kamet0":
                allyTargetDOWN.color = Color.grey;
                allyTargetTOP.color = Color.grey;
                enemyTargetDown.color = Color.grey;
                enemyTargetTOP.color = Color.grey;
                break;
            case "kcorp_kotei":
                allyTargetDOWN.color = Color.white;
                allyTargetTOP.color = Color.white;
                enemyTargetDown.color = Color.grey;
                enemyTargetTOP.color = Color.grey;
                break;
            case "kcorp_rekkless":
                allyTargetDOWN.color = Color.grey;
                allyTargetTOP.color = Color.grey;
                enemyTargetDown.color = Color.grey;
                enemyTargetTOP.color = Color.grey;
                break;
            case "kcorp_sardoche":
                allyTargetDOWN.color = Color.white;
                allyTargetTOP.color = Color.white;
                enemyTargetDown.color = Color.grey;
                enemyTargetTOP.color = Color.grey;
                break;
            case "zevent_boblennon":
                allyTargetDOWN.color = Color.white;
                allyTargetTOP.color = Color.white;
                enemyTargetDown.color = Color.grey;
                enemyTargetTOP.color = Color.grey;
                break;
            case "zevent_maghla":
                allyTargetDOWN.color = Color.white;
                allyTargetTOP.color = Color.white;
                enemyTargetDown.color = Color.grey;
                enemyTargetTOP.color = Color.grey;
                break;
            case "zevent_moman":
                allyTargetDOWN.color = Color.white;
                allyTargetTOP.color = Color.white;
                enemyTargetDown.color = Color.grey;
                enemyTargetTOP.color = Color.grey;
                break;
            case "zevent_ultia":
                allyTargetDOWN.color = Color.white;
                allyTargetTOP.color = Color.grey;
                enemyTargetDown.color = Color.grey;
                enemyTargetTOP.color = Color.grey;
                break;
            case "zevent_zerator":
                allyTargetDOWN.color = Color.grey;
                allyTargetTOP.color = Color.grey;
                enemyTargetDown.color = Color.grey;
                enemyTargetTOP.color = Color.grey;
                break;
        }        
    }

   

}
