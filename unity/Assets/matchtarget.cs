using UnityEngine;
using System.Collections;

public class matchtarget : MonoBehaviour
{

    private Quaternion rotationTarget = new Quaternion(0, 0, 0, -7);

    static int idleState = Animator.StringToHash("Base Layer.Idle");
    static int turnState = Animator.StringToHash("Base Layer.Turn");

    private Animator anim;
    private AnimatorStateInfo currentBaseState; 

    void Start()
    {
        anim = GetComponent<Animator>(); 
    }

    void FixedUpdate()
    {
        if (currentBaseState.nameHash == turnState)
        {
            Debug.Log("In turn state, adding match target"); 
            anim.SetBool("Turn", false);
            anim.MatchTarget(anim.rootPosition, rotationTarget, AvatarTarget.Root, new MatchTargetWeightMask(Vector3.zero, 1F), 0.2f, 1f);

        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            currentBaseState = anim.GetCurrentAnimatorStateInfo(0); 
            Debug.Log("N Pressed " + currentBaseState.nameHash + ", idlestate: " + idleState);
            if (currentBaseState.nameHash == idleState)
            {
                Debug.Log("IIn idleState");
                rotationTarget *= Quaternion.Euler(0, 180, 0);
                Debug.Log(rotationTarget);
                anim.SetBool("Turn", true);

            }
        }

    }
}
