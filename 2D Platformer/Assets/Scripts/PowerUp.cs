using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float minIncrease = 5f;
    public float maxIncrease = 10f;
    public float increase;

    public void Start()
    {
        increase = Random.Range(minIncrease, maxIncrease);
    }
}
