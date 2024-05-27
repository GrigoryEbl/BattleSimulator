using Lean.Localization;
using UnityEngine;

public class DeveloperAssistant : MonoBehaviour
{
    [ContextMenu("SetEnglish")]
    public void SetEnglish() => LeanLocalization.SetCurrentLanguageAll("English");

    [ContextMenu("SetTurkish")]
    public void SetTurkish() => LeanLocalization.SetCurrentLanguageAll("Turkish");

    [ContextMenu("SetRussian")]
    public void SetRussian() => LeanLocalization.SetCurrentLanguageAll("Russian");
}