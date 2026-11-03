using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [Header("UI Reference")]
    public Image buttonImage;       // Componente Image del Botón
    public Sprite soundOnSprite;    // Icono con sonido
    public Sprite soundOffSprite;   // Icono muteado

    private bool isMuted = false;

    public void ToggleMute()
    {
        // Alternamos el estado booleano
        isMuted = !isMuted;

        // Silenciamos o activamos todo el audio del juego
        AudioListener.pause = isMuted;

        // Cambiamos el icono del botón si están asignados los sprites
        if (buttonImage != null)
        {
            if (isMuted && soundOffSprite != null)
            {
                buttonImage.sprite = soundOffSprite;
            }
            else if (!isMuted && soundOnSprite != null)
            {
                buttonImage.sprite = soundOnSprite;
            }
        }
    }
}