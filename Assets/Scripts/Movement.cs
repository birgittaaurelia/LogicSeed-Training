using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private MovementCharacter movementCharacter;
    public bool canMove = false;
    public InputAction jumpAction;
    public InputAction attackAction;
    public InputAction dashAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        jumpAction.Enable();
        dashAction.Enable();
        attackAction.Enable();
    }
    void Start()
    {
        movementCharacter = GetComponent<MovementCharacter>();
    }
    void Update()
    {
        if (canMove)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            movementCharacter.OnMovementCharacter(horizontalInput);

            if (jumpAction.WasPressedThisFrame())
            {
                movementCharacter.OnJumpCharacter();
            }

            if (dashAction.WasPressedThisFrame())
            {
                movementCharacter.OnDashCharacter(horizontalInput);
            }

            if (attackAction.WasPressedThisFrame())
            {
                movementCharacter.OnAttackCharacter();
            }
        }
        
    }

}