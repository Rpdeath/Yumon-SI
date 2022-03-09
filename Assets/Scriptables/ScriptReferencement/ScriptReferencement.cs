
using System.Collections;
using System.Collections.Generic;
using UnityEngine;





[CreateAssetMenu(fileName = "ScriptReferencement", menuName = "Create an Script Referencement", order = 1)]
public class ScriptReferencement : ScriptableObject
{
    public List<string> AssetList_id;
    public List<ScriptableObject> AssetList_script;

}
