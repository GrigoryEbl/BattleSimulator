using UnityEngine;

internal class VolumeTuner : MonoBehaviour
{
    private void Awake()
    {
        if (!PlayerPrefs.HasKey(GameSaver.Volume))
            PlayerPrefs.SetFloat(GameSaver.Volume, AudioListener.volume);
    }

    private void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat(GameSaver.Volume);
    }
}