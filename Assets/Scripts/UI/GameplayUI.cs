using UnityEngine;
using UnityEngine.UI;

namespace UI {
    public class GameplayUI : MonoBehaviour {

        [SerializeField]
        private Button _pauseButton;

        [SerializeField]
        private UIManager _UIManager;

        private void OnEnable() {
            _pauseButton.onClick.AddListener(_UIManager.LoadGameplayScene);
        }

        private void OnDisable() {
            _pauseButton.onClick.RemoveListener(_UIManager.LoadGameplayScene);
        }

    }
}