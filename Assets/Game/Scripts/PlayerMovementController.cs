using System.Collections;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] SOAnimationInfo animationInfo = null;

    private AnimationController animationController;

    private bool isMoving = false;

    private void OnEnable()
    {
        DetectClick.OnClickPositionChanged += MoveToTarget;
    }

    private void Start()
    {
        animationController = GetComponent<AnimationController>();
    }

    private void MoveToTarget(Vector3 targetPosition)
    {
        if (!isMoving)
            StartCoroutine(MoveCoroutine(targetPosition));
    }

    private IEnumerator MoveCoroutine(Vector3 targetPosition)
    {
        isMoving = true;
        animationController.ChangeAnimationState(animationInfo.walkStateHash);
        while (Vector3.Distance(transform.position, targetPosition) > 0.5f)
        {
            Vector3 direction = targetPosition - transform.position;
            direction.Normalize();
            transform.Translate(direction * moveSpeed * Time.deltaTime);

            yield return null;
        }
        transform.position = targetPosition;
        animationController.ChangeAnimationState(animationInfo.idleStateHash);

        isMoving = false;
    }

    private void OnDisable()
    {
        DetectClick.OnClickPositionChanged -= MoveToTarget;
    }
}