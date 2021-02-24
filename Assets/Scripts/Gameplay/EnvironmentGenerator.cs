using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;

namespace Environments
{
    public class EnvironmentGenerator : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> _environmentPrefabs;

        [SerializeField]
        private EventListener _updateEventListner;

        [SerializeField]
        private int _objectsCountInPool;

        [SerializeField]
        private int _distanceToEnvironmentDeactivation = 20;

        [SerializeField]
        private Queue<GameObject> _activeEnvironment;


        private List<GameObject> _inactiveEnvironment;
        private GameObject _endOfLastAddedEvironment;


        private void Start()
        {
            _inactiveEnvironment = new List<GameObject>();
            foreach (var prefab in _environmentPrefabs)
            {
                for (int i = 0; i < _objectsCountInPool; i++)
                {
                    var newEnvironment = Instantiate(prefab);
                    newEnvironment.SetActive(false);
                    _inactiveEnvironment.Add(newEnvironment);
                }
            }
            PutEnvironment();
        }

        private void PutEnvironment()
        {
            if(_activeEnvironment==null)
            {
                _activeEnvironment = new Queue<GameObject>();
            }
            int indexOfEnvironment = Random.Range(0, _inactiveEnvironment.Count);
            _endOfLastAddedEvironment = _inactiveEnvironment[indexOfEnvironment].GetComponent<Environment>().EndOfEvironment;

            var environment = _inactiveEnvironment[indexOfEnvironment];
            _inactiveEnvironment.RemoveAt(indexOfEnvironment);

            environment.SetActive(true);
            environment.transform.position = new Vector2(0, gameObject.transform.position.y);
            _activeEnvironment.Enqueue(environment);
        }

        private void OnEnable()
        {
            _updateEventListner.ActionsToDo += BehaviourUpdate;
        }

        private void OnDisable()
        {
            _updateEventListner.ActionsToDo -= BehaviourUpdate;
        }

        void DeactivationOfTheEnvironment()
        {
            var environment = _activeEnvironment.Dequeue();
            environment.SetActive(false);
            _inactiveEnvironment.Add(environment);
        }

        private void BehaviourUpdate()
        {
            if (_endOfLastAddedEvironment.transform.position.y < gameObject.transform.position.y)
            {
                PutEnvironment();
            }
            
            if ((_activeEnvironment.Peek().transform.position.y + _distanceToEnvironmentDeactivation) < gameObject.transform.position.y)
            {
                DeactivationOfTheEnvironment();
            }
        }
    }
}
