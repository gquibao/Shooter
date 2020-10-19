using System;
using TMPro;
using UnityEngine;

namespace Gameplay
{
    public class Hud : MonoBehaviour
    {
        [SerializeField] private TMP_Text ammoCount;

        public static Action<Tuple<int, int>> OnAmmoCountUpdated;

        private void Start()
        {
            OnAmmoCountUpdated += UpdateAmmoCount;
        }

        private void UpdateAmmoCount(Tuple<int, int> ammo)
        {
            ammoCount.text = $"{ammo.Item1}/{ammo.Item2}";
        } 
    }
}
