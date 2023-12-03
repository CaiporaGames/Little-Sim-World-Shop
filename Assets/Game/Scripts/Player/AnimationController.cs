using System.Collections;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] SOAnimationInfo animationInfo = null;
    private Animator animator;
    private int animationStateHash;

    private Coroutine animationCoroutine;

    private void Awake()
    {
        InitializeAnimationHashes();        
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
       
        animationStateHash = animationInfo.idleStateHash;
        ChangeAnimationState(animationStateHash);
    }


    private void InitializeAnimationHashes()
    {
        animationInfo.idleStateHash = Animator.StringToHash("Rogue_idle_01");
        animationInfo.walkStateHash = Animator.StringToHash("Rogue_walk_01");
    }


    public void ChangeAnimationState(int newAnimationStateHash)
    {
        if (animationStateHash != newAnimationStateHash)
        {
            animationStateHash = newAnimationStateHash;
            if (animationCoroutine != null)
                StopCoroutine(animationCoroutine);

            animationCoroutine = StartCoroutine(AnimateState(newAnimationStateHash));
        }
    }

    private IEnumerator AnimateState(int newAnimationStateHash)
    {
        animator.Play(newAnimationStateHash);

        while (true)
            yield return null; 
    }
}
