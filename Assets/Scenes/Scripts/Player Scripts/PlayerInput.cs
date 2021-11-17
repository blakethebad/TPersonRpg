using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    public Vector3 movementVectorRaw;
    public Vector3 movementVectorSmooth;
    public bool isJogging = false;
    public event Action<int> OnAbilitySelect;
    public event Action OnAbilityCast;
    public event Action OnInteraction;
    public event Action OnJogging;
    public event Action OnWalk;
    public event Action OnJump;
    public event Action OnWeaponDrop;
    public event Action OnNormalAttack;
    public event Action OnSpecialAttack;
    public bool isChanneling = false;


     
    private void Update()
    {
        MovementInput();
        ChanelInput();
        JogInput();
        JumpInput();
        InteractionInput();
        EquipmentInput();
        AttackInput();
        AbilitySelectionInput();
        CursorInput();
        AbilityCastInput();
    }

    private void AttackInput()
    {
        if (!isChanneling)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    OnSpecialAttack?.Invoke();
                }
                else
                {
                    OnNormalAttack?.Invoke();
                }


            }
        }
        
        
    }

    private void InteractionInput()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            OnInteraction?.Invoke();
        }
    }

    private void JogInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (isJogging)
            {
                isJogging = false;
                OnWalk?.Invoke();
            }
            else
            {
                isJogging = true;
                
                OnJogging?.Invoke();
            }
        }
    }

    private void JumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnJump();
        }
    }



    private void MovementInput()
    {
        movementVectorRaw = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        movementVectorSmooth = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }

    private void CursorInput()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            SetCursor(false);
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            SetCursor(true);
        }

    }

    private void ChanelInput()
    {
        if (Input.GetMouseButton(1))
        {
            isChanneling = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            isChanneling = false;
        }

    }

    private void EquipmentInput()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            OnWeaponDrop?.Invoke();
        }
    }

    private void AbilityCastInput()
    {
        if (isChanneling)
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnAbilityCast?.Invoke();
            }
        }
    }

    private void AbilitySelectionInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            OnAbilitySelect?.Invoke(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            OnAbilitySelect?.Invoke(1);

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            OnAbilitySelect?.Invoke(2);

        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            OnAbilitySelect?.Invoke(3);

        }
    }

    void SetCursor(bool isCursorOn)
    {
        if (isCursorOn)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
