using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableHandable : MonoBehaviour
{
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;
    Character character;
    [SerializeReference] HighlighController highlighController;
    Mover mover;
    Aimer aimer;

    private void Awake()
    {
        character = GetComponent<Character>();
        mover = GetComponent<Mover>();
        aimer = GetComponent<Aimer>();
    }

    private void Update()
    {
        CheckInteractable();
        
        if (Input.GetMouseButtonDown(1))
        {
            Interact();
        }
    }

    private void CheckInteractable()
    {
        Vector2 position = (Vector2)transform.position + (aimer.GetAimDirection() * offsetDistance);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach (Collider2D c in colliders)
        {
            Interactable hit = c.GetComponent<Interactable>();
            if (hit != null)
            {
                highlighController.Highligh(hit.gameObject);
                return;           
            }
        }

        highlighController.Hide();
    }

    private void Interact()
    {
        Vector2 position = (Vector2)transform.position + (aimer.GetAimDirection() * offsetDistance);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach (Collider2D c in colliders)
        {
            Interactable hit = c.GetComponent<Interactable>();
            if (hit != null)
            {
                hit.Interact(character);
                break;
            }
        }
    }
}
