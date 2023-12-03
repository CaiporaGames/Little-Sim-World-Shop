using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class PlayerMoneyUIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerMoneyText;

    [SerializeField] SOPlayerInfo playerInfo;

    private void OnEnable()
    {
        ItemController.buyItem += UpdateUI;
    }

    private void Start()
    {
        playerMoneyText.text = playerInfo.playerMoney.ToString();
    }

    void UpdateUI()
    {
        playerMoneyText.text = playerInfo.playerMoney.ToString();
    }

    private void OnDisable()
    {
        ItemController.buyItem -= UpdateUI;
    }
}
