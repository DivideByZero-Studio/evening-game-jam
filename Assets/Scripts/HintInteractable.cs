using DG.Tweening;
using UnityEngine;

public class HintInteractable : MonoBehaviour
{
    [SerializeField] private ParticleSystem onDestroyParticles;
    [SerializeField] private CanvasGroup canvasGroup;

    private Tween _currentTween;
    
    private void Awake()
    {
        canvasGroup.alpha = 0;
    }

    public void Show()
    {
        _currentTween.Kill();
        _currentTween = canvasGroup.DOFade(1f, 0.4f);
    }

    public void Hide()
    {
        _currentTween.Kill();
        _currentTween = canvasGroup.DOFade(0f, 0.4f);
    }

    public void HideWithParticles()
    {
        _currentTween.Kill();
        canvasGroup.DOFade(0f, 0.2f);
        onDestroyParticles.Play();
    }
}
