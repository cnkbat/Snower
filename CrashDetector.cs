using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CrashDetector : MonoBehaviour
{   
    [SerializeField] float DelayTime=1;
    [SerializeField] ParticleSystem CrushEffect;

    [SerializeField] AudioClip CrashEffect;
    
    bool IsDead = false;
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Ground" && !IsDead)
        {
            IsDead=true;
            FindObjectOfType<PlayerController>().DisableController();
            CrushEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(CrashEffect);
            Invoke("ReloadScene",DelayTime);
            
        }
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
