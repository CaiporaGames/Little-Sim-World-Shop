using System.Collections;
using UnityEngine;

public class PointClickController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private bool isMoving = false;

    private void OnEnable()
    {
        DetectClick.OnClickPositionChanged += MoveToTarget;
    }

    private void MoveToTarget(Vector3 targetPosition)
    {
        if (!isMoving)
            StartCoroutine(MoveCoroutine(targetPosition));
    }

    private IEnumerator MoveCoroutine(Vector3 targetPosition)
    {
        isMoving = true;

        while (Vector3.Distance(transform.position, targetPosition) > 0.5f)
        {
            Vector3 direction = targetPosition - transform.position;
            direction.Normalize();
            transform.Translate(direction * moveSpeed * Time.deltaTime);

            yield return null;
        }
        transform.position = targetPosition;

        isMoving = false;
    }

    private void OnDisable()
    {
        DetectClick.OnClickPositionChanged -= MoveToTarget;
    }
}