using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerAnimator 
{
    void SetMovementAnimation(Vector3 movement);
    void SetAimMovementAnimation(Vector3 movement);
    void SetAimAnimationBool(bool aimBool);
}
