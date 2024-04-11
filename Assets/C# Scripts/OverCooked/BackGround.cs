using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevLabirinth
{
    public class BackGround : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _sprite;
        private float _speed = 100.5f;
        private float _positionMinY;
        private Vector3 _restartPosition;
        // Update is called once per frame
        private void Start()
        {
            
        }
        private void Awake()
        {
            _restartPosition = transform.position;
            Debug.Log(_sprite.transform.position);
            _positionMinY = (_sprite.bounds.size.y * 2) - _restartPosition.y;
        }
        private void Update()
        {
            transform.Translate(Vector3.down * _speed * Time.deltaTime);
            if(transform.position.y <= -_positionMinY)
            {
                transform.position = _restartPosition;
            }
        }
    }
}

