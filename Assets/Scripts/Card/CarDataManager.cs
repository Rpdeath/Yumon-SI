using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;
using UnityEngine.Networking;
using UnityEngine.UI;
public class CarDataManager : MonoBehaviour
{
    // Start is called before the first frame update

    public Card CardData;
    public AssetReferencement assetref;
    void Start()
    {
        Image image = this.GetComponent<Image>();
        //Sprite sp = Resources.Load<Sprite>(CardData.pathOfImage);
        if(assetref.AssetList_id.IndexOf(CardData.pathOfImage)!=-1) image.sprite = assetref.AssetList_sprite[assetref.AssetList_id.IndexOf(CardData.pathOfImage)] as Sprite;
        
    }
    public void UpdateCArd()
    {
        Image image = this.GetComponent<Image>();
        //Sprite sp = Resources.Load<Sprite>(CardData.pathOfImage);
        if (assetref.AssetList_id.IndexOf(CardData.pathOfImage) != -1) image.sprite = assetref.AssetList_sprite[assetref.AssetList_id.IndexOf(CardData.pathOfImage)] as Sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

}
