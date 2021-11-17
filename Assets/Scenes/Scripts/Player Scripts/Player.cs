using UnityEngine;

public class Player : MonoBehaviour
{
    public IPlayerEquipment PLayerEquipment => _playerEquipment;
    public IPlayerCombat PlayerCombat => _playerCombat;

    IPlayerController _playerController;
    IPlayerMotion _playerMotion;
    IPlayerAnimator _playerAnimator;
    IPlayerInteractions _playerInteractions;
    IPlayerCombat _playerCombat;
    IPlayerAbilities _playerAbilities;
    IPlayerEquipment _playerEquipment;
    PlayerInput playerInput;


    private void Start()
    {
        GetDependecies();

        SetUpEvents();

    }

    private void FixedUpdate()
    {
        HandleMovement();
       
    }

    private void Update()
    {
        HandleAnimations();

    }

    void HandleMovement()
    {
        _playerController.HandleGravity();

        if (playerInput.isChanneling)
        {
            _playerController.HandleAimMovement(playerInput.movementVectorRaw.normalized);
        }

        else
        {
            if (playerInput.movementVectorRaw.magnitude > 0)
            {

                _playerController.HandlePlayerMovement(playerInput.movementVectorRaw.normalized);
            }
        }
    }

    void HandleAnimations()
    {
        _playerAnimator.SetAimAnimationBool(playerInput.isChanneling);

        if (playerInput.isChanneling)
        {
            _playerAnimator.SetAimMovementAnimation(playerInput.movementVectorSmooth);
        }
        else
        {
            _playerAnimator.SetMovementAnimation(playerInput.movementVectorRaw);
        }
    }

    void HandleEquipment()
    {
        _playerEquipment.DropWeapon(_playerEquipment.EquippedWeapon);
    }

    void HandleAbilities()
    {

    }

    private void GetDependecies()
    {
        _playerAbilities = GetComponent<IPlayerAbilities>();
        _playerEquipment = GetComponent<IPlayerEquipment>();
        _playerInteractions = GetComponent<IPlayerInteractions>();
        _playerCombat = GetComponent<IPlayerCombat>();
        _playerController = GetComponent<IPlayerController>();
        _playerMotion = GetComponent<IPlayerMotion>();
        _playerAnimator = GetComponent<IPlayerAnimator>();
        playerInput = GetComponent<PlayerInput>();
    }

    private void SetUpEvents()
    {
        playerInput.OnJump += _playerMotion.Jump;
        playerInput.OnJogging += _playerMotion.Jog;
        playerInput.OnWalk += _playerMotion.Walk;
        playerInput.OnInteraction += _playerInteractions.OnInteraction;
        playerInput.OnWeaponDrop += HandleEquipment;
        playerInput.OnNormalAttack += _playerCombat.PerformNormalAttack;
        playerInput.OnSpecialAttack += _playerCombat.PerformSpecialAttack;
        playerInput.OnAbilitySelect += _playerAbilities.SelectAbility;
        playerInput.OnAbilityCast += _playerAbilities.CastSelectedAbility;
    }


}
