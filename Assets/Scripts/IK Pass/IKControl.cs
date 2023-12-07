using UnityEngine;

[RequireComponent(typeof(Animator))]

public class IKControl : MonoBehaviour {

    protected Animator animator;

    public bool ikActive = false;
    public AvatarIKGoal limbType = AvatarIKGoal.RightHand;
    public Transform limbObj = null;
    public Transform lookObj = null;

    void Start ()
    {
        animator = GetComponent<Animator>();
    }

    // коллбек для расчета IK
    void OnAnimatorIK()
    {
        if(animator) {

            // если IK активна, устанавливаем целевые позиции и вращения
            if(ikActive) {

                // Если есть, на что смотреть, поворачиваем голову
                if(lookObj != null) {
                    animator.SetLookAtWeight(1);
                    animator.SetLookAtPosition(lookObj.position);
                }    

                // Устанавливаем положение конечности
                if(limbObj != null) {
                    animator.SetIKPositionWeight(limbType,1);
                    animator.SetIKRotationWeight(limbType,1);  
                    animator.SetIKPosition(limbType,limbObj.position);
                    animator.SetIKRotation(limbType,limbObj.rotation);
                }        

            }

            // Если IK выключена, сбрасываем всё на дефолтные значения
            else {          
                animator.SetIKPositionWeight(limbType,0);
                animator.SetIKRotationWeight(limbType,0);
                animator.SetLookAtWeight(0);
            }
        }
    }    
}