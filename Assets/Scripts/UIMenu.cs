using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    #region LevelInterface
    [SerializeField] private int levelCurrent;
    public Button[] levelButtons;

    void Start()
    {
        GameManager.Instance.CheckSaveFile();
        levelCurrent = GameManager.Instance.levelCurrent;
        Debug.Log("[UIMenu] levelCurrent from GameManager: " + levelCurrent);
        AddChangeSceneListeners();
        DisableLevel();
    }

    public int sceneIndex = 0;
    private void AddChangeSceneListeners()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            int sceneIndex = i + 1;
            levelButtons[i].onClick.AddListener(() => GameManager.Instance.ChangeScene(sceneIndex));
        }
    }

    public void DisableLevel()
    {
        Debug.Log("[UIMenu] DisableLevel running. levelCurrent = " + levelCurrent + ", button count = " + levelButtons.Length);
        for (int i = 0; i < levelButtons.Length; i++)
        {
            bool shouldEnable = i <= levelCurrent;
            Debug.Log("[UIMenu] Button " + i + ": i <= levelCurrent (" + i + " <= " + levelCurrent + ") = " + shouldEnable);
            levelButtons[i].interactable = shouldEnable;
        }
    }
    #endregion

    #region PanelManagement
    public GameObject startPanel;
    public GameObject levelPanel;
    public void ShowStartPanel()
    {
        startPanel.SetActive(true);
        levelPanel.SetActive(false);
    }
    public void ShowLevelPanel()
    {
        startPanel.SetActive(false);
        levelPanel.SetActive(true);
        GameManager.Instance.isStart = true;
    }

    public void OpenLevels()
    {
        if (GameManager.Instance == null)
        {
            Debug.LogError("UIMenu.OpenLevels: GameManager.Instance is null");
            return;
        }
        GameManager.Instance.OpenLevelsPanel();
    }

    private void CheckStartPanelExp()
    {
        if (isStart())
        {
            ShowLevelPanel();

        }
        else
        {
            ShowStartPanel();
        }
    }

    private bool isStart()
    {
        return GameManager.Instance.isStart;
    }
    #endregion
}
