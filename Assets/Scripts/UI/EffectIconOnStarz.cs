using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectIconOnStarz : MonoBehaviour
{
    public List<Sprite> effectList;
    public StarzData CardData;
    public int effectNum;

    private void Start()
    {
        StartCoroutine(cdUpdate());
    }
    IEnumerator cdUpdate()
    {
        yield return new WaitForSeconds(1);
        UpdateIcons();
        StartCoroutine(cdUpdate());
    }
    private void UpdateIcons()
    {
        effectList = new List<Sprite>();
        foreach (EffectOnUser effect in GameInstance.instance.gameManager.lEffect)
        {
            Sprite sp = GameInstance.instance.effectAssetRef.AssetList_sprite[GameInstance.instance.effectAssetRef.AssetList_id.IndexOf(effect.name)] as Sprite;
            effectList.Add(sp);



            /*if (effect.name == "HypeProductionSameLine" || effect.name == "MomanBoost" || effect.name == "HypeProduction")
            {
                // HypeBuff
            }
            if (effect.name == "StealHypeProduction")
            {
                
            }
            if (effect.name == "PreventSpawnStarz")
            {
                //Lock
            }
            if (effect.name == "PreventHype" && effect.name == "PreventActif")
            {
                //Silence
            }
            if (effect.name == "ManaProduction")
            {
                //ManaBuff
            }
            if (effect.name == "ManaCost")
            {
            }
            if (effect.name == "ManaProduction")
            {
            }
            if (effect.name == "ActifCooldownReduction")
            {
                //SpeedBuff
            }
            if (effect.name == "BuffNextStarz")
            {
            }
            if (effect.name == "HypeConvertor")
            {

            }
            if (effect.name == "MomanBoost")
            {
            }*/

        }
    }
}
