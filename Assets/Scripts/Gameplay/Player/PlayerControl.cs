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



        private void BehaviourUpdate()
        {
#if DEBUG
            if (Input.GetMouseButtonDown(0))
            {
                _playerMove.ChangePositionX();
            }

#else
            if ( Input.touchCount>0)
            {
                for(int i = 0; i< Input .touchCount;i++)
                {
                    if(Input.touches[i].phase==TouchPhase.Began)
                    {
                        _playerMove.ChangePositionX();
                    }
                }
            }
#endif
        }
    }

}
