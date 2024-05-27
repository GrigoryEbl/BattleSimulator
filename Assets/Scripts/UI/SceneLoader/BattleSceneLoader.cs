using UnityEngine;

public class BattleSceneLoader : SceneLoader
{
    protected override int GetSceneNumber()
    {
        return 3; //добавить выбор из сохраненного файла
    }
}