using UnityEngine;
using TMPro;

[RequireComponent(typeof(Counter))]
[RequireComponent(typeof(TextMeshProUGUI))]

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshProUGUI _counterText;
    [SerializeField] private Animator _counterAnimator;
    [SerializeField] private AnimationClip _countAnimation;

    private void Awake()
    {
        _counter = GetComponent<Counter>();
        _counterText = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _counter.ScoreChanged += DisplayStopwatch;
    }

    private void OnDisable()
    {
        _counter.ScoreChanged -= DisplayStopwatch;
    }

    private void DisplayStopwatch(int score)
    {
        _counterAnimator.Play(_countAnimation.name);
        _counterText.text = score.ToString("");
    }
}