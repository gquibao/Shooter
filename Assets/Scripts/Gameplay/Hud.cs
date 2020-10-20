using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Gameplay
{
    public class Hud : MonoBehaviour
    {
        [SerializeField] private TMP_Text ammoCount;
        [SerializeField] private TMP_Text gameplayScore;
        [SerializeField] private TMP_Text scoreDescription;
        [SerializeField] private TMP_Text finalScore;
        [SerializeField] private Image healthDisplay;
        [SerializeField] private GameObject gameOverMenu;
        [SerializeField] private Button restartButton;
        [SerializeField] private Button quitButton;

        public static Action<Tuple<int, int>> OnAmmoCountUpdated;
        public static Action<Tuple<float, float>> OnHealthCountUpdated;
        public static Action OnPointsAdded;
        public static Action OnGameOver;

        private void Start()
        {
            ammoCount.text = "0/0";
            gameplayScore.text = "0";
            scoreDescription.text = "0";
            finalScore.text = "0";
            restartButton.onClick.AddListener(() => SceneManager.LoadScene("GameplayScene"));
            quitButton.onClick.AddListener(Application.Quit);
            OnAmmoCountUpdated += UpdateAmmoCount;
            OnHealthCountUpdated += UpdateHealthCount;
            OnPointsAdded += UpdatePointsCount;
            OnGameOver += GameOver;
        }

        private void UpdateAmmoCount(Tuple<int, int> ammo)
        {
            ammoCount.text = $"{ammo.Item1}/{ammo.Item2}";
        }

        private void UpdateHealthCount(Tuple<float, float> health)
        {
            var fill = health.Item1 / health.Item2;
            healthDisplay.fillAmount = fill;
        }

        private void UpdatePointsCount()
        {
            gameplayScore.text = $"{GameManager.Points}";
        }

        private void GameOver()
        {
            GameManager.IsGameRunning = false;
            Cursor.visible = true;
            gameOverMenu.SetActive(true);
            ShowScore();
        }

        private void ShowScore()
        {
            scoreDescription.text = $"{GameManager.TimeInSeconds} seconds * {GameManager.Points} points";
            finalScore.text = $"{GameManager.TotalPoints}";
        }
    }
}
