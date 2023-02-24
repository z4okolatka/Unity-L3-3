using UnityEngine;

public class RopeHook : MonoBehaviour
{
    HingeJoint2D _joint;

    private void Start()
    {
        _joint = GetComponent<HingeJoint2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "RopePart Last" && !_joint.enabled)
        {
            _joint.connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();
            _joint.enabled = true;
            _joint.anchor = transform.InverseTransformPoint(collision.contacts[0].point);
        }
    }
}
