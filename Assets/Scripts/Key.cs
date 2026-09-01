using UnityEngine;

public class Key : MonoBehaviour, IInteractable
{
    [SerializeField] private string keyName; // Nome da chave
    [SerializeField] private Door doorToUnlock; // Referência para a porta que esta chave destranca


    public void Interact()
    {
        // Lógica para pegar a chave
        Debug.Log($"Chave {keyName} coletada!");
        // Aqui você pode adicionar lógica para adicionar a chave ao inventário do jogador, etc.
        if (doorToUnlock != null)
        {
            doorToUnlock.Unlock(); // Destranca a porta associada a esta chave
        }
        Destroy(gameObject); // Remove a chave do mundo após ser coletada
    }

    
}
