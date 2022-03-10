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

    // Update is called once per frame
    void Update()
    {
        
    }

   

}
