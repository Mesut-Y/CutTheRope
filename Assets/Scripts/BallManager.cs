using UnityEngine;

public class BallManager : MonoBehaviour
{
    public float distanceWithChain = 0.2f;
    public void TieLastChain(Rigidbody2D lastLink)
    {
        HingeJoint2D joint = gameObject.AddComponent<HingeJoint2D>();
        joint.autoConfigureConnectedAnchor = false;
        joint.connectedBody = lastLink;
        joint.anchor = Vector2.zero;
        joint.connectedAnchor = new Vector2(0f, -distanceWithChain);
    }
}
