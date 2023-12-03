using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesController : MonoBehaviour
{
    public delegate void DressingClothes(SOClothes currentClothe);
    public static DressingClothes dressingClothes;

    [SerializeField] private GameObject playerBodyPart;
    [SerializeField] List<SOClothes> clothesList;
    [SerializeField] private bool isUsedOnClothes = false;

    private SOClothes currentClothe;
    private SpriteRenderer spriteRenderer;


    private void Start()
    {
        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        if (isUsedOnClothes)
        {
            currentClothe = clothesList[SetRandomCloth()];
            spriteRenderer.sprite = currentClothe.clothe;
        }
    }

    public List<SOClothes> AllClothes
    {
        get { return clothesList; }
    }

    public SOClothes GetCurrentClothe
    {
        get { return currentClothe; }
    }

    private void OnMouseDown()
    {
        if (!isUsedOnClothes)
            dressingClothes?.Invoke(currentClothe);
    }

    int SetRandomCloth()
    {
        int index = Random.Range(0, clothesList.Count);
        return index;
    }
}
