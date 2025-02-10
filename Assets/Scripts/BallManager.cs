using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public float distanceWithChain = 0.2f;

    public Dictionary<string, HingeJoint2D> hingeControl = new Dictionary<string, HingeJoint2D>();
    public void TieLastChain(Rigidbody2D lastLink, string hingeName)
    {
        HingeJoint2D joint = gameObject.AddComponent<HingeJoint2D>();
        hingeControl.Add(hingeName, joint);
        joint.autoConfigureConnectedAnchor = false;
        joint.connectedBody = lastLink;
        joint.anchor = Vector2.zero;
        joint.connectedAnchor = new Vector2(0f, -distanceWithChain);
    }
}
