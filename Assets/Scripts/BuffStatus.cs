using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffStatus : MonoBehaviour
{
    Camera cam;
    Canvas canvasStatus;
    Quaternion camRot;

    //Renseigner le GameManager

    private void Awake()
    {
        canvasStatus = GetComponent<Canvas>();
        cam = Camera.main;
        canvasStatus.worldCamera = cam;
        camRot = cam.transform.rotation;
        transform.rotation = camRot;
    }

    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
