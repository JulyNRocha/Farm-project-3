using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public GameObject[] itemsToDrop;
    public float dropSpeed = 5f;

    private void OnDestroy()
    {
        if (itemsToDrop != null)
        {
            Vector3 playerPosition = ItemCollector.instance.GetPlayerPosition();
            foreach (GameObject item in itemsToDrop)
            {
                GameObject droppedItem = Instantiate(item, transform.position, Quaternion.identity);
                Rigidbody2D rb = droppedItem.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    Vector2 directionToPlayer = ((Vector2)playerPosition - (Vector2)droppedItem.transform.position).normalized;
                    rb.velocity = directionToPlayer * dropSpeed;
                }
            }
        }
    }
}