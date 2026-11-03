using UnityEngine;
using UnityEngine.EventSystems;

public class BandejaDrop : MonoBehaviour, IDropHandler
{
    public CategoriaGramatical categoriaBandeja;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null) return;

        CartaUI carta = eventData.pointerDrag.GetComponent<CartaUI>();
        if (carta != null)
        {
            bool acierto = (carta.datosCarta.categoria == categoriaBandeja);
            string explicacion = carta.datosCarta.explicacion;

            // En Nivel 3 destruimos la carta siempre para pasar a la siguiente;
            // En Nivel 1 y 2 solo la destruimos si acertó (si falla, regresa al centro para reintentar)
            if (acierto || GameManager.Instance.NivelActual == 3)
            {
                carta.gameObject.SetActive(false);
                Destroy(carta.gameObject);
                GameManager.Instance.ProcesarRespuesta(acierto, explicacion, true);
            }
            else
            {
                GameManager.Instance.ProcesarRespuesta(false, explicacion, false);
            }
        }
    }
}
