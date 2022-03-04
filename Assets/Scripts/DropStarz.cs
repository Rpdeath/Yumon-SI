using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropStarz : MonoBehaviour, IReceive
{
    public ScriptReferencement ScriptRef;
    public GameObject actualStarz;
    public Transform spawnPoint;
    public AssetReferencement assetRef;
    public bool allowDrop = true;

    public void DropCard(GameObject obj)
    {
        
        if (actualStarz == null && allowDrop)
        {
            Debug.Log("Drop Starz");
            Card card = obj.GetComponent<CarDataManager>().CardData;
            GameObject gobj = null;
            if (assetRef.AssetList_id.IndexOf(card.pathOfImage) != -1) gobj = assetRef.AssetList_model[assetRef.AssetList_id.IndexOf(card.pathOfImage)] as GameObject;
            SpawnStarz(gobj,card);
            obj.GetComponent<IDragable>()?.StopDrag(true);
        }

        GetComponent<BoxCollider>().enabled = false;
    }

    public void AIDropCard(Card card)
    {

    }

    private void SpawnStarz(GameObject objToSpawn,Card card)
    {
        actualStarz = Instantiate(objToSpawn, spawnPoint.position, spawnPoint.rotation);
        
        foreach(Tags tag in card.listOfTags)
        {
            switch (tag)
            {
                case Tags.Standard:
                    
                    break;
                case Tags.Start:
                    break;
                case Tags.ZEvent:
                    actualStarz.AddComponent<Passive_zevent>();
                    break;
                default:
                    break;
            }

        }
        
    }
}
