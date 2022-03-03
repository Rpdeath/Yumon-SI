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

    void Start()
    {
        Image image = this.GetComponent<Image>();
        Debug.Log(CardData.assetReference);
        image.sprite = (Sprite)CardData.assetReference;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

}
