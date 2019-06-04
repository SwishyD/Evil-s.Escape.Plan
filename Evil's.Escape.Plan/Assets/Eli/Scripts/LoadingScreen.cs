using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField]
    private Animator anim;

    public void LoadingComplete()
    {
        AudioManager.instance.CancelMonster();
        AudioManager.instance.Background(true, false);
        bool isLoading = false;
        anim.SetBool("IsLoading", isLoading);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
