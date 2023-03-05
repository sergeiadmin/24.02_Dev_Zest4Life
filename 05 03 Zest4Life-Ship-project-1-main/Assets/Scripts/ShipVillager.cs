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
    [SerializeField] private TradeMenu tradeMenu;

    private NavMeshAgent _navMeshAgent;

    private bool _singleDelivery;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void Update()
    {
        var storageDistance = Vector3.Distance(transform.position, storageEntrance.position);
        var shipDistance = Vector3.Distance(transform.position, shipEntrance.position);

        if (storageDistance <= 0.1f)
        {
            GetComponent<NavMeshAgent>().speed = 5f;
            _navMeshAgent.destination = shipEntrance.position;
        }
        if (shipDistance <= 0.1f && !_singleDelivery)
        {
            tradeMenu.ShipLeaving();
            _singleDelivery = true;
            GetComponent<NavMeshAgent>().speed = 8f;
            _navMeshAgent.destination = waitingSpot.position;
        }
    }

    public void CarryCargo()
    {
        _singleDelivery = false;
        _navMeshAgent.destination = storageEntrance.position;
    }
}
