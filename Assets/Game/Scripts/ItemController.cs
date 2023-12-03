using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public delegate void BuyItem();
    public static BuyItem buyItem;

    [HideInInspector] public SOClothes clothe;
    [SerializeField] private SOPlayerInfo playerInfo;
    [SerializeField] private AudioClip buySound;

    private AudioSource audioSource;
    private GameObject player;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = buySound;
    }
    public void BuySelectedItem()
    {
        player = GameObject.FindWithTag("Player");
        if(clothe.canSell)
        {
            playerInfo.ownedClothes.Remove(clothe);
            playerInfo.playerMoney += clothe.clothPrice;
            Destroy(gameObject);
        }
        else
        {
            player.transform.GetChild(1).GetChild(0).GetChild(3).GetComponent<SpriteRenderer>().sprite = clothe.clothe;
            playerInfo.playerMoney -= clothe.clothPrice;
            playerInfo.ownedClothes.Add(clothe);
        }
        audioSource.Play();
        buyItem.Invoke();
    }
}