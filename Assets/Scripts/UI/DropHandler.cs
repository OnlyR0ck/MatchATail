using Game.Animals;
using Infrastructure;
using Infrastructure.ServicesHub;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class DropHandler : MonoBehaviour, IDropHandler
    {
        [SerializeField] private RectTransform rectTransform;
        private IGameFlowService gameFlowService;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            gameFlowService = ServicesHub.Container.Single<IGameFlowService>();
        }

        public void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawCube(rectTransform.position, rectTransform.sizeDelta);
        }

        public void OnDrop(PointerEventData eventData)
        {
            GameObject droppedItem = eventData.pointerDrag;
            if (droppedItem == null)
            {
                return;
            }

            TailController tailController = droppedItem.GetComponent<TailController>();
            gameFlowService.TailWasChosen(tailController.AnimalType);
        }
    }
}
