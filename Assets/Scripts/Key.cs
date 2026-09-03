using UnityEngine;

public class Key : MonoBehaviour, IInteractable
{
    [SerializeField] private string keyName; // Nome da chave
    [SerializeField] private Door doorToUnlock; // Referência para a porta que esta chave destranca


    public void Interact(GameObject interactor)
    {
        PlayerInventory inventory = interactor.GetComponent<PlayerInventory>();
        // Lógica para pegar a chave
        Debug.Log($"Chave {keyName} coletada!");
        // Aqui você pode adicionar lógica para adicionar a chave ao inventário do jogador, etc.
        if (inventory != null)
        {
            inventory.hasKey = true; // Indica que o jogador possui a chave
            UIManager.Instance.UpdateKeyDisplay(true); // Atualiza a exibição da chave
            Destroy(gameObject); // Remove a chave do mundo após ser coletada
        }
        Destroy(gameObject); // Remove a chave do mundo após ser coletada
        
    }

    
}
