using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HypeParticule : MonoBehaviour
{
    private Vector3 actualHandlePos;

    private Vector3 worldPos;


<<<<<<< HEAD
=======

    private void Start()
    {

    }

>>>>>>> parent of 2fe7cd3 (ColonneLumiereStillWIP)
    private void Update()
    {
        actualHandlePos = Camera.main.WorldToScreenPoint(GameInstance.instance.actualGameInfo.handle1.transform.position);
        worldPos = Camera.main.ScreenToWorldPoint(actualHandlePos);
<<<<<<< HEAD

        transform.position = Vector3.MoveTowards(transform.position, worldPos, Time.deltaTime * 10f);

        if (transform.position == worldPos)
        {
            Destroy(gameObject);
        }
=======
        Debug.Log(worldPos);

        //transform.position = worldPos;

        transform.position = Vector3.MoveTowards(transform.position, worldPos, Time.deltaTime * 10f);
>>>>>>> parent of 2fe7cd3 (ColonneLumiereStillWIP)
        
    }
}
