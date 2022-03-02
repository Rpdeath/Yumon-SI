using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInstance : MonoBehaviour
{

    public User userData;

    public void UpdatePlayerData(string jsonData)
    {

        if (jsonData[13]=='0')
        {
            
            User a = (User)ScriptableObject.CreateInstance("User");
            string b = jsonData.Remove(0, 25);
            b = b.Remove(b.Length - 1, 1);
            //Debug.Log(b);
            JsonUtility.FromJsonOverwrite(b, a);
            string c = (b.Substring(b.IndexOf("\"nfts\""),b.Length - 1 - b.IndexOf("\"nfts\""))).Remove(0,8);
            c = c.Remove(c.Length - 1, 1);
            //Debug.Log(c);
            userData = a;
            string d = c.Replace("},{","}|{");
            foreach (var item in d.Split('|'))
            {
                Nft nft = (Nft)ScriptableObject.CreateInstance("Nft");
                JsonUtility.FromJsonOverwrite(item, nft);
                userData.nfts.Add(nft);
            }

            //Debug.Log(JsonUtility.ToJson(userData));
            SceneManager.LoadScene("MainMenu");
            

        }
    }
}
