using UnityEngine;
using UnityEngine.UI;

public class UIGameplay : MonoBehaviour
{
    public int sceneIndex;

    public Button buttonResume;
    public Button buttonPause;
    public Button buttonMenu;

    void Start()
    {
        buttonMenu.onClick.AddListener(() => GameManager.Instance.ChangeScene(sceneIndex));
        buttonPause.onClick.AddListener(HandleButtonClick);
        buttonResume.onClick.AddListener(HandleButtonClick);
    }

    private void HandleButtonClick()
    {
        if (GameManager.Instance.isPaused)
        {
            GameManager.Instance.Resume();
            buttonPause.gameObject.SetActive(true);
            buttonResume.gameObject.SetActive(false);
        }
        else
        {
            GameManager.Instance.Pause();
            buttonPause.gameObject.SetActive(false);
            buttonResume.gameObject.SetActive(true);
        }
    }
}
