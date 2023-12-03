using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInfo", menuName = "ScriptableObjects / PlayerInfo")]
public class SOPlayerInfo : ScriptableObject
{
    public List<SOClothes> ownedClothes;
    public float playerMoney = 1000;//Just for testing the game.
}
