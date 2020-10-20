using System.Collections;
using UnityEngine;

namespace Targets.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        private Coroutine _wanderingCoroutine;
        private void Start()
        {
            _wanderingCoroutine = StartCoroutine(Wandering(GetNewPosition()));
        }

        private IEnumerator Wandering(Vector2 targetPosition)
        {
            while (Vector2.Distance(transform.position, targetPosition) >= 1)
            {
                transform.Translate(targetPosition * 0.5f * Time.deltaTime);
                yield return null;
            }
            _wanderingCoroutine = StartCoroutine(Wandering(GetNewPosition()));
        }

        private Vector2 GetNewPosition()
        {
            var currentPosition = transform.position;
            var randomX = Random.Range(currentPosition.x - 10, currentPosition.x + 11);
            var randomY = Random.Range(currentPosition.x - 10, currentPosition.x + 11);
            return new Vector2(randomX, randomY);
        }
    }
}
