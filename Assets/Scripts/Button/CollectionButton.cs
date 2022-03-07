using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectionButton : MonoBehaviour
{
    public string level="Collection";
    public void onClick()
    {
        SceneManager.LoadScene(level);
    }
}
