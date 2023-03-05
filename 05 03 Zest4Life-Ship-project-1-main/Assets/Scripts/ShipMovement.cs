using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class ShipMovement : MonoBehaviour
{
    // Launches ship through waypoints, returns in to docks after delay timer, adds new coins and oil to storage
    
    [SerializeField] private Transform shipPath;
    [SerializeField] private Transform dockingPosition;

    [SerializeField] private Storage storage;
    [SerializeField] private TradeMenu tradeMenu;

    [SerializeField] private int shipReturnDelayMilliseconds;

    private NavMeshAgent _navMeshAgent;
    private List<Transform> _currentWaypoint;
    private int _waypointIndex;
    private bool _singleDelivery;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _currentWaypoint = GetShipWaypoints();
    }

    private void Update()
    {
        var waypointDistance = Vector3.Distance(transform.position, _currentWaypoint[_waypointIndex].position);
        var dockingDistance = Vector3.Distance(transform.position, dockingPosition.position);
        
        if (waypointDistance <= 0.1f && _waypointIndex < _currentWaypoint.Count-1)
        {
            _waypointIndex++;
            _navMeshAgent.destination = _currentWaypoint[_waypointIndex].position;
        }
        if (dockingDistance <= 0.1f && !_singleDelivery)
        {
            if (tradeMenu.OilAmount > 0)
            {
                storage.Oil += tradeMenu.OilAmount;
            }
            if (tradeMenu.OilAmount < 0)
            {
                storage.Coins += tradeMenu.ProfitCoins;
            }
            _singleDelivery = true;
            tradeMenu.ResetTrading();
        }
    }

    public async void FollowPath()
    {
        _waypointIndex = 0;
        _navMeshAgent.destination = _currentWaypoint[_waypointIndex].position;
        await Task.Delay (shipReturnDelayMilliseconds);
        ReturnToDocks();
    }

    public void ReturnToDocks()
    {
        _singleDelivery = false;
        _navMeshAgent.destination = dockingPosition.position;
    }

    private List<Transform> GetShipWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform child in shipPath)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }
}