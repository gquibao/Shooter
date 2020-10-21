using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Gameplay
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private GameObject boxPrefab;
        private readonly List<Vector2> _directions = new List<Vector2>() {Vector2.down, Vector2.left, Vector2.right, Vector2.up};
        private PlayerStatus _player;
        void Start()
        {
            _player = FindObjectOfType<PlayerStatus>();
            StartCoroutine(Spawn(enemyPrefab, 10));
            StartCoroutine(Spawn(boxPrefab, 20));
        }

        private IEnumerator Spawn(GameObject prefab, int waitTime)
        {
            _directions.ForEach(direction =>
            {
                var position = direction * 20;
                var playerPosition = _player.transform.position;
                var player2d = new Vector2(playerPosition.x, playerPosition.y);
                Instantiate(prefab, position + player2d, Quaternion.identity);
            });
            yield return new WaitForSeconds(waitTime);
            StartCoroutine(Spawn(prefab, waitTime));
        }
    }
}
