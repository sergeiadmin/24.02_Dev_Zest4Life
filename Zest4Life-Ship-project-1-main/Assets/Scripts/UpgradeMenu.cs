using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeMenu : MonoBehaviour
{
    [SerializeField] private GameObject oilLevel;
    [SerializeField] private GameObject oilCapacity;
    [SerializeField] private GameObject carrierSpeed;
    [SerializeField] private GameObject carrierCapacity;
    [SerializeField] private GameObject storageCapacity;
    [SerializeField] private GameObject notEnoughMessage;

    [SerializeField] private GameObject upgradeOilLevelButton;
    [SerializeField] private GameObject upgradeOilCapacityButton;
    [SerializeField] private GameObject upgradeCarrierSpeedButton;
    [SerializeField] private GameObject upgradeCarrierCapacityButton;
    [SerializeField] private GameObject upgradeStorageCapacityButton;

    [SerializeField] private OilTower oilTower;
    [SerializeField] private OilVillager oilCarrier;
    [SerializeField] private Storage storage;
    
    private float _valueMultiplier = 1.07f;
    private int _oilLevelValue = 100;
    private int _oilCapacityValue = 100;
    private int _carrierSpeedValue = 100;
    private int _carrierCapacityValue = 100;
    private int _storageCapacityValue = 100;

    private void Update()
    {
        oilLevel.GetComponent<TextMeshProUGUI>().text = "Level: " + oilTower.OilTowerLevel;
        oilCapacity.GetComponent<TextMeshProUGUI>().text = "Capacity: " + oilTower.OilTowerCapacity;
        carrierSpeed.GetComponent<TextMeshProUGUI>().text = "Speed: " + oilCarrier.CarrierSpeed;
        carrierCapacity.GetComponent<TextMeshProUGUI>().text = "Capacity: " + oilCarrier.CarrierCapacity;
        storageCapacity.GetComponent<TextMeshProUGUI>().text = "Capacity: " + storage.OilCapacity;
        
        upgradeOilLevelButton.GetComponent<TextMeshProUGUI>().text = " Upgrade for: " + _oilLevelValue;
        upgradeOilCapacityButton.GetComponent<TextMeshProUGUI>().text = " Upgrade for: " + _oilCapacityValue;
        upgradeCarrierSpeedButton.GetComponent<TextMeshProUGUI>().text = " Upgrade for: " + _carrierSpeedValue;
        upgradeCarrierCapacityButton.GetComponent<TextMeshProUGUI>().text = " Upgrade for: " + _carrierCapacityValue;
        upgradeStorageCapacityButton.GetComponent<TextMeshProUGUI>().text = " Upgrade for: " + _storageCapacityValue;
    }

    public void UpgradeOilLevel()
    {
        if (storage.StorageCoins > _oilLevelValue)
        {
            oilTower.OilTowerLevel += 1;
            storage.StorageCoins -= _oilLevelValue;
            _oilLevelValue = (int)(_oilLevelValue * _valueMultiplier);
        }
        else
        {
            notEnoughMessage.GetComponent<TextMeshProUGUI>().text = "You don't have enough coins.";
            notEnoughMessage.GetComponent<Animation>().Play("NotEnoughTradeAnim");
        }
    }
    
    public void UpgradeOilCapacity()
    {
        if (storage.StorageCoins > _oilCapacityValue)
        {
            oilTower.OilTowerCapacity += 100;
            storage.StorageCoins -= _oilCapacityValue;
            _oilCapacityValue = (int)(_oilCapacityValue * _valueMultiplier);
        }
        else
        {
            notEnoughMessage.GetComponent<TextMeshProUGUI>().text = "You don't have enough coins.";
            notEnoughMessage.GetComponent<Animation>().Play("NotEnoughTradeAnim");
        }
    }
    
    public void UpgradeCarrierSpeed()
    {
        if (storage.StorageCoins > _carrierSpeedValue)
        {
            oilCarrier.CarrierSpeed += 1;
            storage.StorageCoins -= _carrierSpeedValue;
            _carrierSpeedValue = (int)(_carrierSpeedValue * _valueMultiplier);
        }
        else
        {
            notEnoughMessage.GetComponent<TextMeshProUGUI>().text = "You don't have enough coins.";
            notEnoughMessage.GetComponent<Animation>().Play("NotEnoughTradeAnim");
        }
    }
    
    public void UpgradeCarrierCapacity()
    {
        if (storage.StorageCoins > _carrierCapacityValue)
        {
            oilCarrier.CarrierCapacity += 1;
            storage.StorageCoins -= _carrierCapacityValue;
            _carrierCapacityValue = (int)(_carrierCapacityValue * _valueMultiplier);
        }
        else
        {
            notEnoughMessage.GetComponent<TextMeshProUGUI>().text = "You don't have enough coins.";
            notEnoughMessage.GetComponent<Animation>().Play("NotEnoughTradeAnim");
        }
    }

    public void UpgradeStorageCapacity()
    {
        if (storage.StorageCoins > _storageCapacityValue)
        {
            storage.OilCapacity += 100;
            storage.StorageCoins -= _storageCapacityValue;
            _storageCapacityValue = (int)(_storageCapacityValue * _valueMultiplier);
        }
        else
        {
            notEnoughMessage.GetComponent<TextMeshProUGUI>().text = "You don't have enough coins.";
            notEnoughMessage.GetComponent<Animation>().Play("NotEnoughTradeAnim");
        }
    }
}
