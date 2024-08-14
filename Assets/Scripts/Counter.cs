using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private float _delay = 0.5f;
    [SerializeField] private int _valueChange = 1;

    private int _score = 0;

    private bool _isRunning = false;

    private WaitForSeconds _wait;

    public event Action<int> ScoreChanged;

    private void IncreaseScore()
    {
        if (_isRunning == false)
        {
            _isRunning = true;

            StartCoroutine(StartCounting());
        }
        else
        {
            _isRunning = false;

            StopCoroutine(StartCounting());
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

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void Start()
    {
        _wait = new WaitForSeconds(_delay);
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(IncreaseScore);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(IncreaseScore);
    }
}