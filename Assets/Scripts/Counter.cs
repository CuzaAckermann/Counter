using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay = 0.5f;
    [SerializeField] private int _valueChange = 1;

    private int _score = 0;
    private bool _isRunning = false;
    private Coroutine _coroutine;
    private WaitForSeconds _wait;

    public event Action<int> ScoreChanged;

    private void Start()
    {
        _wait = new WaitForSeconds(_delay);
    }

    private void Update()
    {
        IncreaseScore();
    }

    private void IncreaseScore()
    {
        if (Input.GetMouseButtonDown(0) && _isRunning == false)
        {
            _isRunning = !_isRunning;

            _coroutine = StartCoroutine(StartCounting());
        }
        else if (Input.GetMouseButtonDown(0) && _isRunning == true)
        {
            _isRunning = !_isRunning;

            if (_coroutine != null)
                StopCoroutine(_coroutine);
        }
    }

    private IEnumerator StartCounting()
    {
        while (_isRunning)
        {
            _score += _valueChange;
            ScoreChanged?.Invoke(_score);
            yield return _wait;
        }
    }
}