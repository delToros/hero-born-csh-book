using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

// For AI Nav
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{

    // For AI Nav
    public Transform PatrolRoute;//For parent object
    public List<Transform> Locations;//For child objects

    private int _locationIndex = 0;
    private NavMeshAgent _agent;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        InitializePatrolRoute();

        MoveToNextPatrolLocation();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Spotted Player - attack!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.name == "Player")
        {
            Debug.Log("Player out of range - resume patrol");
        }
    }

    void InitializePatrolRoute()
    {
        foreach(Transform child in PatrolRoute)
        {
            Locations.Add(child);
        }
    }

    void MoveToNextPatrolLocation()
    {
        _agent.destination = Locations[_locationIndex].position;
    }
}
