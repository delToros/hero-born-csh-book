using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float OnScreenDelay = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, OnScreenDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
