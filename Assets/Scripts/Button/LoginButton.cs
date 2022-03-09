using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Networking;

public class LoginButton : MonoBehaviour
{

    public Text txt;
    public GameInstance gi;
    // Start is called before the first frame update

    private void Start()
    {
        gi = FindObjectOfType<GameInstance>();
    }

    public void onClick()
    {
        if (txt.text != "") {
            StartCoroutine(Request("yumon.rpdeath.com/get/users", txt.text));
        }
        
    }

    IEnumerator Request(string url, string data)
    {
        UnityWebRequest uwr = UnityWebRequest.Get(url + "?users_name=" +data+"&users_password=null");

        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
        }
        else
        {
            //Debug.Log(uwr.downloadHandler.text);


            string tx = "";
            gi.UpdatePlayerData(uwr.downloadHandler.text);

        }




    }
}
