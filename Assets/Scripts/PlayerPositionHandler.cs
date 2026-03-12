using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class PlayerPositionHandler : MonoBehaviour
{

    #region Condition
    Vector2 playerCurrentPos;
    Vector2 currentCheckpointPos;

    public void OnCheckpoint(GameObject col) // col : checkpoint yg mau diambil
    {
        //Debug.Log("col itu adalah : " +  col.transform.position);
        Vector2 newCheckpointPosition = col.transform.position;
        currentCheckpointPos = newCheckpointPosition;
        SavePosition(newCheckpointPosition);
    }

    public void OnEnemy()
    {
        //Debug.Log("curr posss");
        ChangePlayerPos(currentCheckpointPos);
    }

    public void OnFinish(int newLevelUnlocked)
    {
        GameManager.Instance.ChangeScene(0);
        GameManager.Instance.ChangeLevel(newLevelUnlocked);
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
