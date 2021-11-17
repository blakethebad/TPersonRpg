using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerController
{
    bool IsGrounded { get; set; }
    float MovementSpeed { get; set; }
    Vector3 VelocityVector { get; set; }
    void HandlePlayerMovement(Vector3 directionVector);
    void HandleAimMovement(Vector3 directionVector);
    void HandleGravity();
}
