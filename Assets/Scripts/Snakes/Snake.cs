using CustomInput;
using Health;
using System.Collections.Generic;
using UnityEngine;

namespace Snakes
{
    [RequireComponent(typeof(CircleCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Snake : MonoBehaviour
    {
        [SerializeField] private Transform _head;
        [SerializeField] private Transform _bodyTilePrefab;
        [SerializeField] private Transform _TileContainer;
        [SerializeField] private Transform _camera;

        [SerializeField, Range(0.1f, 25f)] private float _speed;
        [SerializeField, Range(0, 25)] private int _startCountTile; 

        private List<Transform> _tiles = new List<Transform>();

        private BaseHeadMover _headMover;
        private BaseTilesMover _tileMover;

        private CircleCollider2D _circleCollider;
        private Rigidbody2D _rigidbody;

        private int _health;

        public IHealth Health;

        private void Awake()
        {
            _tiles.Add(Instantiate(_bodyTilePrefab, _head.position, _bodyTilePrefab.rotation, _TileContainer));

            for (int i = 1; i < _startCountTile; i++)
                TileAdd();

            _tileMover = new MathTileMover(_head, _tiles);
            _headMover = new RunningHeadMover(_head, new InputKeyboard(), _speed);

            Health = new BaseHeath(_startCountTile);
            _health = Health.Value;

            _circleCollider = GetComponent<CircleCollider2D>();
            _circleCollider.isTrigger = true;

            _rigidbody = GetComponent<Rigidbody2D>();
            _rigidbody.bodyType = RigidbodyType2D.Kinematic;
        }

        private void OnValidate()
        {
            if (_headMover != null)
                _headMover.SetSpeed(_speed);
        }

        private void OnEnable()
        {
            Health.Died += Die;
            Health.Changed += HealthChange;
        }

        private void OnDisable()
        {
            Health.Died -= Die;
            Health.Changed -= HealthChange;
        }

        private void Update()
        {
            _headMover.Move();
            _tileMover.Move();
        }

        private void HealthChange()
        {
            if (_health > Health.Value)
                TileDestroy();
            else
                TileAdd();

            _health = Health.Value;
        }

        private void TileDestroy()
        {
            if (_tiles.Count < 0)
                return;

            _head.position = _tiles[0].position;
            Destroy(_tiles[0].gameObject);
            _tiles.RemoveAt(0);
        }

        private void TileAdd()
        {
            _tiles.Add(Instantiate(_bodyTilePrefab, _tiles[_tiles.Count - 1].position, _bodyTilePrefab.rotation, _TileContainer));
        }

        private void Die()
        {
            print("GameOver");
        }
    }

}
