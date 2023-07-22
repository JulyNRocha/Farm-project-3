using UnityEngine;
using UnityEngine.Events;

public class AimEventSystem : MonoBehaviour
{
    public static AimEventSystem Instance; // Instância singleton do AimEventSystem

    public UnityEvent<Vector2> OnAimDirectionChange; // Evento para notificar mudanças na direção do alvo

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void NotifyAimDirectionChange(Vector2 direction)
    {
        OnAimDirectionChange.Invoke(direction);
    }
}