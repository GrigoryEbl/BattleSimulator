using PlayerPrefs = Agava.YandexGames.Utility.PlayerPrefs;

public static class GameSaver
{
    private static class Names
    {
        public static readonly string Level = "Level";
        public static readonly string Map = "Map";

        public static readonly string Settings = "Settings";
        public static readonly string Volume = "Volume";

        public static readonly string Money = "Money";
        public static readonly string Score = "Score";
    }

    private static readonly int _levelStep = 1;
    private static readonly float _maxVolume = 1f;
    private static readonly string _startBuilding = "SoldierHouse";

    public static int Money => PlayerPrefs.GetInt(Names.Money);
    public static int Score => PlayerPrefs.GetInt(Names.Score);
    public static int CurrentMap => PlayerPrefs.GetInt(Names.Map);
    public static int CurrentLevel => PlayerPrefs.GetInt(Names.Level);
    public static float Volume => PlayerPrefs.GetFloat(Names.Volume);
    public static bool IsGameConfigured => PlayerPrefs.HasKey(Names.Settings);

    public static bool HasBuilding(string name)
    {
        return PlayerPrefs.HasKey(name);
    }

    public static void SaveBuilding(string name)
    {
        PlayerPrefs.SetString(name, true.ToString());
        PlayerPrefs.Save();
    }

    public static void SetMoney(int value)
    {
        PlayerPrefs.SetInt(Names.Money, value);
        PlayerPrefs.Save();
    }

    public static void SetScore(int addedValue)
    {
        int score = PlayerPrefs.GetInt(Names.Score) + addedValue;

        PlayerPrefs.SetInt(Names.Score, score);
        PlayerPrefs.Save();
    }

    public static void SetVolume(float value)
    {
        PlayerPrefs.SetFloat(Names.Volume, value);
        PlayerPrefs.Save();
    }

    public static void SetMap(int mapNumber)
    {
        PlayerPrefs.SetInt(Names.Map, mapNumber);
        PlayerPrefs.Save();
    }

    public static void SetLevel(int levelNumber)
    {
        PlayerPrefs.SetInt(Names.Level, levelNumber);
        PlayerPrefs.Save();
    }

    public static void SetNextLevel(int levelsCount)
    {
        if (CurrentMap == (int)SceneNames.LevelChoiceScene)
            return;

        if (CurrentLevel == levelsCount)
            ChangeMap();
        else
            PlayerPrefs.SetInt(Names.Level, CurrentLevel + _levelStep);

        PlayerPrefs.Save();
    }

    public static void SetDefaultSettings()
    {
        PlayerPrefs.DeleteAll();

        PlayerPrefs.SetInt(Names.Level, _levelStep);
        PlayerPrefs.SetInt(Names.Map, (int)SceneNames.Forest);
        PlayerPrefs.SetFloat(Names.Volume, _maxVolume);
        PlayerPrefs.SetString(_startBuilding, true.ToString());
        PlayerPrefs.SetString(Names.Settings, true.ToString());

        PlayerPrefs.Save();
    }

    private static void ChangeMap()
    {
        PlayerPrefs.SetInt(Names.Level, _levelStep);
        PlayerPrefs.SetInt(Names.Map, CurrentMap + _levelStep);
    }
}