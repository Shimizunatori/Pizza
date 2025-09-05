using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _move;
    [SerializeField] private float _outTime;
    private float _moveTime;
    private bool _moveFlag = false;
    private Vector2 _movePosition;
    private int _clickCount;
    private float _clickTime;

    // Start is called before the first frame update
    void Start()
    {
        _moveTime = 0;
        _clickCount = 0;
        _clickTime = 0;
        _moveFlag = false;
        _movePosition = new Vector2(0, -3);
    }

    // Update is called once per frame
    void Update()
    {
        if (_moveTime <= _move && _moveFlag == false)
        {
            _moveTime += Time.deltaTime;
            _moveFlag = !_moveFlag;
        }
        if (_moveTime > _move && _moveFlag)
        {
            int i = Random.Range(-5, 6);
            _movePosition = new Vector2(i, -3);
            _moveTime = 0;
            _clickCount = i * i;
        }
        if (_moveFlag == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, _movePosition, _speed * Time.deltaTime);
            _clickTime += Time.deltaTime;
            if (_movePosition.x < 0)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    _clickCount--;
                }
            }
            if (_movePosition.x > 0)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    _clickCount--;
                }
            }
            if (_clickCount <= 0)
            {
                _movePosition = new Vector2(0, -3);
                _clickTime = 0;
                _moveFlag = !_moveFlag;
            }
            if (_clickTime >= _outTime)
            {
                // ゲームオーバー
                Debug.Log("GameOver");
            }
        }
    }
}
