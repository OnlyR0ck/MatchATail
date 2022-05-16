using DG.Tweening;
using UnityEngine;

namespace UI
{
    public class YoyoMover : MonoBehaviour
    {
        [SerializeField] private float moveDistance;
        [SerializeField] private float duration;
        [SerializeField] private Vector2 moveDirection;


        private void Start()
        {
            moveDirection.Normalize();
            StartMove();
        }

        private void OnDisable() => transform.DOKill();

        public void StartMove()
        {
            transform.DOKill();
            transform.DOLocalMove(moveDirection * moveDistance, duration).SetLoops(-1, LoopType.Yoyo);
        }


        public void StopMove(bool forceComplete)
        {
            if (forceComplete)
            {
                transform.DOComplete();
            }

            transform.DOKill();
        }
    }
}
