using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiPictoManager : MonoBehaviour
{
    #region Variable

    public static UiPictoManager instance;

    public Sprite upArrowPicto;
    public Sprite downArrowPicto;
    public Sprite hypePicto;
    public Sprite hypeSpeedPicto;
    public Sprite manaSpeedPicto;
    public Sprite shieldPicto;
    public Sprite stealPicto;
    public Sprite silencePicto;
    public Sprite lockPicto;

    #endregion


    private void Awake()
    {
        #region Variable
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("Care there is multiple UiPictoManager in the scene");
        }
        #endregion
    }
}
