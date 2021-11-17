using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour, IPlayerInteractions
{

    Player player;
    List<Transform> _interactables = new List<Transform>();
    public List<Transform> InteractableObjectsInScene => GetInteractableObjectsInScene();

    public float interactionRadius = 7f;
    public Transform interactableEnvironment;
    public IInteractable NearestInterractableObject => GetNearestInteractableObject();

    private void Start()
    {
        player = GetComponent<Player>();
    }

    public void OnInteraction()
    {
        if (NearestInterractableObject != null)
        {
            NearestInterractableObject.Interact(player);

        }
        else
        {
            Debug.Log("No Interactable object nearby");
        }
    }

    List<Transform> GetInteractableObjectsInScene()
    {
        _interactables.Clear();
        foreach (Transform transform in interactableEnvironment)
        {
            if (transform.TryGetComponent<IInteractable>(out IInteractable interactable))
            {
                _interactables.Add(transform);
            }
        }

        return _interactables;
    }

    IInteractable GetNearestInteractableObject()
    {
        IInteractable targetInterractable = null;
        float closestDistance = interactionRadius;
        Vector3 currentPos = transform.position;
        foreach (Transform target in InteractableObjectsInScene)
        {
            Vector3 directionToTarget = target.position - currentPos;
            float directionSqr = directionToTarget.sqrMagnitude;
            if (directionSqr < closestDistance)
            {
                closestDistance = directionSqr;
                targetInterractable = target.GetComponent<IInteractable>();
            }
        }

        return targetInterractable;
    }


}