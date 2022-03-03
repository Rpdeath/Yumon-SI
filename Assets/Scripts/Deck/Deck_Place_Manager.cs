using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck_Place_Manager : MonoBehaviour, IReceive
{

    public GameObject CardPlaced;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DropCard(GameObject obj)
    {
        Debug.Log("");
        obj.GetComponent<IDragable>()?.StopDrag();
        
        obj.transform.position = transform.position;
        CardPlaced = obj;
        GetComponent<BoxCollider>().enabled = false;
        obj.GetComponent<CardDeckDragable>().DeckPosition = gameObject;
        
    }
}
