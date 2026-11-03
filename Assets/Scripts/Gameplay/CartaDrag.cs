using UnityEngine;
using UnityEngine.EventSystems;

public class CartaDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Canvas canvasPrincipal;
    private Vector2 posicionInicial;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvasPrincipal = GetComponentInParent<Canvas>();

        if (canvasPrincipal == null)
        {
            canvasPrincipal = FindAnyObjectByType<Canvas>();
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        posicionInicial = rectTransform.anchoredPosition;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.85f;
        transform.SetAsLastSibling();

        Debug.Log($"[DRAG INICIO] Carta: {gameObject.name} | blocksRaycasts: {canvasGroup.blocksRaycasts}");
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvasPrincipal.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        string objetoDebajo = eventData.pointerCurrentRaycast.gameObject != null
        ? eventData.pointerCurrentRaycast.gameObject.name
        : "NINGUNO";

        Debug.Log($"[DRAG FIN] Soltada sobre: {objetoDebajo}");

        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        // Si no fue destruida por una bandeja válida, regresa a su centro
        rectTransform.anchoredPosition = posicionInicial;
    }
}
