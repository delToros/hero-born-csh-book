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

    private Transform Player;

    // For Enemy health & bullet collision
    private int _lives = 3;
    public int EnemyLives
    {
        get { return _lives; }

        private set
        {
            _lives = value;

            if (_lives <= 0)
            {
                Destroy(gameObject);
                Debug.Log("Enemy down.");
            }
        }
    }

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        Player = GameObject.Find("Player").transform;

        InitializePatrolRoute();

        MoveToNextPatrolLocation();
    }

    private void Update()
    {
        if (_agent.remainingDistance < 0.2f && !_agent.pathPending)
        {
            MoveToNextPatrolLocation();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            _agent.destination = Player.position;
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
        if (Locations.Count == 0) return;

        _agent.destination = Locations[_locationIndex].position;

        _locationIndex = (_locationIndex + 1) % Locations.Count;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            EnemyLives -= 1;
            Debug.Log("We have a hit!");
        }
    }
}
