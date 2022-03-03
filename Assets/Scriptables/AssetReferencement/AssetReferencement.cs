using System.Collections;
using System.Collections.Generic;
using UnityEngine;





[CreateAssetMenu(fileName = "AssetReferencement", menuName = "Create an Asset Referencement", order = 1)]
public class AssetReferencement : ScriptableObject
{
    public List<string> AssetList_id;
    public List<Object> AssetList_sprite;
    public List<Object> AssetList_model;
}
