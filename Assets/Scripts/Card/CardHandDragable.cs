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
    Card card;
    public GameObject panel;
    private void Start()
    {
        rectT = GetComponent<RectTransform>();
        card = GetComponent<CarDataManager>().CardData;
    }
    void Update()
    {


        if(card.propertie.cost<= GameInstance.instance.actualGameInfo.manaPlayer1)
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
