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

        [SerializeField]
        private GameObject _playerCube;

        [SerializeField]
        private float _playerCubePositionX;

        private void Start()
        {
            _playerCubePositionX = _playerCube.transform.position.x;
        }

        private void OnEnable()
        {
            _fixedUpdateEventListner.ActionsToDo += BehaviourFixedUpdate;
        }

        private void OnDisable()
        {
            _fixedUpdateEventListner.ActionsToDo -= BehaviourFixedUpdate;
        }

        private void ChangePositionX(float positionX)
        {
            _playerCube.transform.position = new Vector3(positionX,_playerCube.transform.position.y);
        }

        public void ChangePlayerCubePositionToLeft()
        {
            if(!_playerSettings.PlayerPositionLeft)
            {
                ChangePositionX(-_playerCubePositionX);
                _playerSettings.PlayerPositionLeft = true;
            }
        }

        public void ChangePlayerCubePositionToRight()
        {
            if (_playerSettings.PlayerPositionLeft)
            {
                ChangePositionX(_playerCubePositionX);
                _playerSettings.PlayerPositionLeft = false;
            }
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

