using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OilTower : MonoBehaviour
{
    // Generates oil automatically, stores it and shows amount in menu.
    
    [SerializeField] private int oil;
    [SerializeField] private int oilMax;
    [SerializeField] private int oilLevel;

    [SerializeField] private GameObject oilDisplay;

    public int TowerOil => oil;
    public int OilTowerLevel
    {
        get => oilLevel;
        set => oilLevel = value;
    }

    public int OilTowerCapacity
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
    }

    public void TakeOil(int value)
    {
        oil -= value;
    }

    private IEnumerator GenerateOil()
    {
        if (oil < oilMax)
        {
            yield return new WaitForSeconds(5);
            oil += oilLevel;
            StartCoroutine(GenerateOil());
        }
    }
}
