using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompletionData : MonoBehaviour
{
    public static LevelCompletionData instance;

    [System.Serializable]
    public struct LevelData
    {
        public bool completed;
        public bool haveGold;
        public float bestTime;
    }

    [System.Serializable]
    public struct SecretLevelData
    {
        public bool unlocked;
        public bool completed;
        public bool haveGold;
        public float bestTime;
    }

    [System.Serializable]
    public struct LevelDataArray
    {
        public LevelData[] levelData;
        public SecretLevelData[] secretLevelData;
        public bool[] secrets;
    }

    public LevelDataArray levelData;
    public Level[] levels;
    public Level[] secretLevels;
    public LevelList levelList;
    public int winScene;

    public bool specialMode = false;

    private void Start()
    {
        levels = levelList.levels;
        secretLevels = levelList.secretLevels;
        winScene = levelList.winScene;
        LoadData();
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void LevelComplete()
    {
        int levelNumber = levels.TakeWhile(l => !(l.buildIndex == SceneManager.GetActiveScene().buildIndex)).Count();
        Timer timer = GameObject.Find("Timer").GetComponent<Timer>();
        if(levelNumber == levels.Length)
        {
            int secretLevelNumber = secretLevels.TakeWhile(l => !(l.buildIndex == SceneManager.GetActiveScene().buildIndex)).Count();
            if(secretLevelNumber == secretLevels.Length) return;

            levelData.secretLevelData[secretLevelNumber].completed = true;
            if(levelData.secretLevelData[secretLevelNumber].bestTime > timer.elapsed) levelData.secretLevelData[secretLevelNumber].bestTime = timer.elapsed;

            if(timer.gold)
            {
                levelData.secretLevelData[secretLevelNumber].haveGold = true;
            }
            return;
        }
        levelData.levelData[levelNumber].completed = true;
        if(levelData.levelData[levelNumber].bestTime > timer.elapsed) levelData.levelData[levelNumber].bestTime = timer.elapsed;

        if(timer.gold)
        {
            levelData.levelData[levelNumber].haveGold = true;
        }
    }

    public void SaveData()
    {
        PlayerPrefs.SetString("LevelCompletionData", JsonUtility.ToJson(levelData));
        PlayerPrefs.Save();
    }

    public void LoadData()
    {
        if(PlayerPrefs.HasKey("LevelCompletionData"))
        {
            levelData = JsonUtility.FromJson<LevelDataArray>(PlayerPrefs.GetString("LevelCompletionData"));

            if(levelData.secrets == null)
            {
                levelData.secrets = new bool[20];
            }
        }
        else
        {
            levelData.levelData = new LevelData[levels.Length];
            for(int i = 0; i < levelData.levelData.Length; ++i)
            {
                levelData.levelData[i].completed = false;
                levelData.levelData[i].haveGold = false;
                levelData.levelData[i].bestTime = Mathf.Infinity;
            }
            levelData.secretLevelData = new SecretLevelData[secretLevels.Length];
            for(int i = 0; i < levelData.secretLevelData.Length; ++i)
            {
                levelData.secretLevelData[i].unlocked = false;
                levelData.secretLevelData[i].completed = false;
                levelData.secretLevelData[i].haveGold = false;
                levelData.secretLevelData[i].bestTime = Mathf.Infinity;
            }
            levelData.secrets = new bool[20];
            SaveData();
        }
    }

    public void ToggleSpecialMode()
    {
        specialMode = !specialMode;
    }

    public void ClearData()
    {
        PlayerPrefs.DeleteKey("LevelCompletionData");
    }
}
