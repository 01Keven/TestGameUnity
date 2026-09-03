using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 0.1f;
    [SerializeField] private Transform playerBody;

    private PlayerInputActions inputActions;

    private float xRotation = 0f;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        inputActions.Enable();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnDisable()
    {
        inputActions.Disable();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void Update()
    {
        if (playerBody == null)
        {
            Debug.LogError("PlayerBody não foi atribuído.");
            return;
        }

        // Vector2 lookInput =
        //     inputActions.Player.Look.ReadValue<Vector2>();

        Vector2 lookInput = UnityEngine.InputSystem.Mouse.current.delta.ReadValue();

        float mouseX = lookInput.x * mouseSensitivity;
        float mouseY = lookInput.y * mouseSensitivity;
        // Debug.Log(lookInput);

        // Rotação vertical da câmera
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(
            xRotation,
            -90f,
            90f
        );

        transform.localRotation =
            Quaternion.Euler(
                xRotation,
                transform.localEulerAngles.y,
                0f
            );

        // Rotação horizontal do Player
        playerBody.Rotate(
            Vector3.up * mouseX,
            Space.Self
        );
    }
}