using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NFT", menuName = "Create an NFT", order = 2)]
public class Nft : ScriptableObject
{
    public int nft_id;
    public string nft_data;
    public int nft_owner;
}