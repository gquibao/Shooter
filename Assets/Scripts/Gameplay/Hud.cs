using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    public class Hud : MonoBehaviour
    {
        [SerializeField] private TMP_Text ammoCount;
        [SerializeField] private Image healthDisplay;
        [SerializeField] private GameObject gameOverMenu;

        public static Action<Tuple<int, int>> OnAmmoCountUpdated;
        public static Action<Tuple<float, float>> OnHealthCountUpdated;
        public static Action OnGameOver;

        private void Start()
        {
            OnAmmoCountUpdated += UpdateAmmoCount;
            OnHealthCountUpdated += UpdateHealthCount;
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

        private void GameOver()
        {
            Cursor.visible = true;
            gameOverMenu.SetActive(true);
        }
    }
}
