using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TradeMenu : MonoBehaviour
{
    // Allows buying/selling oils when possible, commands ship launch
    
    [SerializeField] private GameObject oilDisplay;
    [SerializeField] private GameObject coinDisplay;
    [SerializeField] private GameObject notEnoughMessage;
    
    [SerializeField] private GameObject buyOilButton;
    [SerializeField] private GameObject sellOilButton;
    [SerializeField] private GameObject sendShipButton;

    [SerializeField] private int oilAmount;
    [SerializeField] private int coinAmount;
    
    [SerializeField] private Storage storage;

    public int ProfitCoins => coinAmount;
    public int OilAmount => oilAmount;

    private void Update()
    {
        if (oilAmount == 0) { sendShipButton.SetActive(false); }

        oilDisplay.GetComponent<TextMeshProUGUI>().text = oilAmount switch
        {
            > 0 => "+" + oilAmount,
            < 0 => oilAmount.ToString(),
            _ => "0"
        };

        coinDisplay.GetComponent<TextMeshProUGUI>().text = coinAmount switch
        {
            > 0 => "Expected profit in coins: +" + coinAmount,
            < 0 => "Expected profit in coins: " + coinAmount,
            _ => "Expected profit in coins: 0"
        };
    }

    public void BuyOil ()
    {
        if (storage.Coins + coinAmount >= 100)
        {
            oilAmount += 1;
            coinAmount -= 100;
            sendShipButton.SetActive(true);
        }
        else
        {
            notEnoughMessage.GetComponent<TextMeshProUGUI>().text = "You don't have enough coins.";
            notEnoughMessage.GetComponent<Animation>().Play("NotEnoughTradeAnim");
        }
    }
    
    public void SellOil ()
    {
        if (storage.Oil > -oilAmount)
        {
            oilAmount -= 1;
            coinAmount += 100;
            sendShipButton.SetActive(true);
        }
        else
        {
            notEnoughMessage.GetComponent<TextMeshProUGUI>().text = "You don't have enough oil.";
            notEnoughMessage.GetComponent<Animation>().Play("NotEnoughTradeAnim");
        }
    }

    public void CallSendShip()
    {
        FindObjectOfType<ShipVillager>().CarryCargo();
        buyOilButton.SetActive(false);
        sellOilButton.SetActive(false);
        sendShipButton.SetActive(false);
    }

    public void ShipLeaving()
    {
        if (oilAmount < 0)
        {
            storage.Oil -= -oilAmount;
        }
        if (oilAmount > 0)
        {
            storage.Coins -= -coinAmount;
        }
        FindObjectOfType<ShipMovement>().FollowPath();
    }

    public void ResetTrading()
    {
        oilAmount = 0;
        coinAmount = 0;
        buyOilButton.SetActive(true);
        sellOilButton.SetActive(true);
        sendShipButton.SetActive(true);
    }
}