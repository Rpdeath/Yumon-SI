using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropStarz : MonoBehaviour, IReceive
{
    public GameObject actualStarz;
    public Transform spawnPoint;

    public void DropCard(GameObject obj)
    {
        if (actualStarz != null)
        {
            SpawnStarz(obj.GetComponent<CarDataManager>().CardData.assetReference as GameObject);
        }
    }

    private void SpawnStarz(GameObject objToSpawn)
    {
        actualStarz = Instantiate(objToSpawn, spawnPoint.position, spawnPoint.rotation);
    }
}
