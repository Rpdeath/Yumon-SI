using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IClickable
{
    void OnClick();
}

public class ScreenInputManager : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera gameCamera;
    private InputAction click;
    void Awake()
    {
        click = new InputAction(binding: "<Mouse>/leftButton");
        click.performed += ctx => {
            if (gameCamera == null)
            {
                gameCamera = Camera.main;
            }
            RaycastHit hit;
            Vector3 coor = Mouse.current.position.ReadValue();
            if (Physics.Raycast(gameCamera.ScreenPointToRay(coor), out hit))
            {
                hit.collider.GetComponent<IClickable>()?.OnClick();
            }
        };
        click.Enable();
    }


}
