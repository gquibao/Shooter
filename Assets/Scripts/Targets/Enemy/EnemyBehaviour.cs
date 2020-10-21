using System.Collections;
using System.Linq;
using UnityEngine;

namespace Targets.Enemy
{
    public class EnemyBehaviour : MonoBehaviour
    {
        [SerializeField] private LineRenderer lineRenderer;
        [SerializeField] private float speed = 3;
        [SerializeField] private EdgeCollider2D lineCollider;
        private Coroutine _wanderingCoroutine;
        private Coroutine _movementCoroutine;
        private Coroutine _attackingCoroutine;
        private void Start()
        {
            _wanderingCoroutine = StartCoroutine(Wandering(GetDirection()));
        }

        private Vector3 GetDirection()
        {
            var randomDirection = Vector3.zero;
            while (randomDirection == Vector3.zero)
            {
                var x = Random.Range(-1, 2);
                var y = Random.Range(-1, 2);
                randomDirection = Vector3.Normalize(new Vector3(x, y, 0));
            }
            return randomDirection;
        }

        private IEnumerator Fire(Vector2 playerCurrentPosition)
        {
            yield return new WaitForSeconds(1.5f);
            lineRenderer.SetPosition(1, playerCurrentPosition);
            ChangeEdgeColliderPoints(playerCurrentPosition);
            yield return new WaitForSeconds(2);
            lineRenderer.SetPosition(1, Vector2.zero);
            ChangeEdgeColliderPoints(Vector2.zero);
            _attackingCoroutine = null;
            _wanderingCoroutine = StartCoroutine(Wandering(GetDirection()));
        }

        private void Update()
        {
            if (_attackingCoroutine != null) return;
            var hits = Physics2D.CircleCastAll(transform.position, 5f, Vector2.right);
            var player = hits.ToList().Find(hit => hit.transform.CompareTag("Player"));
            if (player.transform == null) return;
            StopAllCoroutines();
            var direction = player.transform.position - transform.position;
            _attackingCoroutine = StartCoroutine(Fire(direction));
        }

        private void ChangeEdgeColliderPoints(Vector2 value)
        {
            var newPoints = new Vector2[2];
            newPoints[0] = Vector2.zero;
            newPoints[1] = value;
            lineCollider.points = newPoints;
        }

        private IEnumerator Move(Vector2 targetPosition)
        {
            while (true)
            {
                transform.Translate(targetPosition * speed * Time.deltaTime);
                yield return null;
            }
        }

        private IEnumerator Wandering(Vector2 targetPosition)
        {
            if (_movementCoroutine != null) StopCoroutine(_movementCoroutine);
            _movementCoroutine = StartCoroutine(Move(targetPosition));
            yield return new WaitForSeconds(5);
            _wanderingCoroutine = StartCoroutine(Wandering(GetDirection()));
        }
    }
}