using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Properties", menuName = "Create a Card Properties", order = 1)]
public class Properties : ScriptableObject
{
    public int cost = 0;
    public int hype = 0;
    public int speed = 0;
    public string passivId = "none";
    public int actif_cost = 0;
    public int cooldown = 0;
    public string actifId = "none";

}
