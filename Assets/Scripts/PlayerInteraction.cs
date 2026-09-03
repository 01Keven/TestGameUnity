using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactionDistance = 3f;
    [SerializeField] private GameObject interactionUI;

    private PlayerInputActions inputActions;
    private Camera playerCamera;

    private IInteractable currentInteractable; // Referência para o objeto interagível atualmente detectado pelo jogador
    

    private void Awake()
    {
        inputActions = new PlayerInputActions(); // Inicializa a classe de ações de entrada do jogador
        playerCamera = GetComponentInChildren<Camera>(); // Obtém a referência para a câmera do jogador, assumindo que ela é um filho do objeto do jogador
        interactionUI.SetActive(false); // Inicialmente, a interface de usuário de interação está desativada
        
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
        CheckInteractable(); // Verifica se há algum objeto interagível na frente do jogador
        // Verifica se o jogador pressionou a tecla de interação neste frame
        if (inputActions.Player.Interact.WasPressedThisFrame())
        {
            // Chama o método para tentar interagir com um objeto
            TryInteract();
        }
    }

    private void CheckInteractable()
    {
        // Cria um raio a partir da posição da câmera do jogador na direção em que a câmera está olhando
        Ray ray = new Ray(
            playerCamera.transform.position, // Posição da câmera do jogador
            playerCamera.transform.forward // Direção em que a câmera está olhando
        );

        if (Physics.Raycast(
            ray,
            out RaycastHit hit, // Armazena informações sobre o objeto atingido pelo raio
            interactionDistance // Distância máxima para interação
        ))
        {
            IInteractable interactable = hit.collider.GetComponentInParent<IInteractable>(); // Tenta obter o componente IInteractable do objeto atingido pelo raio ou de seus pais na hierarquia

            if (interactable != null)
            {
                currentInteractable = interactable; // Atualiza a referência para o objeto interagível atualmente detectado
                interactionUI.SetActive(true); // Ativa a interface de usuário de interação
                // Debug.Log("Objeto interagível detectado: " + hit.collider.name);
                return;
            }
        }
            currentInteractable = null; // Nenhum objeto interagível detectado
            interactionUI.SetActive(false); // Desativa a interface de usuário de interação
        
    }

    private void TryInteract()
    {
        
        if (currentInteractable != null)
        {
            currentInteractable.Interact(this.gameObject); // Chama o método de interação do objeto interagível, passando o jogador como parâmetro
            Debug.Log("Interagiu com: " + currentInteractable.ToString());
        }
    }

}
