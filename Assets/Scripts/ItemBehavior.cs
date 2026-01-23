using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(gameObject);
            Debug.Log("Item Destroyed");
        }
    }
}
