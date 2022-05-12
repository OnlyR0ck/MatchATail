using UnityEngine;
using UnityEngine.EventSystems;

public class DragNDropController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler,IDragHandler
{
    private Vector3 startPosition;
    private RectTransform rectTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        
        canvas = GameSceneDefs.Canvas;
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        startPosition = transform.position;
        canvasGroup.blocksRaycasts = false;
    }


    public void OnDrag(PointerEventData eventData) =>
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;

    
    public void OnPointerUp(PointerEventData eventData)
    {
        transform.position = startPosition;
        canvasGroup.blocksRaycasts = true;
    }
}


public static class ExtensionHelper
{
    public static Vector3 SetZ(this Vector3 vector, float z) => new Vector3(vector.x, vector.y, z);
}
