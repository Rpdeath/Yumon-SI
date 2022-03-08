using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelperBox : MonoBehaviour
{
    public List<string> allHelpComments;
    
    
    public void OpenHelp()
    {
        ManagerHelperBox.helperManagerInstance.SetHelpersBox(allHelpComments);
    }
    public void CloseHelp()
    {
        ManagerHelperBox.helperManagerInstance.CloseHelpersBox(allHelpComments);
    }
}
