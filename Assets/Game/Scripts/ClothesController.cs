using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesController : MonoBehaviour
{
    [SerializeField] private GameObject playerBodyPart;
    [SerializeField] List<SOClothes> clothesList;

    private SOClothes currentClothe;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        currentClothe = clothesList[SetRandomCloth()];
        spriteRenderer.sprite = currentClothe.clothe;
    }

    int SetRandomCloth()
    {
        int index = Random.Range(0, clothesList.Count);
        return index;
    }

    private void OnMouseDown()
    {
        playerBodyPart.GetComponent<SpriteRenderer>().sprite = currentClothe.clothe;
    }
}
