using UnityEngine;
using UnityEngine.Video;

public class CutScene : MonoBehaviour
{
    [SerializeField] private VideoPlayer _videoPlayer;

    private bool _loading;

    private float _timer;
    
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
