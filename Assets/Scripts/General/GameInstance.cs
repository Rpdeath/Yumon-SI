using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameInstance : MonoBehaviour
{
    #region Variable
    public static GameInstance instance;

    public User userData;
    public User userDataEnemy;
    
    //[HideInInspector]
    public CreateGameInfo actualGameInfo;
    


    #endregion

    private void Awake()
    {
        #region Setup instance
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("Care there is multiple GameInstance in the scene");
        }
        #endregion
    }

    private void Start()
    {
        CreateGameInfo card = (CreateGameInfo)ScriptableObject.CreateInstance("CreateGameInfo");
        actualGameInfo = card;

        actualGameInfo.maxScore = 1000;
        actualGameInfo.sliderPlayer1 = GameObject.FindGameObjectWithTag("Slider1").GetComponent<Slider>();
        actualGameInfo.sliderPlayer2 = GameObject.FindGameObjectWithTag("Slider2").GetComponent<Slider>();
    }


    public void AddScore(int playerId, int scoreToAdd)
    {
        if (playerId == userData.users_id)
        {
            actualGameInfo.scorePlayer1 += scoreToAdd;

            actualGameInfo.sliderPlayer1.value = (float)actualGameInfo.scorePlayer1 / (float)actualGameInfo.maxScore ;


            if (actualGameInfo.scorePlayer1 > actualGameInfo.maxScore)
            {
                Debug.Log("Player 1 WIN !!!!!!!!!!!");
            }
        }
        else
        {
            actualGameInfo.scorePlayer2 += scoreToAdd;
            actualGameInfo.sliderPlayer2.value = actualGameInfo.scorePlayer2 / actualGameInfo.maxScore;

            if (actualGameInfo.scorePlayer2 > actualGameInfo.maxScore)
            {
                Debug.Log("Player 2 WIN !!!!!!!!!!!");
            }
        }
    }

    public void AddStarzInList(int playerId, Card starzPlace)
    {
        if (playerId == userData.users_id)
        {
            actualGameInfo.actualStarzPlayer1.Add(starzPlace);
        }
        else
        {
            actualGameInfo.actualStarzPlayer2.Add(starzPlace);
        }
    }
    public void RemoveStarzInList(int playerId, Card starzToRemove)
    {
        if (playerId == userData.users_id)
        {
            actualGameInfo.actualStarzPlayer1.Remove(starzToRemove);
        }
        else
        {
            actualGameInfo.actualStarzPlayer2.Remove(starzToRemove);
        }
    }
    
    public void RefreshManaState(int playerId, int manaValue)
    {
        if (playerId == userData.users_id)
        {
            actualGameInfo.manaPlayer1 = manaValue;
        }
        else
        {
            actualGameInfo.manaPlayer2 = manaValue;
        }
    }


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
