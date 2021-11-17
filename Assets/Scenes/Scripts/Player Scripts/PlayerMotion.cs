using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : MonoBehaviour, IPlayerMotion
{
    [Range(1,10)] [SerializeField] float walkSpeed;
    [Range(1, 20)] [SerializeField] float jogSpeed;
    [SerializeField] float jumpHeight = 1.0f;
    float gravity = 9.81f;
    float groundTime;

    IPlayerController playerController;

    private void Start()
    {
        playerController = GetComponent<IPlayerController>();

    }

    private void Update()
    {
        CheckGroundTime();
    }

    void CheckGroundTime()
    {
        if (playerController.IsGrounded)
        {
            groundTime = 0.2f;
        }
        if (groundTime > 0)
        {
            groundTime -= Time.deltaTime;
        }
    }

    public void Jog() => playerController.MovementSpeed = jogSpeed;

    public void Jump()
    {
        if (groundTime > 0)
        {
            groundTime = 0;
            Vector3 velocity = new Vector3(0, Mathf.Sqrt(2f * gravity * jumpHeight), 0);

            playerController.VelocityVector = velocity;
        }
    }

    public void Walk() => playerController.MovementSpeed = walkSpeed;
}
