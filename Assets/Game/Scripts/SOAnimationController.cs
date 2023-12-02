using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AnimationController", menuName = "ScriptableObjects / AnimationController")]
public class SOAnimationController : ScriptableObject
{
    public Animator animator;
    private int animationStateHash;

    private int idleStateHash = Animator.StringToHash("Rogue_idle_01");
    private int walkStateHash = Animator.StringToHash("Rogue_walk_01");


    private void OnEnable()
    {
        idleStateHash = animator.StringToHash("Rogue_idle_01");
        animationStateHash = idleStateHash;
    }
}
