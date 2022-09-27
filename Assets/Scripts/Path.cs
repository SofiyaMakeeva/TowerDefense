using UnityEngine;

public class Path : MonoBehaviour
{
    public static Path EnemyPath;

    private void Awake()
    {
        if (EnemyPath != null && EnemyPath != this)
        {
            Destroy(gameObject);
        }
        else
        {
            EnemyPath = this;
        }
    }
}
