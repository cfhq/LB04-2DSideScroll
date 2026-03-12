using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    # region GameManager

    public static GameManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //public void GameManagerCheck()
    //{
    //    Debug.Log("GameManag is working!");
    //}

    # endregion

    # region SceneManagement
    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    # endregion

    # region PauseManagement
    public bool isPaused;

    public void Pause()
    {
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        isPaused = false;
    }
    #endregion

    #region LevelManagement

    public int levelCurrent;

    public void CheckSaveFile()
    {
        if (File.Exists(Application.dataPath + "/Level.json"))
        {
            LoadLevel();
        }
        else
        {
            levelCurrent = 0;
            LoadLevel();
        }
    }
    private void SaveLevel()
    {
        LevelData levelData = new LevelData();
        levelData.Level = levelCurrent;
        string json = JsonUtility.ToJson(levelData);
        File.WriteAllText(Application.dataPath + "/Level.json", json);
    }

    private void LoadLevel()
    {
        string json;
        json = File.ReadAllText(Application.dataPath + "/Level.json");
        LevelData levelData = new LevelData();
        levelCurrent = levelData.Level;
    }

    public void CheckLevel()
    {
        LoadLevel();
    }

    public void ChangeLevel(int newLevelUnlocked)
    {
        levelCurrent = newLevelUnlocked;
        SaveLevel();
    }
    # endregion
}
