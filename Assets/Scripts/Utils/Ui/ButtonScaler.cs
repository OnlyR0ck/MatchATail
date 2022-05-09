using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;


public class ButtonScaler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    #region Fields

    [Header("Pointer Down")]
    [SerializeField] private AnimationCurve pointerDownEase;

    [SerializeField] private float pointerDownDuration = 0;
    [SerializeField] private Vector2 pointerDownScale = default;

    [Header("Pointer Up")]
    [SerializeField] private AnimationCurve pointerUpEase;

    [SerializeField] private float pointerUpDuration = 0;
    [SerializeField] private Vector2 pointerUpScale = default;

    #endregion



    #region Unity lifecycle

    private void OnDestroy() => transform.DOKill();

    #endregion



    #region IPointerDownHandler

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.DOKill();
        transform.DOScale(new Vector3(pointerDownScale.x, pointerDownScale.y, pointerDownScale.x),
            pointerDownDuration).SetEase(pointerDownEase).SetUpdate(true);
    }

    #endregion



    #region IPointerUpHandler

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.DOKill();
        transform.DOScale(new Vector3(pointerUpScale.x, pointerUpScale.y, pointerUpScale.x), pointerUpDuration)
            .SetEase(pointerUpEase).SetUpdate(true);;
    }

    #endregion



    #region IPointerExitHandler

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOKill();
        transform.DOScale(new Vector3(pointerUpScale.x, pointerUpScale.y, pointerUpScale.x), pointerUpDuration)
            .SetEase(pointerUpEase).SetUpdate(true);;
    }

    #endregion
}
