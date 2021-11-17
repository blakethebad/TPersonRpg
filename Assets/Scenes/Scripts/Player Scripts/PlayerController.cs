using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IPlayerController
{
    Transform cameraTransform;
    CharacterController cc;
    public float TurnSpeed { get; set; } = 10;
    public bool IsGrounded { get; set; }
    public float MovementSpeed { get; set; }
    public Vector3 VelocityVector { get { return velocity; } set { SetVelocity(value); } }
    public Vector3 velocity;


    float gravity = 9.81f;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;
        
    }


    public void HandlePlayerMovement(Vector3 directionVector)
    {
        Vector3 targetDirection = MovementTools.GetDirectionVectorFromTransformAxes(cameraTransform, directionVector);
        velocity.x = targetDirection.x;
        velocity.z = targetDirection.z;
        Vector3 euler = MovementTools.GetRotationEuler(transform, targetDirection);

        if (directionVector != Vector3.zero && targetDirection.magnitude > 0.1f)
        {

            MovementTools.RotatePlayer(euler, TurnSpeed, transform);
            MovementTools.MovePlayer(VelocityVector, MovementSpeed, cc);


        }
    }

    public void HandleAimMovement(Vector3 directionVector)
    {
        Vector3 targetDirection = MovementTools.GetDirectionVectorFromTransformAxes(transform, directionVector);
        velocity.x = targetDirection.x;
        velocity.z = targetDirection.z;

        Vector3 cameraForward = cameraTransform.TransformDirection(Vector3.forward);
        cameraForward.y = 0;

        Vector3 euler = MovementTools.GetRotationEuler(transform,cameraForward);

        MovementTools.RotatePlayer(euler, TurnSpeed, transform);

        if (directionVector.magnitude != 0 && targetDirection.magnitude > 0.1f) { MovementTools.MovePlayer(VelocityVector, MovementSpeed, cc); }
    }


    public void HandleGravity()
    {
        IsGrounded = cc.isGrounded;

        if (IsGrounded && velocity.y < 0)
        {
            velocity.y = 0;
        }

        velocity.y -= gravity * Time.fixedDeltaTime;

        if (IsGrounded == false)
        {
            cc.Move(velocity * Time.fixedDeltaTime);
        }
    }



    void SetVelocity(Vector3 vector)
    {
        if (vector.x == 0)
        {
            if (vector.z == 0)
            {
                velocity.y = vector.y;
            }
        }
        else
        {
            velocity = vector;
        }
    }


}





