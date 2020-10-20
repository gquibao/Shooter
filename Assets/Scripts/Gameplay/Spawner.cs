using UnityEngine;

namespace Gameplay
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private GameObject boxPrefab;
        private int _enemyCount;
        private int _boxCount;
        void Start()
        {
        
        }

        // private IEnumerator Spawn(GameObject prefab)
        // {
        //     
        // }
    }
}
