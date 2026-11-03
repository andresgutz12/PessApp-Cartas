using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TemporizadorInstrucciones : MonoBehaviour
{
    [Header("Configuración")]
    public float tiempoDeEspera = 8f; // Los 8 segundos que pediste
    public string nombreEscenaJuego = "Juego"; // Cambia esto por el nombre exacto de tu escena de nivel

    void Start()
    {
        // Inicia la cuenta regresiva automáticamente al entrar a la escena
        StartCoroutine(EsperarYCambiar());
    }

    IEnumerator EsperarYCambiar()
    {
        // Espera los segundos indicados
        yield return new WaitForSeconds(tiempoDeEspera);

        // Cambia de escena
        SceneManager.LoadScene(nombreEscenaJuego);
    }
}