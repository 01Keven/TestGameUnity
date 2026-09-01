using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactionDistance = 3f;

    private PlayerInputActions inputActions;
    private Camera playerCamera;
    

    private void Awake()
    {
        inputActions = new PlayerInputActions(); // Inicializa a classe de ações de entrada do jogador
        playerCamera = GetComponentInChildren<Camera>(); // Obtém a referência para a câmera do jogador, assumindo que ela é um filho do objeto do jogador
        
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
        // Verifica se o jogador pressionou a tecla de interação neste frame
        if (inputActions.Player.Interact.WasPressedThisFrame())
        {
            // Chama o método para tentar interagir com um objeto
            TryInteract();
        }
    }

    private void TryInteract()
    {
        // Cria um raio a partir da posição da câmera do jogador na direção em que a câmera está olhando
        // Ray ray => Cria um raio que começa na posição da câmera do jogador e se estende na direção em que a câmera está olhando. Esse raio será usado para detectar objetos com os quais o jogador pode interagir.
        Ray ray = new Ray(

            playerCamera.transform.position, // Posição da câmera do jogador
            playerCamera.transform.forward // Direção em que a câmera está olhando
        );

        // Realiza um raycast para verificar se o raio colide com algum objeto dentro da distância de interação
        if (Physics.Raycast(
            ray,
            out RaycastHit hit, // Armazena informações sobre o objeto atingido pelo raio
            interactionDistance // Distância máxima para interação
        ))
        {
            IInteractable interactable = hit.collider.GetComponentInParent<IInteractable>(); // Tenta obter o componente IInteractable do objeto atingido pelo raio ou de seus pais na hierarquia. Isso permite que o jogador interaja com objetos que implementam a interface IInteractable.

            if (interactable != null)
            {
                interactable.Interact();
                Debug.Log("Interagiu com: " + hit.collider.name);
            }
        }

    }
}