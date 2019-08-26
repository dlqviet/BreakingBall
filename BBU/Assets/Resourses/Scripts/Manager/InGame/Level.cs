using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class LevelProperty
{
}
[System.Serializable]
public class NormalLevelProperty : LevelProperty
{
    private LevelManager levelManager;

    public int numberOfPlatformDestroy;
    public List<SubLevel> subLevels;
}
[System.Serializable]
public class BossLevelProperty : LevelProperty
{
    public GameObject boss;
}

[System.Serializable]
public class LevelPropertyFactory
{
    public enum LevelPropertyType
    {
        NormalLevelProperty,
        BossLevelProperty,
    }
    public LevelPropertyType Type = LevelPropertyType.NormalLevelProperty;

    public NormalLevelProperty NormalLevelProperty = new NormalLevelProperty();
    public BossLevelProperty BossLevelProperty = new BossLevelProperty();

    public LevelProperty CreateLevelProperty()
    {
        return GetLevelPropertyFromType(Type);
    }

    public System.Type GetClassType(LevelPropertyType levelPropertyType)
    {
        return GetLevelPropertyFromType(levelPropertyType).GetType();
    }

    private LevelProperty GetLevelPropertyFromType(LevelPropertyType type)
    {
        switch (type)
        {
            case LevelPropertyType.NormalLevelProperty:
                return NormalLevelProperty;
            case LevelPropertyType.BossLevelProperty:
                return BossLevelProperty;
            default:
                return NormalLevelProperty;
        }
    }
}

public class Level : MonoBehaviour
{
    public LevelPropertyFactory LevelType;

    private LevelProperty m_levelType = null;
    private void Awake()
    {
        m_levelType = LevelType.CreateLevelProperty();
    }
}
