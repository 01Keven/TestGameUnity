using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI keyText;
    [SerializeField] private TextMeshProUGUI messageText;


    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            keyText.gameObject.SetActive(false); // Inicialmente, o texto da chave está desativado
            Instance = this;
        }
    }

    public void ShowMessage(string message, float duration)
    {
        StopAllCoroutines(); // Para qualquer coroutine em execução
        StartCoroutine(HideMessageAfterTime(message, 2f));
    }

    // Coroutine para exibir a mensagem por um tempo determinado
    private System.Collections.IEnumerator HideMessageAfterTime(string message, float duration)
    {
        messageText.text = message;
        messageText.gameObject.SetActive(true);
        yield return new WaitForSeconds(duration); // yeld = pausa a execução da coroutine por um tempo determinado
        messageText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void UpdateKeyDisplay(bool hasKey)
    {
        keyText.gameObject.SetActive(true); // Ativa o texto da chave
        keyText.text = hasKey ? "Key: Acquired" : "Key: Not Acquired";
    }
}
