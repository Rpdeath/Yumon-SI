using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HypeParticule : MonoBehaviour
{
    private Vector3 actualHandlePos;

    private Vector3 worldPos;

    public Image currentHandle;

    private void Awake()
    {


        currentHandle=GameInstance.instance.actualGameInfo.handle1;
    }


    public ParticleSystem main;
    public ParticleSystem child;


    private void Update()
    {
        actualHandlePos = Camera.main.WorldToScreenPoint(currentHandle.transform.position);
        worldPos = Camera.main.ScreenToWorldPoint(actualHandlePos);


        transform.position = Vector3.MoveTowards(transform.position, worldPos, Time.deltaTime * 10f);

        if (transform.position == worldPos)
        {
            child.Stop();
            Destroy(gameObject, 1f);
        }

        
    }
}
