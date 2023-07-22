using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Aimer : MonoBehaviour
{
    private List<IAim> IAimInterfaces = new List<IAim>();

    private Vector2 lastAimDirection;

    private void Awake()
    {
        GetComponentsInChildren<IAim>(true, IAimInterfaces);
    }

    private void Update()
    {
        Vector2 aimDirection = GetInputAimDirection();

        if (aimDirection != lastAimDirection)
        {
            lastAimDirection = aimDirection;
            AimEventSystem.Instance.NotifyAimDirectionChange(aimDirection); // Notificar a mudança de direção do alvo
        }
    }

    private Vector2 GetInputAimDirection()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return (mousePosition - (Vector2)transform.position).normalized;
        
    }


    public Vector2 GetAimDirection()
    {
        return lastAimDirection;
    }

    public Vector2 GetAimPosition()
    {
        return (Vector2)transform.position + (GetAimDirection() * 0.10f);
    }

    public void LookAt(Vector2 target)
    {
        Vector2 lookVector = (target - (Vector2)this.transform.position);

        if (Mathf.Abs(lookVector.x) > Mathf.Abs(lookVector.y))
        {
            lookVector.y = 0;

            if (lookVector.x > 0)
            {
                lookVector.x = 1;
            }
            else
            {
                lookVector.x = -1;
            }
        }
        else
        {
            lookVector.x = 0;

            if (lookVector.y > 0)
            {
                lookVector.y = 1;
            }
            else
            {
                lookVector.y = -1;
            }
        }

        SetAimDirection(lookVector);
    }

    public void SetAimDirection(Vector2 direction)
    {
        foreach (IAim aimInterface in IAimInterfaces)
        {
            aimInterface.OnAim(direction);
        }

        lastAimDirection = direction;
    }

    #region Debug 

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + lastAimDirection);
        Gizmos.DrawSphere((Vector2)transform.position + lastAimDirection, 0.1f);
    }

    #endregion
   
}