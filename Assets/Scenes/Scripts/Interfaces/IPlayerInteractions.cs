using System.Collections.Generic;
using UnityEngine;

public interface IPlayerInteractions
{
    List<Transform> InteractableObjectsInScene { get; }
    IInteractable NearestInterractableObject { get; }

    void OnInteraction();
}