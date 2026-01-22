using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public Vector3 CamOffset = new(0, 1.2f, -2.6f);

    [SerializeField]
    private Transform _target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //_target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (_target != null)
        {
            transform.position = _target.TransformPoint(CamOffset);
            transform.LookAt(_target);
        }
        
    }
}
