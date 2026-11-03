using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CartaUI : MonoBehaviour
{
    [HideInInspector] public CardData datosCarta;

    [Header("Referencias Visuales del Prefab")]
    [SerializeField] private Image imagenFondoCarta;
    [SerializeField] private TextMeshProUGUI textoPalabra;
    [SerializeField] private Image imagenFigura;

    public void ConfigurarCarta(CardData datos, int nivelActual)
    {
        datosCarta = datos;

        if (datos.fondoCarta != null && imagenFondoCarta != null)
        {
            imagenFondoCarta.sprite = datos.fondoCarta;
        }
        if (nivelActual == 1) 
        {
            MostrarSoloTexto(datos.palabra);
        }
        else if (nivelActual == 2)
        {

            bool usarFigura = (datos.figura != null) && (Random.value > 0.5f);
            if (usarFigura)
            {
                MostrarSoloFigura(datos.figura);
            }
            else
            {
                MostrarSoloTexto(QuitarTildes(datos.palabra.ToUpper()));
            }
        }
        else 
        {
            bool usarFigura = (datos.figura != null) && (Random.value > 0.5f);
            if (usarFigura)
            {
                MostrarSoloFigura(datos.figura);
            }
            else
            {
                MostrarSoloTexto(QuitarTildes(datos.palabra.ToUpper()));
            }
        }
    }

    private void MostrarSoloTexto(string texto)
    {
        textoPalabra.gameObject.SetActive(true);
        imagenFigura.gameObject.SetActive(false);
        textoPalabra.text = texto;
    }

    private void MostrarSoloFigura(Sprite sprite)
    {
        textoPalabra.gameObject.SetActive(false);
        imagenFigura.gameObject.SetActive(true);
        imagenFigura.sprite = sprite;
    }

    private string QuitarTildes(string texto)
    {
        return texto.Replace("Á", "A")
                    .Replace("É", "E")
                    .Replace("Í", "I")
                    .Replace("Ó", "O")
                    .Replace("Ú", "U");
    }
}
