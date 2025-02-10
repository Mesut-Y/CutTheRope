using UnityEngine;
using UnityEngine.Pool;

public class RopeManager : MonoBehaviour
{
    public Rigidbody2D firstHook;
    public BallManager _Ball;
    public int linkCounter = 8; //kanca ve top arası bağlantı sayısı
    public GameObject[] linkPool;

    public string hingeName; 

    //public GameObject linkPrefab; //The code is used for prototype
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hingeName = linkPool[1].tag; 
        CreateRope();
    }

    void CreateRope()
    {
        Rigidbody2D lastLink = firstHook;

        for (int i = 0; i < linkCounter; i++)
        {
            linkPool[i].SetActive(true);
            HingeJoint2D joint = linkPool[i].GetComponent<HingeJoint2D>();
            joint.connectedBody = lastLink;
            if (i < linkCounter - 1)
            {
                lastLink = linkPool[i].GetComponent<Rigidbody2D>();
            }
            else
            {
                _Ball.TieLastChain(linkPool[i].GetComponent<Rigidbody2D>(), hingeName);
            }
        }

        //for (int i = 0; i < linkCounter; i++) //The code is used for prototype
        //{
        //    GameObject link = Instantiate(linkPrefab, transform);
        //    HingeJoint2D joint = link.GetComponent<HingeJoint2D>();
        //    joint.connectedBody = lastLink;
        //    if (i < linkCounter - 1)
        //        lastLink = link.GetComponent<Rigidbody2D>();
        //    else
        //        _Ball.TieLastChain(link.GetComponent<Rigidbody2D>());
        //}
    }
}
