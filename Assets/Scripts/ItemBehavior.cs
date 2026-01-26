using UnityEngine;

public class ItemBehavior : MonoBehaviour
{

    public GameBehavior GameManager;

    private void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(gameObject);
            Debug.Log("Item Destroyed");
        }

        GameManager.Items += 1;
    }
}
