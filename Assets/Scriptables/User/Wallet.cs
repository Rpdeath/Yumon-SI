using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Wallet", menuName = "Create a Wallet", order = 3)]
public class Wallet : ScriptableObject
{
    public int wallet_id;
    public int wallet_currency;
    public int wallet_amount;
}