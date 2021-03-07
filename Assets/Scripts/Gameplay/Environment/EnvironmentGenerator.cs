using System.Collections.Generic;
using UnityEngine;
using System.Collections;


namespace Environments
{
    public class EnvironmentGenerator : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> _environmentPrefabs;

        [SerializeField]
        private float _distanceToEnvironmentDeactivation;

        private Queue<Environment> _disabledEnvironments;

        private Queue<Environment> _enabledEnviroments;

        [SerializeField]
        private int _enabledEnviromentCount;

        [SerializeField]
        private Environment _environmentActivatedLast;

        private Transform _transform;


        void Start()
        {
            _disabledEnvironments = new Queue<Environment>();
            _enabledEnviroments = new Queue<Environment>();
            _transform = GetComponent<Transform>();
            while (_environmentPrefabs.Count > 0)
            {
                int randomIndex = Random.Range(0, _environmentPrefabs.Count);
                var environment = Instantiate(_environmentPrefabs[randomIndex]).GetComponent<Environment>();
                environment.gameObject.SetActive(false);
                environment.DifferencePositionYBetweenObjectAndEnd = environment.EnvironmentTransform.position.y
                    - environment.EndOfEvironment.position.y;
                _environmentPrefabs.RemoveAt(randomIndex);
                _disabledEnvironments.Enqueue(environment);
                _disabledEnvironments.Peek().EnvironmentTransform = _disabledEnvironments.Peek().GetComponent<Transform>();
            }
            ActivationEnvironment();
            StartCoroutine(DistanceCheck());
        }


        void ActivationEnvironment()
        {
            
            if (_disabledEnvironments.Count == 0)
            {
                return;
            }
                
            int randomGetNum = Random.Range(0, 2);

            if (randomGetNum == 0)
            {
                var secondEnviroment = _disabledEnvironments.Dequeue();
                _environmentActivatedLast = _disabledEnvironments.Dequeue();
                _disabledEnvironments.Enqueue(secondEnviroment);

                
                _environmentActivatedLast.gameObject.SetActive(true);

                _enabledEnviroments.Enqueue(_environmentActivatedLast);
            }
            else
            {
                _environmentActivatedLast = _disabledEnvironments.Dequeue();
                _environmentActivatedLast.gameObject.SetActive(true);
                _enabledEnviroments.Enqueue(_environmentActivatedLast);
            }
            _environmentActivatedLast.EnvironmentTransform.position = new Vector2(_environmentActivatedLast.EnvironmentTransform.position.x,
                    _transform.position.y);
        }

        void DeactivationEnvironment()
        {
            if(_enabledEnviroments.Count==0)
            {
                return;
            }

            var environmentToDeactivation = _enabledEnviroments.Dequeue();
            environmentToDeactivation.gameObject.SetActive(false);
            _disabledEnvironments.Enqueue(environmentToDeactivation);
        }

        IEnumerator DistanceCheck()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.1f);

                if(_environmentActivatedLast.transform.position.y - _environmentActivatedLast.DifferencePositionYBetweenObjectAndEnd <
                    _transform.position.y)
                {
                    ActivationEnvironment();
                    if(_enabledEnviromentCount < _enabledEnviroments.Count)
                    {
                        DeactivationEnvironment();
                    }
                }
            }
        }

    }
}
