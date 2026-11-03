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
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvasPrincipal.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        // Si no fue destruida por una bandeja válida, regresa a su centro
        rectTransform.anchoredPosition = posicionInicial;
    }
}
