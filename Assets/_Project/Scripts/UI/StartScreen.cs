using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace KingOfMountain
{
    public class StartScreen : UIElement
    {
        private Button _startButton;
        private Animation _animation;

        [Inject]
        private void Construct(Button startButton, Animation animation)
        {
            _startButton = startButton;
            _animation = animation;
        }

        private void Start()
        {
            _startButton.onClick.AddListener(HandleStartButtonClick);
        }

        private void HandleStartButtonClick()
        {
            _startButton.gameObject.SetActive(false);

            _animation.Play();
        }

        // Called by AnimationEvent.
        private void HandleDisableAnimationEnd() => Deactivate();
    }
}