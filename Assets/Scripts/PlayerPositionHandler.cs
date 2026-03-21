using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class PlayerPositionHandler : MonoBehaviour
{
    Vector2 playerCurrentPos;
    Vector2 currentCheckpointPos;

    #region Condition
    public void OnCheckpoint(GameObject col)
    {
        Vector2 newCheckpointPosition = col.transform.position;
        currentCheckpointPos = newCheckpointPosition;
        SavePosition(newCheckpointPosition);
    }

    public void OnEnemy()
    {
        ChangePlayerPos(currentCheckpointPos);
    }

    public void OnFinish(int newLevelUnlocked)
    {
        GameManager.Instance.ChangeLevel(newLevelUnlocked);
        GameManager.Instance.ChangeScene(0);
    }

    #endregion

    #region SaveLoad
    public TransformData playerPositionData;

    public void LoadPosition()
    {
        transform.position = playerPositionData.position;
    }

    public void SavePosition(Vector2 newPosition)
    {
        playerPositionData.position = newPosition;
    }
    #endregion

    #region Instruction

    private void ChangePlayerPos(Vector2 newPosition)
    {
        transform.position = newPosition;
    }

    #endregion
}
