using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Paneles Principales")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject gameplayPanel;
    [SerializeField] private GameObject levelCompletePanel;
    [SerializeField] private GameObject gameOverPanel;

    [Header("Textos Menú Principal")]
    [SerializeField] private TextMeshProUGUI txtNivelMenu;
    [SerializeField] private TextMeshProUGUI txtHighScoreMenu;

    [Header("Textos HUD Gameplay")]
    [SerializeField] private TextMeshProUGUI txtNivelHUD;
    [SerializeField] private TextMeshProUGUI txtPuntosHUD;
    [SerializeField] private TextMeshProUGUI txtVidasHUD;

    [Header("Textos Game Over (Nivel 3)")]
    [SerializeField] private TextMeshProUGUI txtPuntosFinales;
    [SerializeField] private TextMeshProUGUI txtRecordGameOver;

    public void MostrarMenuPrincipal(int nivelActual, int highScore)
    {
        mainMenuPanel.SetActive(true);
        gameplayPanel.SetActive(false);
        levelCompletePanel.SetActive(false);
        gameOverPanel.SetActive(false);

        string nombreModo = nivelActual == 3 ? "Nivel 3 (Modo Infinito)" : $"Nivel {nivelActual}";
        txtNivelMenu.text = $"Nivel Actual: {nombreModo}";
        txtHighScoreMenu.text = $"Récord Modo Infinito: {highScore} pts";
    }

    public void MostrarGameplay()
    {
        mainMenuPanel.SetActive(false);
        gameplayPanel.SetActive(true);
        levelCompletePanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    public void ActualizarHUD(int nivel, int puntos, int vidas, int metaCartas, int aciertosActuales)
    {
        if (nivel < 3)
        {
            txtNivelHUD.text = $"Nivel {nivel} ({aciertosActuales}/{metaCartas})";
            txtVidasHUD.gameObject.SetActive(false);
        }
        else
        {
            txtNivelHUD.text = "Nivel 3: Infinito";
            txtVidasHUD.gameObject.SetActive(true);
            txtVidasHUD.text = $"Vidas: {vidas}";
        }
        txtPuntosHUD.text = $"Puntos: {puntos}";
    }

    public void MostrarNivelCompletado()
    {
        levelCompletePanel.SetActive(true);
    }

    public void MostrarGameOver(int puntosLogrados, int recordTotal, bool nuevoRecord)
    {
        gameOverPanel.SetActive(true);
        txtPuntosFinales.text = $"Puntaje obtenido: {puntosLogrados}";
        txtRecordGameOver.text = nuevoRecord ? $"¡NUEVO RÉCORD: {recordTotal}!" : $"Mejor Récord: {recordTotal}";
    }
}
