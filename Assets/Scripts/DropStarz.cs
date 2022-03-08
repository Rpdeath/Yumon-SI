using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropStarz : MonoBehaviour, IReceive
{
    [Header ("Ui")]
    public ActifButtonUi uiActif;


    public ScriptReferencement ScriptRef;
    public GameObject actualStarz;
    public Transform spawnPoint;
    public AssetReferencement assetRef;
    public bool allowDrop = true;

    public void DropCard(GameObject obj)
    {
        
        if (actualStarz == null && allowDrop)
        {
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
        actualStarz.GetComponentInChildren<HypeGenerator>().timeToCompletion = card.propertie.speed;
        actualStarz.GetComponentInChildren<StarzActifSysteme>().selfActifUi = uiActif;
        GameInstance.instance.actualGameInfo.manaPlayer1 -= card.propertie.cost;


        //GameInstance.instance.actualGameInfo.actualStarzPlayer1.Add(card);
        
        /*foreach(Tags tag in card.listOfTags)
        {
            switch (tag)
            {
                case Tags.Standard:
                    
                    break;
                case Tags.Start:
                    break;
                case Tags.ZEvent:
                    Passive_zevent pz = actualStarz.GetComponentInChildren<HypeGenerator>().gameObject.AddComponent<Passive_zevent>();
                    break;
                default:
                    break;
            }
        }

        foreach(HypeGenerator starz in GameObject.FindObjectsOfType<HypeGenerator>()){
            starz.gameObject.GetComponent<IPassive>()?.UpdatePassiveOnNewCard(card, GameInstance.instance.actualGameInfo.actualStarzPlayer1, GameInstance.instance.actualGameInfo.actualStarzPlayer2);
        }
*/
        
    }
}
