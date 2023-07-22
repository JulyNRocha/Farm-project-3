using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteractable : Interactable
{
    [SerializeField] Color openChestColor;
    [SerializeField] Color closedChestColor;
    [SerializeField] bool isOpen;
    private SpriteRenderer square;

    public override void Interact(Character character)
    {
        square = GetComponent<SpriteRenderer>(); 
        if(isOpen == false)
        {
            isOpen = true;
            square.color = openChestColor;
        }
        
    }
    
}
