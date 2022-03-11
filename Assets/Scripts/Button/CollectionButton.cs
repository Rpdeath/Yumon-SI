using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectionButton : MonoBehaviour
{
    public string level="Collection";
    public Difficulty difficulty;
    public void onClick()
    {
        GameInstance.instance.difficulty = difficulty;
        SceneManager.LoadScene(level);
    }
}
