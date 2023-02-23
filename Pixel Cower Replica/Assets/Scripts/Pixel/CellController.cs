using UnityEngine;
using TMPro;
using DG.Tweening;

public class CellController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    [SerializeField] private Sprite _nonColorSprite;
    [SerializeField] private Sprite _colorSprite;


    public Color currentColor;

    [SerializeField] private TMP_Text _numberText;

    [SerializeField] private Vector3 _endScale;
    private Vector3 _currentScale;


    [SerializeField] private float _duration;
    [SerializeField] private float _endYValue;
    private float _currentYValue;
    public bool _isComplete;
    public int activeColor;


    private void Start()
    {
        _currentScale = transform.localScale;
        _currentYValue = transform.localPosition.y;
    }



    public void SetStartValues(int number)
    {
        _spriteRenderer.sprite = _nonColorSprite;
        _numberText.text = number.ToString();
    }


    [ContextMenu("Test")]
    public void PaintCell()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            _spriteRenderer.sprite = _colorSprite;
            _spriteRenderer.color = currentColor;
            _numberText.text = "";
            SetCellAnimation();
        }
    }



    private void SetCellAnimation()
    {
        transform.DOScale(_endScale, _duration);
        transform.DOLocalMoveY(_endYValue, _duration).OnComplete(() => OnComplete());
    }


    private void OnComplete()
    {
        transform.DOScale(_currentScale, _duration);
        transform.DOLocalMoveY(_currentYValue, _duration);
    }
}
