using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Events {

    public class EventDispatcher : MonoBehaviour {

        [SerializeField]
        private Event _someEvent;

        public void Dispatch() {
            _someEvent.Dispatch();
        }

    }
}

