using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectClick : MonoBehaviour
{
    public delegate void ClickPositionHandler(Vector3 position);
    public static event ClickPositionHandler OnClickPositionChanged;

    [SerializeField] private AudioClip mouseClick;
    [SerializeField] private Camera mainCamera;

    private Vector3 currentPosition;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = mouseClick;
    }

    void OnMouseDown()
    {
        if (OnClickPositionChanged != null)
        {
            currentPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            currentPosition.z = 0;
            currentPosition.y -= 2;
            OnClickPositionChanged(currentPosition);
            currentPosition = Vector3.zero;
            audioSource.Play();
        }
    }
}
