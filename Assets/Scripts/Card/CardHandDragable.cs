using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CardHandDragable : MonoBehaviour, IDragable
{

    private bool isDraged = false;
    public bool isDraggable = false;
    Camera gameCamera;
    RectTransform rectT;
    public CarHandPostions cardHand;
    public Card card;
    public GameObject panel;
    private void Start()
    {
        rectT = GetComponent<RectTransform>();
        card = GetComponent<CarDataManager>().CardData;
    }
    void Update()
    {

        float cost = card.properties.cost;
        foreach(EffectOnUser effect in GameInstance.instance.gameManager.lEffect)
        {
            if(effect.name == "ManaCost")
            {
                List<string> Stags = new List<string>();
                foreach(Tags tag in card.listOfTags)
                {
                    switch (tag)
                    {
                        case Tags.Standard:
                            break;
                        case Tags.Start:
                            break;
                        case Tags.KCorp:
                            Stags.Add("KCorp");
                            break;
                        case Tags.AmongUs:
                            Stags.Add("AmongUs");
                            break;
                        case Tags.ZEvent:
                            Stags.Add("ZEvent");
                            break;
                        default:
                            break;
                    }
                }

                foreach(string stag in Stags)
                {
                    if (stag == effect.stringBuff)
                    {
                        cost = cost * (1 - effect.floatBuff);
                    }
                }
            }
        }

        bool canLaunchCard = true;
        foreach (EffectOnUser effect in GameInstance.instance.gameManager.lEffectEnnemy)
        {
            if (effect.name == "PreventSpawnStarz")
            {
                canLaunchCard = false;
            }
        }


        if (cost<= GameInstance.instance.actualGameInfo.manaPlayer1 && canLaunchCard)
        {
            isDraggable = true;
            
        }
        else
        {
            isDraggable = false;
        }
        panel.active= !isDraggable;


        if (isDraged)
        {
            if (gameCamera == null) { gameCamera = Camera.main; }
            Vector3 pz = Camera.main.ScreenToViewportPoint(Mouse.current.position.ReadValue());
            pz.y = -500 + 1000*pz.y;
            pz.x = -1000 + 2000 * pz.x;

            rectT.transform.localPosition = pz ;


        }
    }

    public void StartDrag()
    {
        isDraged = true;
        GetComponent<BoxCollider>().enabled = false;
        
    }

    
    public void StopDrag(bool Destroy=false)
    {
        
        if (Destroy)
        {

            cardHand.RemoveCard(gameObject);
        }
        else
        {
            cardHand.UpdateHandPoses();
            isDraged = false;
            GetComponent<BoxCollider>().enabled = true;
        }



    }
}
