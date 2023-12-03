using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellingSystemController : MonoBehaviour
{
    

    [SerializeField] private SOPlayerInfo playerInfo;
    [SerializeField] private AudioClip buySound;

    private AudioSource audioSource;

    //private void OnEnable()
    //{
    //    ClothesController.dressingClothes += BuySelectedItem;
    //}

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = buySound;
    }
    // void BuySelectedItem(SOClothes selectedClothe)
    //{
    //    playerInfo.ownedClothes.Add(selectedClothe);
    //    playerInfo.playerMoney -= selectedClothe.clothPrice;
    //    audioSource.Play();
    //    buyItem.Invoke();
    //}

    //private void OnDisable()
    //{
    //    ClothesController.dressingClothes += BuySelectedItem;
    //}
}
