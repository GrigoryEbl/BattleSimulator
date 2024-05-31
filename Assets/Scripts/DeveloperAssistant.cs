using Lean.Localization;
using UnityEngine;
using YG;

public class DeveloperAssistant : MonoBehaviour
{
    [ContextMenu("SetEnglish")]
    public void SetEnglish() => LeanLocalization.SetCurrentLanguageAll("English");

    [ContextMenu("SetTurkish")]
    public void SetTurkish() => LeanLocalization.SetCurrentLanguageAll("Turkish");

    [ContextMenu("SetRussian")]
    public void SetRussian() => LeanLocalization.SetCurrentLanguageAll("Russian");

    [ContextMenu("Reset")]
    public void ResetProgress()
    {
        YandexGame.ResetSaveProgress();
        YandexGame.SaveProgress();
    }
}