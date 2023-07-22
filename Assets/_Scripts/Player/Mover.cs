using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D)), DisallowMultipleComponent()]
public class Mover : MonoBehaviour
{

    [SerializeField] float speed;

    List<IMove> IMoveInterfaces = new List<IMove>();
    List<IFreezeMovement> IFreezeMovementInterfaces = new List<IFreezeMovement>();

    Rigidbody2D rigidBody2D;
    bool isMovementFrozen;
    
    public bool IsMovementFrozen { get { return isMovementFrozen; } }

    void Awake()
    {
        if (rigidBody2D == null)
            rigidBody2D = GetComponent<Rigidbody2D>();

        GetComponentsInChildren<IMove>(true, IMoveInterfaces);
        GetComponentsInChildren<IFreezeMovement>(true, IFreezeMovementInterfaces);

        DispatchMoveEvent(Vector2.zero, 0);
    }

    void Update() {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        Vector2 direction = new Vector2(horizontal, vertical);

        Move(direction);
    }

    public void Move(Vector2 direction)
    {
        if (isMovementFrozen)
        {
            return;
        }

        direction.Normalize();

        rigidBody2D.MovePosition((Vector2)this.transform.position + ((direction * speed) * Time.deltaTime));

        DispatchMoveEvent(direction, (direction.x == 0 && direction.y == 0) ? 0 : speed);
    }

    public void SetPosition(Vector2 position)
    {
        rigidBody2D.MovePosition(position);
        DispatchMoveEvent(Vector2.zero, 0);
    }
        
    public void FreezeMovement(bool state)
    {
        isMovementFrozen = state;

        DispatchMoveEvent(Vector2.zero, 0);
        DispatchFreezeEvent(state);
    }

    void DispatchMoveEvent(Vector2 direction, float speed)
    {

        for (int i = 0; i < IMoveInterfaces.Count; i++)
        {
            IMoveInterfaces[i].OnMove(direction, speed);
        }
    }

    void DispatchFreezeEvent(bool isFrozen)
    {
        for (int i = 0; i < IFreezeMovementInterfaces.Count; i++)
        {
            IFreezeMovementInterfaces[i].OnMovementFrozen(isFrozen);
        }
    }
}
