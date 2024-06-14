using UnityEngine;

public class BattleSceneLoader : SceneLoader
{
    protected override int GetSceneNumber()
    {
        return PlayerPrefs.GetInt(GameSaver.CurrentMap);
    }
}