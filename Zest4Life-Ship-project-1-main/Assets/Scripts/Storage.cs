using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Storage : MonoBehaviour
{
    // Stores resourses and shows amounts in menu.
    
    [SerializeField] private int oil;
    [SerializeField] private int oilMax;
    [SerializeField] private int fuel;
    [SerializeField] private int fuelMax;
    [SerializeField] private int wood;
    [SerializeField] private int woodMax;
    [SerializeField] private int stone;
    [SerializeField] private int stoneMax;
    [SerializeField] private int coins;
    [SerializeField] private int gems;

    [SerializeField] private GameObject oilDisplay;
    [SerializeField] private GameObject coinsDisplay;

    public int StorageOil
    {
        get => oil;
        set => oil = value;
    }

    public int StorageCoins
    {
        get => coins;
        set => coins = value;
    }

    public int OilCapacity
    {
        get => oilMax;
        set => oilMax = value;
    }

    private void Start()
    {
        StartCoroutine(StoredResourses());
    }
    
    private void Update()
    {
        oilDisplay.GetComponent<TextMeshProUGUI>().text = "Oil in storage: " + oil + " / " + oilMax;
        coinsDisplay.GetComponent<TextMeshProUGUI>().text = "Coins: " + coins;
    }
    
    public void StoreOil(int value)
    {
        oil += value;
    }

    private IEnumerator StoredResourses()
    {
        yield return new WaitForSeconds(5);
        StartCoroutine(StoredResourses());
    }
}