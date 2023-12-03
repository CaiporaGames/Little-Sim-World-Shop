using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Clothes", menuName = "ScriptableObjects / Clothes")]
public class SOClothes : ScriptableObject
{
    [HideInInspector]
    public GameObject bodyPart;
    public float clothPrice;
    public string clotheName;
    public Sprite clothe;
    public AudioClip clouthClip;
}
