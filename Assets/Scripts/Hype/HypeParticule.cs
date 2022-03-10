using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HypeParticule : MonoBehaviour
{
    public ParticleSystem child;

    private Vector3 actualHandlePos;
    private Vector3 worldPos;

    public Image currentHandle;

    private void Awake()
    {


        //currentHandle=GameInstance.instance.actualGameInfo.handle1;
    }


    public ParticleSystem main;


    private void Update()
    {
        if (currentHandle != null)
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

    public void GiveDestination(int wichDestination)
    {
        if (wichDestination == 1)
        {
            currentHandle = GameInstance.instance.actualGameInfo.handle1;
        }
        else if (wichDestination == 2)
        {
            currentHandle = GameInstance.instance.actualGameInfo.handle2;
        }
        else
        {
            currentHandle = GameInstance.instance.actualGameInfo.manaBar.GetComponentInChildren<Image>();
        }
    }
}
