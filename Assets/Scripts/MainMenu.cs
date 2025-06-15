using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _creditsButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _controlsButton;
    
    [SerializeField] private GameObject _creditsPanel;
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private GameObject _controlsPanel;

    [SerializeField] private Button _backButton;
    [SerializeField] private Slider _volumeSlider;
    
    [SerializeField] private AudioClip _buttonSound;
    [SerializeField] private AudioClip _playSound;
    
    private void Awake()
    {
        _playButton.onClick.AddListener(OnPlayButtonClicked);
        _backButton.onClick.AddListener(() =>
        {
            HideAll();
            AudioManager.Instance.PlaySfxOneShot(_buttonSound, 0.7f);
        });
        _creditsButton.onClick.AddListener( () => ShowPanel(_creditsPanel));
        _settingsButton.onClick.AddListener( () => ShowPanel(_settingsPanel));
        _controlsButton.onClick.AddListener( () => ShowPanel(_controlsPanel));
        
    }

    private void Start()
    {
        _volumeSlider.onValueChanged.AddListener( (value) => AudioManager.Instance.SetMasterVolume(value));
        HideAll();
        _volumeSlider.value = AudioManager.Instance.MasterVol;
    }

    private void OnPlayButtonClicked()
    {
        AudioManager.Instance.PlaySfxOneShot(_playSound, 0.5f);
        SceneLoader.Instance.LoadScene(1);
    }

    private void HideAll()
    {
        _creditsPanel.SetActive(false);
        _settingsPanel.SetActive(false);
        _controlsPanel.SetActive(false);
        _backButton.gameObject.SetActive(false);
    }

    private void ShowPanel(GameObject panel)
    {
        AudioManager.Instance.PlaySfxOneShot(_buttonSound, 0.7f);
        HideAll();
        panel.SetActive(true);
        _backButton.gameObject.SetActive(true);
    }
}
