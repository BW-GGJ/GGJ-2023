using UnityEngine;
using UnityEngine.Animations;
public class BrotherDeath : MonoBehaviour
{
    public void Animate() 
    {
        GetComponent<Animator>().SetBool("died", true);
    }
}