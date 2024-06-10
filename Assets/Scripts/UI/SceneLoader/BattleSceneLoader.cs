using YG;

public class BattleSceneLoader : SceneLoader
{
    protected override int GetSceneNumber()
    {
        return YandexGame.savesData.CurrentMap;
    }
}