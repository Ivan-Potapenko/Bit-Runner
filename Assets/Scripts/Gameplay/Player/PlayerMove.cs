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
            //Test
            _playerSettings.PlayerMove = true;
            _playerSettings.PlayerPositionLeft = false;
            //Test
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

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Barrier")
            {
                _playerSettings.PlayerMove = false;
            }
        }


        public void ChangePositionX()
        {
            if (_playerSettings.PlayerPositionLeft)
            {
                _playerCube.transform.position = new Vector3(_playerCubePositionX, _playerCube.transform.position.y);
            }
            else
            {
                _playerCube.transform.position = new Vector3(-_playerCubePositionX, _playerCube.transform.position.y);
            }
            _playerSettings.PlayerPositionLeft = !_playerSettings.PlayerPositionLeft;

        }


        private void BehaviourFixedUpdate()
        {
            if (_playerSettings.PlayerMove)
            {
                _playerRigidbody.velocity = new Vector2(0, _playerSettings.PlayerSpeed);
            }
        }

    }
}

