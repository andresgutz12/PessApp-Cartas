using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // Necesario para la espera de los segundos

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject mainMenu;

    [Header("Instrucciones")]
    public GameObject panelInstrucciones; // Arrastra aquí tu panel o sprite de instrucciones
    public float tiempoDeEspera = 8f;     // Los 8 segundos que pediste

    public void OpenOptionsPanel()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void OpenMainPanel()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // Modificamos esta función para que muestre el panel y espere antes de cargar
    public void PlayGame()
    {
        // 1. Ocultamos el menú principal por si acaso
        if (mainMenu != null)
            mainMenu.SetActive(false);

        // 2. Mostramos el panel de instrucciones
        if (panelInstrucciones != null)
        {
            panelInstrucciones.SetActive(true);
        }

        // 3. Iniciamos la cuenta regresiva para cambiar a la escena "Nivel"
        StartCoroutine(EsperarYComenzarJuego());
    }

    IEnumerator EsperarYComenzarJuego()
    {
        // Espera los 8 segundos
        yield return new WaitForSeconds(tiempoDeEspera);

        // Carga la escena del nivel
        SceneManager.LoadScene("Nivel");
    }
}