using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AnimationInfo", menuName = "ScriptableObjects / AnimationInfo")]
public class SOAnimationInfo : ScriptableObject
{
    [HideInInspector] public int idleStateHash;
    [HideInInspector] public int walkStateHash;
    public bool isStopAnimation = false;
   
}
