using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Button quitButton;

        private void Start()
        {
            startButton.onClick.AddListener(() => SceneManager.LoadScene("GameplayScene"));
            quitButton.onClick.AddListener(Application.Quit);
        }
    }
}
