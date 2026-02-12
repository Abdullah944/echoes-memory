//? -------- what / why --------
//? This file does one task: read movement state from PlayerController and set Animator parameters
//? (isWalking, FacingX, FacingY, MoveX, MoveY) so Idle and Walk blend trees show the right direction.
//? Attach to the same GameObject as PlayerController and Animator.

using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    //? -------- state / cache -------- Refs to controller and animator; not shown in Inspector.

    PlayerController controller;
    Animator animator;

    //? -------- Unity lifecycle -------- Get refs, then every frame update Animator from movement state.

    void Awake()
    {
        controller = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (animator == null) return;
        if (controller == null) return;

        animator.SetBool("isWalking", controller.IsMoving);
        animator.SetFloat("FacingX", controller.LastFacingDirection.x);
        animator.SetFloat("FacingY", controller.LastFacingDirection.y);
        animator.SetFloat("MoveX", controller.LastFacingDirection.x);
        animator.SetFloat("MoveY", controller.LastFacingDirection.y);
    }
}