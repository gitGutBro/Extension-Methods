using UnityEngine;
using UnityEngine.UI;

public class Bootstrap : MonoBehaviour
{
    [Header("Image Settings")]
    [SerializeField][Range(0.01f, 1f)] private float _changingStep;
    [SerializeField][Range(0f, 1f)] private float _targetAlpha;
    [SerializeField] private int _durationStepInMilliseconds;
    [SerializeField] private Image _image;
    [Space]
    [Header("Transform Settings")]
    [SerializeField][Range(0.01f, 1f)] private float _movingStep;
    [SerializeField] private Vector3 _targetPosition;
    [SerializeField] private GameObject _objectToMove;

    private async void Start()
    {
        float positionX = _objectToMove.transform.position.x;

        _image.ChangeAlphaAsync(_targetAlpha, _changingStep, _durationStepInMilliseconds);
        await _objectToMove.transform.MoveAsync(_targetPosition, _movingStep);

        _objectToMove.transform.SetX(positionX);
    }
}