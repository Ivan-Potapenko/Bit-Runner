using UnityEngine;
using UnityEngine.UI;

namespace UI {
    public class MenuUI : MonoBehaviour {

        [SerializeField]
        private Button _playButton;

        [SerializeField]
        private UIManager _UIManager;

        private void OnEnable() {
            _playButton.onClick.AddListener(_UIManager.LoadGameplayScene);
        }

        private void OnDisable() {
            _playButton.onClick.RemoveListener(_UIManager.LoadGameplayScene);
        }



    }
}