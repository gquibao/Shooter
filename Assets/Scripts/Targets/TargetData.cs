using UnityEngine;

namespace Targets
{
    [CreateAssetMenu(menuName = "Shooter/TargetData", fileName = "TargetData", order = 1)]
    public class TargetData : ScriptableObject
    {
        public float life;
        public float damage;
    }
}
