using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IClickable
{
    void OnClick();
}
public interface IHelper {
    void OpenHelper();
    void CloseHelper();
}

public interface IDragable
{
    void StartDrag();
    void StopDrag(bool destroy=false);
}

public interface IReceive
{
    void DropCard(GameObject obj);
    
}

public interface IHover
{
    void Hover();
    void StopHover();

}

public class ScreenInputManager : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera gameCamera;
    private InputAction click;
    private InputAction clickRight;
    private bool isDragging = false;
    private GameObject dragedObject;
    private GameObject hoveredObject;
    private GameObject openedHelper;
    private float timer;

    private bool isHoverBox;

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

                        if (hit.collider.GetComponent<DropStarz>() != null)
                        {
                            if (hit.collider.GetComponent<DropStarz>().allowDrop)
                            {
                                isDragging = false;
                                hit.collider.GetComponent<IReceive>()?.DropCard(dragedObject);
                                dragedObject = null;
                            }
                            else
                            {
                                dragedObject.GetComponent<IDragable>().StopDrag();
                                isDragging = false;
                                dragedObject = null;
                            }
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
                            if (hit.collider.GetComponent<CardHandDragable>() != null && hit.collider.GetComponent<CardHandDragable>().isDraggable)
                            {
                                isDragging = true;
                                hit.collider.GetComponent<IDragable>()?.StartDrag();
                                dragedObject = hit.collider.gameObject;
                            }
                        }
                    }
                }
            }
            else
            {
                if (dragedObject != null)
                {
                    if (dragedObject.GetComponent<CardHandDragable>())
                    {
                        dragedObject.GetComponent<IDragable>().StopDrag();
                        isDragging = false;
                        dragedObject = null;
                    }
                }
            }
        };
        click.Enable();
        clickRight = new InputAction(binding: "<Mouse>/rightButton");
        clickRight.Enable();
        clickRight.performed += ctx =>
        {
            if (gameCamera == null)
            {
                gameCamera = Camera.main;
            }
            RaycastHit hit;
            Vector3 coor = Mouse.current.position.ReadValue();
            if (openedHelper != null)
            {
                openedHelper.GetComponent<HelperBox>().CloseHelp();
                openedHelper = null;
            }
            if (Physics.Raycast(gameCamera.ScreenPointToRay(coor), out hit))
            {
                if (openedHelper != hit.collider.gameObject)
                {
                    if (hit.collider.gameObject.layer == 5 && hit.collider.gameObject.GetComponent<HelperBox>() != null)
                    {
                        openedHelper = hit.collider.gameObject;
                        openedHelper.GetComponent<HelperBox>().OpenHelp();
                    }
                }
            }
        };
    }
    private void Update()
    {
        if (gameCamera == null)
        {
            gameCamera = Camera.main;
        }
        
        RaycastHit hit;
        Vector3 coor = Mouse.current.position.ReadValue();
        if (Physics.Raycast(gameCamera.ScreenPointToRay(coor), out hit))
        {
            
            if (hit.collider.GetComponent<IHover>() != null)
            {
                if (hoveredObject!=null && hoveredObject != hit.collider.gameObject)
                {
                    hoveredObject.GetComponent<IHover>()?.StopHover();
                    hoveredObject = null;
                }
                hit.collider.GetComponent<IHover>()?.Hover();
                hoveredObject = hit.collider.gameObject;
            }
           if(hit.collider.GetComponent<HelperBox>()!= null)
           {
                isHoverBox = true;

           }
           else
           {
                isHoverBox = false;
                if(openedHelper != null)
                {
                    openedHelper.GetComponent<HelperBox>().CloseHelp();
                    openedHelper = null;
                }
                timer = 0;
            }
            if (isHoverBox && openedHelper == null)
            {
                if (hit.collider.GetComponent<HelperBox>().hasOpened == false)
                {
                    timer += Time.deltaTime;
                    if (timer >= hit.collider.GetComponent<HelperBox>().timerHover)
                    {
                        openedHelper = hit.collider.gameObject;
                        openedHelper.GetComponent<HelperBox>().OpenHelp();
                    }
                }
            }




        }
        else
        {
            if (hoveredObject != null)
            {
                hoveredObject.GetComponent<IHover>()?.StopHover();
                hoveredObject = null;
            }
            isHoverBox = false;
            if (openedHelper != null)
            {
                openedHelper.GetComponent<HelperBox>().CloseHelp();
                openedHelper = null;
            }
            timer = 0;

        }

    }
}
