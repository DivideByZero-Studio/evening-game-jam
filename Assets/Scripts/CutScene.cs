using UnityEngine;
using UnityEngine.Video;

public class CutScene : MonoBehaviour
{
    [SerializeField] private VideoPlayer _videoPlayer;

    private bool _loading;

    private float _timer;

    private void Start()
    {
        _videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "CutScene.mp4");
        _videoPlayer.Play();
        _videoPlayer.SetDirectAudioVolume(0, 0.75f * AudioManager.Instance.MasterVol);
    }
    
    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= 30 && _loading == false)
        {
            _loading = true;
            SceneLoader.Instance.LoadScene(2);
        } 
    }
}
