using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SellingSystemController;

public class ItemController : MonoBehaviour
{
    public delegate void BuyItem();
    public static BuyItem buyItem;

    [HideInInspector] public SOClothes clothe;
    [SerializeField] private SOPlayerInfo playerInfo;
    [SerializeField] private AudioClip buySound;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = buySound;
    }
    public void BuySelectedItem()
    {
        playerInfo.ownedClothes.Add(clothe);
        playerInfo.playerMoney -= clothe.clothPrice;
        audioSource.Play();
        buyItem.Invoke();
    }
}