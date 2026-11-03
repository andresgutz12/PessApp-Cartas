using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Referencias a Managers")]
    [SerializeField] private GeneradorNivel generadorNivel;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private ComentariosManager comentariosManager;

    [Header("Configuración de Niveles")]
    [SerializeField] private int cartasParaGanarNivel1y2 = 5;
    [SerializeField] private int vidasInicialesNivel3 = 3;

    public int NivelActual { get; private set; }
    private int puntosActuales;
    private int aciertosEnNivel;
    private int vidasRestantes;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        VolverAlMenu();
    }

    public void VolverAlMenu()
    {
        generadorNivel.LimpiarTablero();
        NivelActual = EstadoJugador.ObtenerNivelGuardado();
        uiManager.MostrarMenuPrincipal(NivelActual, EstadoJugador.ObtenerHighScore());
    }

    public void IniciarPartida()
    {
        NivelActual = EstadoJugador.ObtenerNivelGuardado();
        puntosActuales = 0;
        aciertosEnNivel = 0;
        vidasRestantes = vidasInicialesNivel3;

        comentariosManager.OcultarDialogo();
        uiManager.MostrarGameplay();
        ActualizarInterfaz();

        generadorNivel.PrepararMazo(NivelActual);
        generadorNivel.GenerarSiguienteCarta(NivelActual);
    }

    public void ProcesarRespuesta(bool esCorrecto, string explicacion, bool pedirNuevaCarta)
    {
        comentariosManager.MostrarDialogo(esCorrecto, explicacion);

        if (esCorrecto)
        {
            puntosActuales += 10;
            aciertosEnNivel++;
        }
        else if (NivelActual == 3)
        {
            vidasRestantes--;
        }

        ActualizarInterfaz();

        // Validar fin de partida en Nivel 3 (Sin vidas)
        if (NivelActual == 3 && vidasRestantes <= 0)
        {
            bool esNuevoRecord = EstadoJugador.IntentarGuardarHighScore(puntosActuales);
            uiManager.MostrarGameOver(puntosActuales, EstadoJugador.ObtenerHighScore(), esNuevoRecord);
            return;
        }

        // Validar victoria en Niveles 1 y 2
        if (NivelActual < 3 && aciertosEnNivel >= cartasParaGanarNivel1y2)
        {
            EstadoJugador.GuardarNivel(NivelActual + 1);
            uiManager.MostrarNivelCompletado();
            return;
        }

        if (pedirNuevaCarta)
        {
            generadorNivel.GenerarSiguienteCarta(NivelActual);
        }
    }

    public void SiguienteNivel()
    {
        IniciarPartida(); // Carga automáticamente el nuevo nivel recién guardado en PlayerState
    }

    private void ActualizarInterfaz()
    {
        uiManager.ActualizarHUD(NivelActual, puntosActuales, vidasRestantes, cartasParaGanarNivel1y2, aciertosEnNivel);
    }
}
