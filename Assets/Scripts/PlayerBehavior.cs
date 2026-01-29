using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{   
    // For moving
    public float MoveSpeed = 10f;
    public float RotateSpeed = 75f;

    private float _vInput;
    private float _hInput;

    // For jumping
    public float JumpVelocity = 5f;
    private bool _isJumpung;

    // To limit jump (not make inifinite jumps)
    public float DistanceToGround = 0.1f;
    public LayerMask GroundLayer;
    private CapsuleCollider _col;

    // For shooting
    public GameObject Bullet;
    public float BulletSpeed = 100f;

    private bool _isShooting;

    private Rigidbody _rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // For managing the Health from Game Manager
    private GameBehavior _gameManager;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();

        _col = GetComponent<CapsuleCollider>();

        _gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        _vInput = Input.GetAxis("Vertical") * MoveSpeed;
        _hInput = Input.GetAxis("Horizontal") * RotateSpeed;

        // Moving without using rididbody
        //transform.Translate(_vInput * Time.deltaTime * Vector3.forward);
        //transform.Rotate(_hInput * Time.deltaTime * Vector3.up);

        // For Jumping
        _isJumpung |= Input.GetKeyDown(KeyCode.J);

        // For Shooting
        _isShooting |= Input.GetKeyDown(KeyCode.Space);
    }

    private void FixedUpdate()
    {
        // For moving
        Vector3 rotation = Vector3.up * _hInput;

        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        _rb.MovePosition(transform.position + (_vInput * Time.fixedDeltaTime * transform.forward));

        _rb.MoveRotation(_rb.rotation * angleRot);

        // For jumping
        if (IsGrounded() && _isJumpung)
        {
            _rb.AddForce(Vector3.up * JumpVelocity, ForceMode.Impulse);
        }
        _isJumpung = false;

        // For shooting
        if (_isShooting)
        {
            Vector3 spawnPos = transform.position + transform.forward * 1f;

            GameObject newBullet = Instantiate(
                Bullet,//Object
                spawnPos,//Position
                transform.rotation);//Rotation

            Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();

            bulletRB.linearVelocity = transform.forward * BulletSpeed;
        }

        _isShooting = false;
    }

    private bool IsGrounded()
    {
        // variable to store the position at the bottom of the player’s CapsuleCollider component
        Vector3 capsuleBottom = new(
            _col.bounds.center.x,
            _col.bounds.min.y,
            _col.bounds.center.z);

        bool grounded = Physics.CheckCapsule(
            _col.bounds.center,
            capsuleBottom,
            DistanceToGround,
            GroundLayer,
            QueryTriggerInteraction.Ignore
            );

        return grounded;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            _gameManager.HP -= 1;
            Debug.Log("Health gets lowered");
        }
    }
}
