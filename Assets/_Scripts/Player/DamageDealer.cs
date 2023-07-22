using UnityEngine;
using System;

public class DamageDealer : MonoBehaviour
{
    public event Action<int, DamageEffectType> OnDamageDeal; // Evento de dano com o tipo de efeito

    [Header("Damage Making Properties")]
    public LayerMask damageLayers;
    [SerializeField] public float damageRange = 1.5f;
    [SerializeField] public int damageAmount = 10;
    [SerializeField] public DamageEffectType damageEffect = DamageEffectType.None;

    private Vector2 miningDirection;

    private void OnEnable()
    {
        if (AimEventSystem.Instance != null)
        {
            AimEventSystem.Instance.OnAimDirectionChange.AddListener(OnAimDirectionChange);
        }
    }

    private void OnDisable()
    {
        AimEventSystem.Instance.OnAimDirectionChange.RemoveListener(OnAimDirectionChange);
    }

    private void OnAimDirectionChange(Vector2 direction)
    {
        miningDirection = direction;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PerformDamage();
        }
    }

    private void PerformDamage()
    {
        Vector2 miningStartPosition = (Vector2)transform.position + miningDirection * damageRange / 2f;
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(miningStartPosition, damageRange, damageLayers);

        foreach (Collider2D collider in hitColliders)
        {
            IHitable hitable = collider.GetComponent<IHitable>();
            if (hitable != null)
            {
                Debug.Log("HIT!");
                hitable.TakeDamage(damageAmount, damageEffect); // Passe o tipo de efeito para o método TakeDamage

                // Dispare o evento OnDamageDeal para notificar os ouvintes do dano causado
                OnDamageDeal?.Invoke(damageAmount, damageEffect);
            }
        }
    }
}