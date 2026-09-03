using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI keyText;

    
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

    // Update is called once per frame
    public void UpdateKeyDisplay(bool hasKey)
    {
        keyText.gameObject.SetActive(true); // Ativa o texto da chave
        keyText.text = hasKey ? "Key: Acquired" : "Key: Not Acquired";
    }
}
