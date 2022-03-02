using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstance : MonoBehaviour
{

    public User userData;

    public void UpdatePlayerData(string jsonData)
    {
        if (jsonData[16]=='0')
        {

        User a = (User)ScriptableObject.CreateInstance("User");
        string b = jsonData.Remove(0, 25);
        b = b.Remove(b.Length - 1, 1);
        Debug.Log(b);
        JsonUtility.FromJsonOverwrite(b, a);
        Debug.Log(JsonUtility.ToJson(a));
        }
    }
}
