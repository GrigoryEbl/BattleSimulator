using UnityEngine;

public class BattleSceneLoader : SceneLoader
{
    protected override int GetSceneNumber()
    {
        return GameSaver.CurrentMap;
    }
}