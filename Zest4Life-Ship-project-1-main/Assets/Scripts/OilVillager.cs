using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class OilVillager : MonoBehaviour
{
    // Takes oil from tower when available and carries it to storage.
    
    [SerializeField] private Transform storageLocation;
    [SerializeField] private Transform oilTowerLocation;

    [SerializeField] private Storage storage;
    [SerializeField] private OilTower oilTower;

    [SerializeField] private GameObject oilDisplay;
    [SerializeField] private int carryingOilMax;
    [SerializeField] private int speed;

    private int _carryingOil;
    private NavMeshAgent _navMeshAgent;

    public int CarrierSpeed
    {
        get => speed;
        set => speed = value;
    }

    public int CarrierCapacity
    {
        get => carryingOilMax;
        set => carryingOilMax = value;
    }

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }
    
    private void Update()
    {
        GetComponent<NavMeshAgent>().speed = speed;
        oilDisplay.GetComponent<TextMeshProUGUI>().text = "Carrying oil: " + _carryingOil + " / " + carryingOilMax;
        
        if (_carryingOil <= 0 && oilTower.TowerOil > 0)
        {
            _navMeshAgent.destination = oilTowerLocation.position;
        }
        else if (_carryingOil > 0)
        {
            _navMeshAgent.destination = storageLocation.position;
        }
    }
    
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("OilTower"))
        {
            if (oilTower.TowerOil >= carryingOilMax)
            {
                oilTower.TakeOil(carryingOilMax);
                _carryingOil += carryingOilMax;
            }
            else
            {
                _carryingOil += oilTower.TowerOil; 
                oilTower.TakeOil(oilTower.TowerOil);
            }
        }
        if (other.gameObject.CompareTag("Storage"))
        {
            if (_carryingOil > 0)
            {
                storage.StoreOil(_carryingOil);
                _carryingOil = 0;
            }
        }
    }
}
