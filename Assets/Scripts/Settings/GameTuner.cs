using UnityEngine;

public class GameTuner : MonoBehaviour
{
    private void Awake()
    {
        if (GameSaver.IsGameConfigured == false)
            GameSaver.SetDefaultSettings();
    }

    private void Start()
    {
        AudioListener.volume = GameSaver.Volume;
    }
}