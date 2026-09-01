using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private float openAngle = 90f; // Ângulo de abertura da porta
    [SerializeField] private float openDuration = 2f; // Duração da animação de abertura da porta
    private bool isOpen = false;
    private bool isMoving = false;

    public void Interact()
    {
        // Lógica para abrir a porta
        Debug.Log("Porta interagida!");

        if (isMoving)
        {
            return; // Se a porta já estiver se movendo, não faça nada
        }

        if ( isOpen)
        {
            
            Close();
        }
        else
        {
            Open();
        }
    }

    private void Open()
    {
        isOpen = true;
        StartCoroutine(RotateDoor(openAngle));
    }

    private void Close()
    {
        isOpen = false;
        StartCoroutine(RotateDoor(0f));
    }

    private IEnumerator RotateDoor(float targetAngle)
    {
        isMoving = true; // Indica que a porta está se movendo
        float currentAngle = transform.localEulerAngles.y; // Obtém o ângulo atual da porta no eixo Y
        float elapsedTime = 0f; // Tempo decorrido desde o início da animação

        while (elapsedTime < openDuration) // Enquanto o tempo decorrido for menor que a duração da animação
        {
            elapsedTime += Time.deltaTime; // Incrementa o tempo decorrido com o tempo do frame atual
            float newAngle = Mathf.Lerp(currentAngle, targetAngle, elapsedTime / openDuration); // Interpola linearmente entre o ângulo atual e o ângulo alvo com base no tempo decorrido
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, newAngle, transform.localEulerAngles.z); // Atualiza o ângulo da porta no eixo Y, mantendo os ângulos nos eixos X e Z inalterados
            yield return null; // Aguarda o próximo frame antes de continuar a execução do loop
        }

        // Garantir que a porta esteja exatamente no ângulo final
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, targetAngle, transform.localEulerAngles.z);

        isMoving = false; // Indica que a porta terminou de se mover
    }
}