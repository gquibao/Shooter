using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private int _speed = 5;
        void Update()
        {
            var xAxis = Input.GetAxis("Horizontal");
            var yAxis = Input.GetAxis("Vertical");
            var movementDirection = new Vector2(xAxis, yAxis);
            transform.Translate(movementDirection * _speed * Time.deltaTime);
        }
    }
}
