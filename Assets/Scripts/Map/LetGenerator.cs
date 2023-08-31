using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map
{
    public class LetGenerator : MonoBehaviour
    {
        [SerializeField] private List<Transform> _spawmPoins = new List<Transform>();
        [SerializeField] private LetPool _pool;

        [SerializeField, Range(0.05f, 2f)] private float _coolDown;

        private WaitForSeconds _sleep;

        private void Awake()
        {
            _sleep = new WaitForSeconds(_coolDown);
            StartCoroutine(Generate());
        }

        private void OnValidate()
        {
            _sleep = new WaitForSeconds(_coolDown);
        }

        private IEnumerator Generate()
        {
            while (true)
            {
                Vector3 spawnPosotion = _spawmPoins[Random.Range(0, _spawmPoins.Count)].position;
                Let let = _pool.Get(spawnPosotion);
                yield return _sleep;
            }
        }
    }
}
