using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ClothesController;

public class ClothesController : MonoBehaviour
{
    public delegate void DressingClothes(SOClothes currentClothe);
    public static DressingClothes dressingClothes;

    [SerializeField] private GameObject playerBodyPart;
    [SerializeField] List<SOClothes> clothesList;

    private SOClothes currentClothe;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;


    private void Start()
    {
        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        currentClothe = clothesList[SetRandomCloth()];
        spriteRenderer.sprite = currentClothe.clothe;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = currentClothe.clouthClip;
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
        dressingClothes?.Invoke(currentClothe);
        //playerBodyPart.GetComponent<SpriteRenderer>().sprite = currentClothe.clothe;
        //audioSource.Play();
    }

    int SetRandomCloth()
    {
        int index = Random.Range(0, clothesList.Count);
        return index;
    }
}
