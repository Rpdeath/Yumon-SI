using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerHelperBox : MonoBehaviour
{
    public static ManagerHelperBox helperManagerInstance;
    public List<GameObject> helperList = new List<GameObject>();
    private void Awake()
    {
        #region Setup instance
        if (helperManagerInstance == null)
        {
            helperManagerInstance = this;
        }
        else
        {
            Debug.LogWarning("Care there is multiple HelperManagerInstance in the scene");
        }
        #endregion
    }
   
    public void SetHelpersBox(List<string> helpsTexts)
    {
        for (int i =0;i<helpsTexts.Count; i++)
        {
            helperList[i].SetActive(true);
            helperList[i].transform.GetChild(0).GetComponent<Text>().text = helpsTexts[i];
        }
    }
    public void CloseHelpersBox(List<string> helpsTexts)
    {
        for (int i = 0; i < helpsTexts.Count; i++)
        {
            helperList[i].SetActive(false);
            helperList[i].transform.GetChild(0).GetComponent<Text>().text = null;
        }
    }
}
