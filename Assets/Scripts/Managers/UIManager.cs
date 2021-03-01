using UnityEngine;
using UnityEngine.SceneManagement;


namespace UI {
    public class UIManager : MonoBehaviour {
        public static UIManager Instance;

        private void Awake() {
            if (Instance != null) {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void LoadGameplayScene() {
            SceneManager.LoadScene("Gameplay");
        }
        
        public void LoadMenuScene() {
            SceneManager.LoadScene("Menu");
        }

    }

}
