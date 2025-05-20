using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followSpeed = 4f;
    public float y0ffset = 1f;
    public float x0ffset = 1f;
    public Transform target; // will return the position of the player
   
    void Update()
    {
       Vector3 newPos = new Vector3(target.position.x + x0ffset, target.position.y + y0ffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
    }
}
