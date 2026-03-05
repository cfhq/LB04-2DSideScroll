using UnityEngine;

[CreateAssetMenu(fileName = "TransformData", menuName = "Scriptable Objects/TransformData")]
public class TransformData : ScriptableObject
{
    public Vector2 position; // pos x & y
    // Vector3 position; --> pos x, y & z (ga ngaruh karena cuma mau ngambil x & y)
    
    public void ResetData()
    {
        position = Vector2.zero;
    }
}
