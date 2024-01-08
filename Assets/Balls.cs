using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balls : MonoBehaviour
{
    [SerializeField] private List<GameObject> balls = new List<GameObject>();
    public static Balls instance;
    private void Awake()
    {
        instance = this;
    }
    /*public void SpawnBalls()
    {
        if (Blade.instance != null)
        {
            List<Vector3> destroyedPositions = Blade.instance.RemoveSameColor();

            foreach (Vector3 position in destroyedPositions)
            {
                Instantiate(balls[Random.Range(0, balls.Count)], position, Quaternion.identity);
            }
        }
    }*/

}
