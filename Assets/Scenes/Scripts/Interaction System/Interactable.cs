using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour ,IInteractable
{
    Transform interactableObjectPool;

    private void Awake()
    {
        interactableObjectPool = FindObjectOfType<InteractableManager>().transform;

        transform.SetParent(interactableObjectPool);
    }

    public virtual void Interact(Player player)
    {
        Debug.Log($"Player interacted with item");
    }
}
