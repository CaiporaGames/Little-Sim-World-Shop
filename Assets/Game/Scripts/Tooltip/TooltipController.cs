using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TooltipController : MonoBehaviour
{
    public static TooltipController instance;

    [SerializeField] private GameObject textComponentObject;
    [SerializeField] private Texture2D defaultCursor;

    private TextMeshProUGUI textComponent;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.ForceSoftware);
        textComponent = textComponentObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    public void ShowTooltip(string tooltip)
    {
        textComponentObject.SetActive(true);
        textComponent.text = tooltip;
        textComponentObject.transform.position = Input.mousePosition;
    }

    public void HideTooltip()
    {
        textComponentObject.SetActive(false);
        textComponent.text = string.Empty;
    }
}
