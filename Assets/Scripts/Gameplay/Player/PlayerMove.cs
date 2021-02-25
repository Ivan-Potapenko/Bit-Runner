using UnityEngine;
using Events;

namespace Player
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField]
        private PlayerSettings _playerSettings;

        [SerializeField]
        private EventListener _fixedUpdateEventListner;

        [SerializeField]
        private Rigidbody2D _playerRigidbody;

        private void OnEnable()
        {
            _fixedUpdateEventListner.ActionsToDo += BehaviourFixedUpdate;
        }

        private void OnDisable()
        {
            _fixedUpdateEventListner.ActionsToDo -= BehaviourFixedUpdate;
        }

        private void BehaviourFixedUpdate()
        {
            if(_playerSettings.PlayerMove)
            {
                _playerRigidbody.MovePosition(transform.position + transform.up * Time.fixedDeltaTime * _playerSettings.PlayerSpeed);
            }
        }

    }
}

