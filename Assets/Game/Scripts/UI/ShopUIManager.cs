using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopUIManager : MonoBehaviour
{
    [SerializeField] GameObject sellingPanel;
    [SerializeField] GameObject sellersPanel;
    [SerializeField] SOPlayerInfo playerInfo;
    [SerializeField] List<SOClothes> clothesList;
    [SerializeField] GameObject item;

    private GameObject sellingPanelChild;
    private void OnEnable()
    {
        ClothesController.dressingClothes += OpenSellersPanel;
    }

    private void Start()
    {
        sellingPanelChild = sellingPanel.transform.GetChild(1).GetChild(0).gameObject;
    }

    void OpenSellersPanel(SOClothes currentClothe)
    {
        sellersPanel.SetActive(true);
    }

    public void OpenPlayerSellingPanel()
    {
        sellersPanel.SetActive(false);
        sellingPanel.SetActive(true);
        SetPlayerClothes();
    }

    public void OpenSellerSellingPanel()
    {
        sellersPanel.SetActive(false);
        sellingPanel.SetActive(true);
        SetSellerClothes();
    }

    void SetPlayerClothes()
    {
        for (int i = 0; i < playerInfo.ownedClothes.Count; i++)
        {
            item.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = playerInfo.ownedClothes[i].clotheName;
            item.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = playerInfo.ownedClothes[i].clothe;
            item.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = playerInfo.ownedClothes[i].clothPrice.ToString();
            Instantiate(item, sellingPanelChild.transform);
        }
    }

    void SetSellerClothes()
    {
        for (int i = 0; i < clothesList.Count; i++)
        {
            item.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = clothesList[i].clotheName;
            item.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = clothesList[i].clothe;
            item.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = clothesList[i].clothPrice.ToString();
            Instantiate(item, sellingPanelChild.transform);
        }
    }

    public void CloseSellingPanel()
    {
        sellingPanel.SetActive(false);

        for (int i = 0; i < sellingPanelChild.transform.childCount; i++)
        {
            Destroy(sellingPanelChild.transform.GetChild(i).gameObject);
        }
    }

    private void OnDisable()
    {
        
      
        ClothesController.dressingClothes -= OpenSellersPanel;
    }
}
