using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace KingOfMountain
{
    public class ScreenTouchDetector : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private float _startTouchPositionX;
        private float _endTouchPositionX;

        public event Action OnTap;
        public event Action OnSwipeLeft;
        public event Action OnSwipeRight;

        public void OnPointerDown(PointerEventData eventData)
        {
            _startTouchPositionX = eventData.position.x;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _endTouchPositionX = eventData.position.x;

            if (_startTouchPositionX < _endTouchPositionX)
                OnSwipeRight?.Invoke();

            else if (_startTouchPositionX > _endTouchPositionX)
                OnSwipeLeft?.Invoke();  

            else
                OnTap?.Invoke();
        }
    }
}