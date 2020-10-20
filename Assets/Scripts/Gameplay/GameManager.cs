using System;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace Gameplay
{
    public class GameManager : MonoBehaviour
    {
        public static int Points;
        public static int TotalPoints;
        public static int TimeInSeconds;
        public static bool IsGameRunning;
        private void Start()
        {
            IsGameRunning = true;
            Points = 0;
            StartCoroutine(Timer());
        }
        private void OnDestroy()
        {
            IsGameRunning = false;
        }

        private IEnumerator Timer()
        {
            while (IsGameRunning)
            {
                TimeInSeconds++;
                yield return new WaitForSeconds(1);
            }
            TotalPoints = TimeInSeconds * Points;
        }

        public static void AddPoints(int pointsToAdd)
        {
            Points += pointsToAdd;
            Hud.OnPointsAdded.Invoke();
        }
    }
}
