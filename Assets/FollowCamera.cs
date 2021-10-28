using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // camera will follow this object
    public Transform target;

    //camera transform
    public Transform camTransform;

    // offset between camera and target
    public Vector3 offset;

    // change this value to get desired smoothness
    public float smoothTime = 0.3f;

    // This value will change at the runtime depending on target movement. Initialize with zero vector.
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    private void Start()
    {
        offset = camTransform.position - target.position;
    }

    // Update is called once per frame
    private void Update()
    {
        // update position
        var targetPosition = target.position + offset;
        camTransform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        // update rotation
        transform.LookAt(target);
    }
}