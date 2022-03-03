using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IClickable
{
    void OnClick();
}

public interface IDragable
{
    void StartDrag();
    void StopDrag();
}

public interface IReceive
{
    void DropCard(GameObject obj);
    
}

public interface IHover
{
    void Hover();

}

public class ScreenInputManager : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera gameCamera;
    private InputAction click;
    private bool isDragging = false;
    private GameObject dragedObject;
    void Awake()
    {
        click = new InputAction(binding: "<Mouse>/leftButton");
        click.performed += ctx =>
        {
            if (gameCamera == null)
            {
                gameCamera = Camera.main;
            }
            RaycastHit hit;
            Vector3 coor = Mouse.current.position.ReadValue();
            if (Physics.Raycast(gameCamera.ScreenPointToRay(coor), out hit))
            {
                if (dragedObject != hit.collider.gameObject)
                {
                    if (isDragging)
                    {

                        if (hit.collider.GetComponent<Deck_Place_Manager>() != null && hit.collider.GetComponent<Deck_Place_Manager>().CardPlaced == null)
                        {
                            Debug.Log("Should Drop");
                            isDragging = false;
                            hit.collider.GetComponent<IReceive>()?.DropCard(dragedObject);
                            dragedObject = null;
                        }
                    }
                    else
                    {
                        if (hit.collider.GetComponent<IClickable>() != null)
                        {
                            hit.collider.GetComponent<IClickable>()?.OnClick();
                        }
                        if (hit.collider.GetComponent<IDragable>() != null)
                        {
                            isDragging = true;
                            hit.collider.GetComponent<IDragable>()?.StartDrag();
                            dragedObject = hit.collider.gameObject;
                        }
                    }
                }
            }
        };
        click.Enable();
    }
    private void Update()
    {
        if (gameCamera == null)
        {
            gameCamera = Camera.main;Debug.Log("enter");
        }
        
        RaycastHit hit;
        Vector3 coor = Mouse.current.position.ReadValue();
        if (Physics.Raycast(gameCamera.ScreenPointToRay(coor), out hit))
        {
            Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.GetComponent<IHover>() != null)
            {
                Debug.Log("Hit");
                hit.collider.GetComponent<IHover>()?.Hover();
            }
        }

    }
}
