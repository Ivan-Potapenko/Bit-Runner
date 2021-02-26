using UnityEngine;
using Events;

namespace Player
{
    public class PlayerControl : MonoBehaviour
    {
        [SerializeField]
        private EventListener _updateEventListner;

        [SerializeField]
        private PlayerMove _playerMove;

        private void OnEnable()
        {
            _updateEventListner.ActionsToDo += BehaviourUpdate;
        }

        private void OnDisable()
        {
            _updateEventListner.ActionsToDo -= BehaviourUpdate;
        }

        void BehaviourUpdate()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if(Input.mousePosition.x>Screen.width/2)
                {
                    print("right");
                }
                if (Input.mousePosition.x <= Screen.width / 2)
                {
                    print("left ");
                }
            }
        }

    }

}
