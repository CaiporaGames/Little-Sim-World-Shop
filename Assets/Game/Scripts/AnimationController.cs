using UnityEngine;

public class AnimationController  
{
    private Animator animator;
    private int animationStateHash;

    private int idleStateHash;
    private int walkStateHash;

    private AnimationController()
    {
        // Set up hash codes for animation states
        idleStateHash = Animator.StringToHash("isIdeling");
        walkStateHash = Animator.StringToHash("isWalking");
        animationStateHash = idleStateHash;
    }

    public void ChangeAnimationState(int newAnimationStateHash)
    {
        if (animationStateHash != newAnimationStateHash)
        {
            animator.Play(newAnimationStateHash);
            animationStateHash = newAnimationStateHash;
        }
    }
}
