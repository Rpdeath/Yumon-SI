using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropStarz : MonoBehaviour, IReceive
{
    public GameObject actualStarz;
    public Transform spawnPoint;
    public AssetReferencement assetRef;

    public void DropCard(GameObject obj)
    {
        if (actualStarz != null)
        {
            Card card = obj.GetComponent<CarDataManager>().CardData;
            GameObject gobj = null;
            if (assetRef.AssetList_id.IndexOf(card.pathOfImage) != -1) gobj = assetRef.AssetList_model[assetRef.AssetList_id.IndexOf(card.pathOfImage)] as GameObject;
            SpawnStarz(gobj);
        }
    }

    private void SpawnStarz(GameObject objToSpawn)
    {
        actualStarz = Instantiate(objToSpawn, spawnPoint.position, spawnPoint.rotation);
    }
}
