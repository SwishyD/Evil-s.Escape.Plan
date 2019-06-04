using UnityEngine;

public class ActionController : MonoBehaviour
{
    [SerializeField]
    private Animator anim;

    public void ControlSwitch(int transition)
    {
        anim.SetInteger("Actions", transition);
    }
    
   
}
