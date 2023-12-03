using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    [SerializeField] Texture2D defaultCursor;
    [SerializeField] Texture2D cursor;
    [SerializeField] string tooltip;
    [SerializeField] bool useCustomTooltip = false;

    private Coroutine timerCoroutine;
    private SOClothes currentClothe;

    private void OnMouseEnter()
    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.ForceSoftware);
        timerCoroutine = StartCoroutine(WaitForSeconds());

        SetCurrentClotheName(!useCustomTooltip);
    }

    void SetCurrentClotheName(bool useCustomTooltip)
    {
        if (useCustomTooltip)
        {
            currentClothe = GetComponent<ClothesController>().GetCurrentClothe;
            tooltip = currentClothe.clotheName;
        }
    }

    IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(1f);
        TooltipController.instance.ShowTooltip(tooltip);
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.ForceSoftware);
        StopCoroutine(timerCoroutine);
        TooltipController.instance.HideTooltip();
    }
}
