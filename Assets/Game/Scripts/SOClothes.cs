using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Clothes", menuName = "ScriptableObjects / Clothes")]
public class SOClothes : ScriptableObject
{
    public List<Sprite> clothe;
    public List<string> clotheName;
}
