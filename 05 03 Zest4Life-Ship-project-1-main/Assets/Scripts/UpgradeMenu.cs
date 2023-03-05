using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeMenu : MonoBehaviour
{
    [SerializeField] private GameObject notEnoughMessage;

    [SerializeField] private GameObject upgradeOilLevelButton;
    [SerializeField] private GameObject upgradeOilCapacityButton;
    [SerializeField] private GameObject upgradeCarrierSpeedButton;
    [SerializeField] private GameObject upgradeCarrierCapacityButton;
    [SerializeField] private GameObject upgradeStorageCapacityButton;
    
    [SerializeField] private GameObject upgradeMainBuildingLevelText;

    [SerializeField] private OilTower oilTower;
    [SerializeField] private OilVillager oilCarrier;
    [SerializeField] private Storage storage;
    [SerializeField] private MainBuilding mainBuilding;

    [SerializeField] private AudioManager audioManager;

    private float _valueMultiplier = 1.07f;
    private int _oilLevelValue = 100;
    private int _oilCapacityValue = 100;
    private int _carrierSpeedValue = 100;
    private int _carrierCapacityValue = 100;
    private int _storageCapacityValue = 100;
    private int _mainBuildingLevelValue = 100;

    private void Update()
    {
        upgradeOilLevelButton.GetComponent<TextMeshProUGUI>().text = " Upgrade for: " + _oilLevelValue;
        upgradeOilCapacityButton.GetComponent<TextMeshProUGUI>().text = " Upgrade for: " + _oilCapacityValue;
        upgradeCarrierSpeedButton.GetComponent<TextMeshProUGUI>().text = " Upgrade for: " + _carrierSpeedValue;
        upgradeCarrierCapacityButton.GetComponent<TextMeshProUGUI>().text = " Upgrade for: " + _carrierCapacityValue;
        upgradeStorageCapacityButton.GetComponent<TextMeshProUGUI>().text = " Upgrade for: " + _storageCapacityValue;
        
        upgradeMainBuildingLevelText.GetComponent<TextMeshProUGUI>().text = " Upgrade for: " + _mainBuildingLevelValue;
    }

    public void UpgradeOilLevel()
    {
        if (storage.Coins > _oilLevelValue)
        {
            oilTower.Level += 1;
            storage.Coins -= _oilLevelValue;
            _oilLevelValue = (int)(_oilLevelValue * _valueMultiplier);
            audioManager.Play("Upgrade");
        }
        else
        {
            notEnoughMessage.GetComponent<TextMeshProUGUI>().text = "You don't have enough coins.";
            notEnoughMessage.GetComponent<Animation>().Play("NotEnoughTradeAnim");
        }
    }
    
    public void UpgradeOilCapacity()
    {
        if (storage.Coins > _oilCapacityValue)
        {
            oilTower.Capacity += 10;
            storage.Coins -= _oilCapacityValue;
            _oilCapacityValue = (int)(_oilCapacityValue * _valueMultiplier);
            audioManager.Play("Upgrade");
        }
        else
        {
            notEnoughMessage.GetComponent<TextMeshProUGUI>().text = "You don't have enough coins.";
            notEnoughMessage.GetComponent<Animation>().Play("NotEnoughTradeAnim");
        }
    }
    
    public void UpgradeCarrierSpeed()
    {
        if (storage.Coins > _carrierSpeedValue)
        {
            oilCarrier.CarrierSpeed += 1;
            storage.Coins -= _carrierSpeedValue;
            _carrierSpeedValue = (int)(_carrierSpeedValue * _valueMultiplier);
            audioManager.Play("Upgrade");
        }
        else
        {
            notEnoughMessage.GetComponent<TextMeshProUGUI>().text = "You don't have enough coins.";
            notEnoughMessage.GetComponent<Animation>().Play("NotEnoughTradeAnim");
        }
    }
    
    public void UpgradeCarrierCapacity()
    {
        if (storage.Coins > _carrierCapacityValue)
        {
            oilCarrier.CarrierCapacity += 1;
            storage.Coins -= _carrierCapacityValue;
            _carrierCapacityValue = (int)(_carrierCapacityValue * _valueMultiplier);
            audioManager.Play("Upgrade");
        }
        else
        {
            notEnoughMessage.GetComponent<TextMeshProUGUI>().text = "You don't have enough coins.";
            notEnoughMessage.GetComponent<Animation>().Play("NotEnoughTradeAnim");
        }
    }

    public void UpgradeStorageCapacity()
    {
        if (storage.Coins > _storageCapacityValue)
        {
            storage.Capacity += 10;
            storage.Coins -= _storageCapacityValue;
            _storageCapacityValue = (int)(_storageCapacityValue * _valueMultiplier);
            audioManager.Play("Upgrade");
        }
        else
        {
            notEnoughMessage.GetComponent<TextMeshProUGUI>().text = "You don't have enough coins.";
            notEnoughMessage.GetComponent<Animation>().Play("NotEnoughTradeAnim");
        }
    }
    
    public void UpgradeMainBuildingLevel()
    {
        if (storage.Coins > _mainBuildingLevelValue)
        {
            mainBuilding.Level += 1;
            storage.Coins -= _mainBuildingLevelValue;
            _mainBuildingLevelValue = (int)(_mainBuildingLevelValue * _valueMultiplier);
            audioManager.Play("Upgrade");
        }
        else
        {
            notEnoughMessage.GetComponent<TextMeshProUGUI>().text = "You don't have enough coins.";
            notEnoughMessage.GetComponent<Animation>().Play("NotEnoughTradeAnim");
        }
    }
}
