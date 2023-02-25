using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShipVillager : MonoBehaviour
{
    // Carries cargo from storage to ship, when called
    
    [SerializeField] private Transform storageEntrance;
    [SerializeField] private Transform shipEntrance;
    [SerializeField] private Transform waitingSpot;
    
    private NavMeshAgent _navMeshAgent;
    private TradeMenu _tradeMenu;

    private bool _singleDelivery;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _tradeMenu = FindObjectOfType<TradeMenu>();
    }

    public void Update()
    {
        if (transform.position == storageEntrance.position)
        {
            GetComponent<NavMeshAgent>().speed = 5f;
            _navMeshAgent.destination = shipEntrance.position;
        }
        if (transform.position == shipEntrance.position && !_singleDelivery)
        {
            _tradeMenu.ShipLeaving();
            _singleDelivery = true;
            GetComponent<NavMeshAgent>().speed = 10f;
            _navMeshAgent.destination = waitingSpot.position;
        }
    }

    public void CarryCargo()
    {
        _singleDelivery = false;
        _navMeshAgent.destination = storageEntrance.position;
    }
}
