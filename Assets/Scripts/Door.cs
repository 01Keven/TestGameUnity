using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        // Lógica para abrir a porta
        Debug.Log("Porta interagida!");
    }
}