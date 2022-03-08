using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class FindAGame : MonoBehaviour
{
    public Text localUser;
    public Text onlineUser;
    void Start()
    {
        localUser.text = GameInstance.instance.userData.users_name;
        onlineUser.text = "Looking For a Game";
        StartCoroutine(Request("yumon.rpdeath.com/matchmaking/pvp", GameInstance.instance.userData.users_id));
    }

    IEnumerator Request(string url, int id)
    {
        UnityWebRequest uwr = UnityWebRequest.Get(url + "?id=" + id);

        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
        }
        else
        {
            string response = uwr.downloadHandler.text;
            Debug.Log(uwr.downloadHandler.text);
            if ( response == "LOOKINGFORGAME")
            {
                yield return new WaitForSeconds(2);
                StartCoroutine(Request(url,id));
            }
            else
            {
                
                onlineUser.text = "Game Found";
                GameInstance.instance.gameManager = new GameManager();
                GameInstance.instance.StoreOnlineUserData(response);
                GameInstance.instance.gameManager.localUserData = GameInstance.instance.userData;


            }

        }
    }
}
