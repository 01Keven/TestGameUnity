using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float sprintSpeed = 10f;
    [SerializeField] private float gravity = -9.81f;

    private CharacterController controller;
    private PlayerInputActions inputActions;

    private float currentSpeed;
    private float verticalVelocity;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();

        inputActions = new PlayerInputActions();

        currentSpeed = walkSpeed;

        inputActions.Player.Sprint.performed += ctx =>
        {
            currentSpeed = sprintSpeed;
        };

        inputActions.Player.Sprint.canceled += ctx =>
        {
            currentSpeed = walkSpeed;
        };
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void Update()
    {
        Vector2 input =
            inputActions.Player.Move.ReadValue<Vector2>();

        Vector3 movement =
            transform.right * input.x +
            transform.forward * input.y;

        movement *= currentSpeed;

        // Gravidade
        if (controller.isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -2f;
        }

        verticalVelocity += gravity * Time.deltaTime;

        movement.y = verticalVelocity;

        controller.Move(
            movement * Time.deltaTime
        );
    }
}