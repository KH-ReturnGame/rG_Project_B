using UnityEngine;

public class Sprite_Spin : MonoBehaviour
{
    public float rotationSpeed = 1000f;

    void Update()
    {
        // Z축을 기준으로 회전
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
