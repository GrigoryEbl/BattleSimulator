using UnityEngine;
using YG;

internal class VolumeTuner : MonoBehaviour
{
    private void Start()
    {
        AudioListener.volume = YandexGame.savesData.Volume;
    }
}