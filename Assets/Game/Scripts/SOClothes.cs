using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Clothes", menuName = "ScriptableObjects / Clothes")]
public class SOClothes : ScriptableObject
{
    public string bodyPartName;
    [HideInInspector]
    public GameObject bodyPart;
    public float clothPrice;
    public string clotheName;
    public Sprite clothe;
    public AudioClip clouthClip;
    [HideInInspector]
    public bool canSell = false;
}
