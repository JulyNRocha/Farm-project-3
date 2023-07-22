using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDroped : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o objeto que entrou em contato é o jogador (ou um objeto com uma tag específica, se preferir).
        if (other.CompareTag("Player"))
        {
            // Destruir o objeto do item.
            Destroy(gameObject);
        }
    }
}
