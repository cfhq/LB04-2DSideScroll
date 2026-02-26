using UnityEngine;
using UnityEngine.Events;

public enum TypeTag
{
    Player,
    Trap,
    Checkpoint,
    Finish,
    Trigger
}

public class EventTrrigger : MonoBehaviour
{
    public TypeTag targetTag;
    public UnityEvent<GameObject> onTrigger;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == targetTag.ToString())
        {
            Debug.Log(gameObject.tag + " collide with " + col.gameObject.tag);
            onTrigger.Invoke(col.gameObject);
        }
    }
}
