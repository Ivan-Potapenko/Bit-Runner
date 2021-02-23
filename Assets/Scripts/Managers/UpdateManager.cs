using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;

namespace Managers
{
    public class UpdateManager : MonoBehaviour
    {
        [SerializeField]
        private EventDispatcher updateEventDispatcher;

        [SerializeField]
        private EventDispatcher fixedUpdateEventDispatcher;

        void Update()
        {   
            updateEventDispatcher.Dispatch();
        }

        private void FixedUpdate()
        {
            fixedUpdateEventDispatcher.Dispatch();
        }
    }
}

