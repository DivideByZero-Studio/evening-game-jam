using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController Instance => _instance;

    private static UIController _instance;
    
    [SerializeField] private Image _leftHand;
    [SerializeField] private Image _rightHand;
    [SerializeField] private Image _occlusion;
    
    [SerializeField] private float _animationDuration;
    
    private RectTransform _rectTransform; 
    
    private Vector3 _leftHandDefaultPosition;
    private Vector3 _rightHandDefaultPosition;
    
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        _rectTransform = GetComponent<RectTransform>();
        
        _leftHandDefaultPosition = _leftHand.rectTransform.position;
        _rightHandDefaultPosition = _rightHand.rectTransform.position;
    }

    public void CloseEyes()
    {
        _leftHand.rectTransform.DOKill();
        _rightHand.rectTransform.DOKill();
        _occlusion.DOKill();
        
        _occlusion.DOFade(0.85f, _animationDuration).SetEase(Ease.Linear);
        _leftHand.rectTransform.DOMove(_rectTransform.position, _animationDuration, true).SetEase(Ease.InOutQuad);
        _rightHand.rectTransform.DOMove(_rectTransform.position, _animationDuration, true).SetEase(Ease.InOutQuad);
    }

    public void OpenEyes()
    {
        _leftHand.rectTransform.DOKill();
        _rightHand.rectTransform.DOKill();
        _occlusion.DOKill();
        
        _occlusion.DOFade(0, _animationDuration).SetEase(Ease.Linear);
        _leftHand.rectTransform.DOMove(_leftHandDefaultPosition, _animationDuration, true).SetEase(Ease.InOutQuad);
        _rightHand.rectTransform.DOMove(_rightHandDefaultPosition, _animationDuration, true).SetEase(Ease.InOutQuad);
    }

    public void HideScreen()
    {
        _occlusion.DOKill();
        _occlusion.DOFade(1, 3).SetEase(Ease.Linear);
    }
}
