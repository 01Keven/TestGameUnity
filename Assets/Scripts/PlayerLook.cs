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
        Vector2 lookInput = inputActions.Player.Look.ReadValue<Vector2>();

        float mouseX = lookInput.x * mouseSensitivity;
        float mouseY = lookInput.y * mouseSensitivity;

        // Rotação vertical da câmera
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -70f, 70f);

        // Aplicar rotação vertical à câmera
        // Quaternion.Euler cria uma rotação a partir de ângulos de Euler (em graus) para cada eixo (x, y, z). Aqui, estamos definindo a rotação local da câmera apenas no eixo x (pitch), mantendo os eixos y (yaw) e z (roll) em 0. Isso significa que a câmera só vai olhar para cima e para baixo, sem girar para os lados ou inclinar.
        transform.localRotation = Quaternion.Euler(
            xRotation,
            0f,
            0f
        );

        // Rotação horizontal do corpo
        playerBody.Rotate(
            Vector3.up * mouseX
        );
    }
}