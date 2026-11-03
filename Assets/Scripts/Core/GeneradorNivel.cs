using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GeneradorNivel : MonoBehaviour
{
    [SerializeField] private List<CardData> catalogoCompleto;
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private Transform cardSpawnPoint;

    private Queue<CardData> colaCartas = new Queue<CardData>();
    private GameObject cartaActualInstanciada;

    public void PrepararMazo(int nivel)
    {
        LimpiarTablero();
        colaCartas.Clear();

        // En el Nivel 2 filtramos solo cartas que tengan figura asignada
        IEnumerable<CardData> pool = (nivel == 2) &&  catalogoCompleto.Any(c => c.figura != null)
            ? catalogoCompleto.Where(c => c.figura != null)
            : catalogoCompleto;

        // Mezclamos usando LINQ
        foreach (var carta in pool.OrderBy(x => Random.value))
        {
            colaCartas.Enqueue(carta);
        }
    }

    public void GenerarSiguienteCarta(int nivel)
    {
        LimpiarTablero();

        // Si en el Modo Infinito (o por reintentos) se vacía la cola, volvemos a barajar el catálogo
        if (colaCartas.Count == 0)
        {
            PrepararMazo(nivel);
        }

        CardData siguiente = colaCartas.Dequeue();
        cartaActualInstanciada = Instantiate(cardPrefab, cardSpawnPoint);
        cartaActualInstanciada.GetComponent<CartaUI>().ConfigurarCarta(siguiente, nivel);
    }

    public void LimpiarTablero()
    {
        if (cartaActualInstanciada != null)
        {
            Destroy(cartaActualInstanciada);
        }
    }
}
