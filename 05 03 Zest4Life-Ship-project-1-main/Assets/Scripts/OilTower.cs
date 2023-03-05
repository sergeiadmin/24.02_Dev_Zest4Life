using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OilTower : MonoBehaviour
{
    // Generates oil automatically, stores it and shows amount in menu.
    
    [SerializeField] private float oil;
    [SerializeField] private float oilMax;
    [SerializeField] private int oilLevel;

    [SerializeField] private GameObject oilDisplay;
    [SerializeField] private GameObject oilTowerLevelDisplay;
    [SerializeField] private GameObject oilTowerSpeedDisplay;
    [SerializeField] private GameObject oilTowerCapacityDisplay;

    [SerializeField] private AudioManager audioManager;

    public float Oil
    {
        get => oil;
        set => oil = value;
    }

    public int Level
    {
        get => oilLevel;
        set => oilLevel = value;
    }

    public float Capacity
    {
        get => oilMax;
        set => oilMax = value;
    }

    private void Start()
    {
        StartCoroutine(GenerateOil());
    }

    private void Update()
    {
        oilDisplay.GetComponent<TextMeshProUGUI>().text = "Oil in tower: " + oil + " / " + oilMax;
        oilTowerLevelDisplay.GetComponent<TextMeshProUGUI>().text = oilLevel + " lvl";
        oilTowerSpeedDisplay.GetComponent<TextMeshProUGUI>().text = oilLevel + " ед в 5 секунд";
        oilTowerCapacityDisplay.GetComponent<TextMeshProUGUI>().text = "Capacity: " + oilMax;
    }

    public void TakeOil(float value)
    {
        oil -= value;
    }

    public void ClickOil()
    {
        if (oil < oilMax)
        {
            audioManager.Play("ClickOil");
            oil += 1;
        }
    }

    private IEnumerator GenerateOil()
    {
        yield return new WaitForSeconds(5);
        if (oil == oilMax)
        {
            oil += 0;
        }
        
        if (oil < oilMax)
        {
            if (oil + oilLevel > oilMax)
            {
                oil += oilMax - oil;
            }
            else
            {
                oil += oilLevel;
            }
        }
        StartCoroutine(GenerateOil()); 
    }
}
