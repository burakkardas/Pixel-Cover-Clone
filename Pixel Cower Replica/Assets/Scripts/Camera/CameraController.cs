using UnityEngine;
using Cinemachine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineMixingCamera _cinemachineMixingCamera;

    [SerializeField] private float _duration;
    private float _currentLerp01 = 0.5f;
    private float _currentLerp02 = 0f;




    public void SetCameraTransition(string value)
    {

        if (value == "Zoom")
        {
            DOTween.To(() => _currentLerp01, x => _currentLerp01 = x, 0, _duration)
            .OnUpdate(() =>
            {
                _cinemachineMixingCamera.m_Weight0 = _currentLerp01;
            });

            DOTween.To(() => _currentLerp02, x => _currentLerp02 = x, 0.5f, _duration)
            .OnUpdate(() =>
            {
                _cinemachineMixingCamera.m_Weight1 = _currentLerp02;
            });
        }
        else
        {
            DOTween.To(() => _currentLerp01, x => _currentLerp01 = x, 0.5f, _duration)
            .OnUpdate(() =>
            {
                _cinemachineMixingCamera.m_Weight0 = _currentLerp01;
            });

            DOTween.To(() => _currentLerp02, x => _currentLerp02 = x, 0, _duration)
            .OnUpdate(() =>
            {
                _cinemachineMixingCamera.m_Weight1 = _currentLerp02;
            });
        }

    }
}
