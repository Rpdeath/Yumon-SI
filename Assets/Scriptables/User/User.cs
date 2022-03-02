using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "UserData", menuName = "Create a UserData", order = 2)]
public class User : ScriptableObject
{
    public int users_id;
    public string users_name;
    public string users_password_crypted;
    public string users_key_public;
    public string users_key_private;

    public List<Wallet> wallets;
    public List<NFT> nft;



}

public class Wallet : ScriptableObject
{
    public int wallet_id;
    public int wallet_currency;
    public int wallet_amount;
}

public class NFT : ScriptableObject
{
    public int nft_id;
    public string nft_data;
    public int nft_owner;
}