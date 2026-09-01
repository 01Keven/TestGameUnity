using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    private bool isOpen = false;
    public void Interact()
    {
        // Lógica para abrir a porta
        Debug.Log("Porta interagida!");

        if ( isOpen)
        {
            
            Open();
        }
        else
        {
            Close();
        }
    }

    private void Open()
    {
        transform.Rotate(0f, -90f, 0f);
        isOpen = true;
    }

    private void Close()
    {
        transform.Rotate(0f, 90f, 0f);
        isOpen = false;
    }
}