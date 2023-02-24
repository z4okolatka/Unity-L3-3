using UnityEngine;

public class RopeSwinger : MonoBehaviour
{
    [SerializeField] KeyCode Key;
    [SerializeField] private float velocityMultiplier = 1.001f;
    [SerializeField] private float maxVelocityX = 20f;
    [SerializeField] private float maxAngle = 30f;

    Rigidbody2D _rigidBody;
    Transform _transform;
    HingeJoint2D _joint;

    private bool isSwinging = false;
    private float boostAngle = 0.1f;
    private float boostSpeed = 5f;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
        _joint = GetComponent<HingeJoint2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(Key))
        {
            isSwinging = true;
        }

        bool isFalling = _rigidBody.velocity.y < 0;
        bool speedExceeded = Mathf.Abs(_rigidBody.velocity.x) > maxVelocityX;
        bool angleExceeded = Mathf.Abs(_transform.rotation.z) > maxAngle / 100;

        if (isSwinging && isFalling && !speedExceeded && _joint.enabled && !angleExceeded)
        {
            Swing();
        }

        if (Input.GetKeyUp(Key))
        {
            isSwinging = false;
        }
    }
    private void Swing()
    {
        float new_vx = Mathf.Abs(_rigidBody.velocity.x * velocityMultiplier);

        if (boostSpeed > new_vx && Mathf.Abs(_transform.rotation.z) <= boostAngle)
        {
            new_vx = boostSpeed;
        }

        _rigidBody.velocity = new Vector2(
             Mathf.Sign(_rigidBody.velocity.x) * new_vx,
            _rigidBody.velocity.y * velocityMultiplier);
    }
}
