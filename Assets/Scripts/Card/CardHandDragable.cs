using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CardHandDragable : MonoBehaviour, IDragable
{

    private bool isDraged = false;
    Camera gameCamera;
    public GameObject DeckPosition;
    void Update()
    {
        if (isDraged)
        {
            if (gameCamera == null) { gameCamera = Camera.main; }
            Vector3 pz = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            pz.z = 0;
            transform.position = pz;


        }
    }

    public void StartDrag()
    {
        isDraged = true;
        GetComponent<BoxCollider>().enabled = false;
        if (DeckPosition != null)
        {
            DeckPosition.GetComponent<Deck_Place_Manager>().CardPlaced = null;
            DeckPosition.GetComponent<BoxCollider>().enabled = true;
            

        }
    }

    public void StopDrag()
    {
        isDraged = false;
        GetComponent<BoxCollider>().enabled = true;
        Destroy(gameObject);
    }
}
