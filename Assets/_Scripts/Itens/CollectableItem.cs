using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    private Transform playerTransform;
    public float followSpeed = 5f;

    private bool isCollected = false;

    private void Start()
    {
        playerTransform = ItemCollector.instance.transform;
    }

    private void Update()
    {
        // Verificar se o item ainda não foi coletado
        if (!isCollected)
        {
            // Fazer o item seguir o jogador suavemente
            transform.position = Vector3.Lerp(transform.position, playerTransform.position, followSpeed * Time.deltaTime);
        }
    }

    public void CollectItem()
    {
        // Marcar o item como coletado e destruí-lo
        isCollected = true;
        Destroy(gameObject);
    }
}
