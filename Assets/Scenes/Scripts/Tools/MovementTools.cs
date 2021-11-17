using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTools : MonoBehaviour
{
    public static Vector3 GetDirectionVectorFromTransformAxes(Transform transform, Vector3 directionVector)
    {
        Vector3 cameraForward = transform.TransformDirection(Vector3.forward);
        cameraForward.y = 0;
        Vector3 cameraRight = transform.TransformDirection(Vector3.right);

        Vector3 targetDirection = directionVector.x * cameraRight + directionVector.z * cameraForward;
        return targetDirection;
    }


    public static Vector3 GetRotationEuler(Transform transform, Vector3 cameraDirection)
    {
        Quaternion targetRotation = Quaternion.LookRotation(cameraDirection, transform.up);

        var currentRotation = transform.eulerAngles.y;
        var newRotation = targetRotation.eulerAngles.y - currentRotation;
        if (newRotation < 0 || newRotation > 0)
        {
            currentRotation = targetRotation.eulerAngles.y;
        }
        var euler = new Vector3(0, currentRotation, 0);
        return euler;
    }

    public static void MovePlayer(Vector3 velocity, float movementSpeed, CharacterController cc)
    {
        Vector3 movement = velocity.normalized * movementSpeed * Time.fixedDeltaTime;
        cc.Move(movement);
    }

    public static void RotatePlayer(Vector3 euler, float turnSpeed, Transform transform)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(euler), turnSpeed * Time.deltaTime);

    }
}
