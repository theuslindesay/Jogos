using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Configurações de Vitória")]
    public int moedasParaVencer = 10; 

    [Header("Interface (UI)")]
    public GameObject victoryPanel;
    public TextMeshProUGUI coinCountText; 

    private int moedasColetadas = 0;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        if (victoryPanel != null) victoryPanel.SetActive(false);
        Time.timeScale = 1;

        AtualizarTextoUI();
        Debug.Log($"Objetivo: Coletar {moedasParaVencer} moedas.");
    }

    public void AddCoin()
    {
        moedasColetadas++;
        Debug.Log($"Moedas: {moedasColetadas} / {moedasParaVencer}");

        AtualizarTextoUI();

        if (moedasColetadas >= moedasParaVencer)
        {
            VencerJogo();
        }
    }

    void AtualizarTextoUI()
    {
        if (coinCountText != null)
        {
            coinCountText.text = $"Moedas: {moedasColetadas} / {moedasParaVencer}";
        }
    }

    void VencerJogo()
    {
        Debug.Log("PARABÉNS! VOCÊ VENCEU!");
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(true);
            
            Time.timeScale = 0; 
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
