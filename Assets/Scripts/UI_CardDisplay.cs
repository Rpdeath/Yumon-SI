using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CardDisplay : MonoBehaviour
{
    [SerializeField]
    private Transform cardSelectedInfo;
    [SerializeField]
    private GameObject CardToSelect;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    public void OnClickCollection()
    {

        Instantiate(CardToSelect, cardSelectedInfo.position, cardSelectedInfo.rotation);
        Debug.Log(this.gameObject.name);
    }
}
