using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    #region PanelManagement
    public bool isStart;

    public GameObject startPanel;
    public GameObject levelsPanel;

    public void OpenLevelsPanel()
    {
        if (startPanel == null || levelsPanel == null)
        {
            Debug.LogError("GameManager.OpenLevelsPanel: startPanel or levelsPanel is not assigned.");
            return;
        }

        startPanel.SetActive(false);
        levelsPanel.SetActive(true);
    }
    #endregion

    #region GameManager

    public static GameManager Instance;
    private void Awake()
    {
            Instance = this;
            DontDestroyOnLoad(gameObject);
    }

    # endregion

    # region SceneManagement
    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
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

    #region LevelManagemant
    LevelData levelData;
    public int levelCurrent;

    public void CheckSaveFile()
    {
        if (File.Exists(Application.dataPath + "/Level.json")) LoadLevel();
        else SaveLevel();
    }

    private void SaveLevel()
    {
        levelData = new LevelData();
        levelData.level = levelCurrent;
        string json = JsonUtility.ToJson(levelData, true);
        File.WriteAllText(Application.dataPath + "/Level.json", json);
    }

    private void LoadLevel()
    {
        string json;
        json = File.ReadAllText(Application.dataPath + "/Level.json");
        LevelData levelData = JsonUtility.FromJson<LevelData>(json);
        levelCurrent = levelData.level;
    }

    private void CheckLevel()
    {
        LoadLevel();
        levelCurrent = levelData.level;
    }

    public void ChangeLevel(int newLevelUnlocked)
    {
        newLevelUnlocked = levelCurrent + 1;
        levelCurrent = newLevelUnlocked;
        SaveLevel();
    }

    public void ResetLevel()
    {
        levelCurrent = 0;
        SaveLevel();
    }

    #endregion
}
