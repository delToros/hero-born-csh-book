using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float MoveSpeed = 10f;
    public float RotateSpeed = 75f;

    private float _vInput;
    private float _hInput;

    private Rigidbody _rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _vInput = Input.GetAxis("Vertical") * MoveSpeed;
        _hInput = Input.GetAxis("Horizontal") * RotateSpeed;

        //transform.Translate(_vInput * Time.deltaTime * Vector3.forward);
        //transform.Rotate(_hInput * Time.deltaTime * Vector3.up);
    }

    private void FixedUpdate()
    {
        Vector3 rotation = Vector3.up * _hInput;

        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        _rb.MovePosition(transform.position + (_vInput * Time.fixedDeltaTime * transform.forward));

        _rb.MoveRotation(_rb.rotation * angleRot);
    }
}
