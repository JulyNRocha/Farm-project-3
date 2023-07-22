using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public static ItemCollector instance; // Instância estática do PlayerController

    private Transform playerTransform;
    private Vector2 playerPosition;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this; // Definir a instância como esta (this) se não houver outra instância
        }
        else
        {
            Destroy(gameObject); // Se já houver uma instância, destruir este GameObject
            return;
        }

        playerTransform = transform;
    }

    private void Update()
    {
        playerPosition = playerTransform.position;
    }

    public Vector2 GetPlayerPosition()
    {
        return playerPosition;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar se o objeto que colidiu é um item coletável
        CollectableItem item = other.GetComponent<CollectableItem>();
        if (item != null)
        {
            // Coletar o item
            item.CollectItem();
        }
    }

    // Adicione outros métodos e funcionalidades do jogador aqui
}