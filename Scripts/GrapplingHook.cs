using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    [SerializeField] private Player Player;
    [SerializeField] private float grappleLength;
    [SerializeField] private LayerMask grappleLayer;
    [SerializeField] private LineRenderer rope;
    [SerializeField] private Transform ropeHand;
    [SerializeField] private Rigidbody2D rg;
    [SerializeField] private Animator animator;
    [SerializeField] private SoundEffectPlayer SoundPlayer;
    [SerializeField] bool started = false;


    private Vector3 grapplePoint;
    private DistanceJoint2D joint;

    void Start()
    {
        joint = gameObject.GetComponent<DistanceJoint2D>();
        joint.enabled = false;
        rope.enabled = false;
    }

    void Update()
    {
        if (!started)
        {
            return;
        }

        if (!Player.isStun && Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(
                origin: Camera.main.ScreenToWorldPoint(Input.mousePosition),
                direction: Vector2.zero,
                distance: Mathf.Infinity,
                layerMask: grappleLayer);

            if (hit.collider != null)
            {
                grapplePoint = hit.point;
                grapplePoint.z = 0;
                float direction = transform.position.x - grapplePoint.x;
                if (Mathf.Abs(direction) > 1.15)
                {
                    joint.connectedAnchor = grapplePoint;
                    joint.enabled = true;
                    joint.distance = grappleLength;
                    rope.SetPosition(0, grapplePoint);
                    rope.SetPosition(1, ropeHand.position);
                    rope.enabled = true;

                    Vector3 localScale = Player.transform.localScale;
                    localScale.x = direction > 0 ? 0.4f : -0.4f;
                    Player.transform.localScale = localScale;
                    rg.freezeRotation = false;
                    SoundPlayer.PlayStuck();


                    animator.SetBool("isSlinging", true);
                }
            }
        }

        if (Input.GetMouseButtonUp(0) || Player.isStun)
        {
            joint.enabled = false;
            rope.enabled = false;
            Player.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            rg.freezeRotation = true;
            animator.SetBool("isSlinging", false);
        }

        if (rope.enabled == true)
        {
            rope.SetPosition(1, ropeHand.position);
        }
    }

    public void Started()
    {
        started = true;
    }

    public void GameOver()
    {
        started = false;
    }
}