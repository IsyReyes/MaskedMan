using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    
    public static SoundManager instance; // instancia static, global
    
    private AudioSource _audioSource; // componente de audio
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        //revisa si la instancia existe o no
        if (instance == null)
        {
            //si no existe, crea una instancia de la misma clase
            instance = this;
            DontDestroyOnLoad(gameObject); //cmbiar escenas sin destruir
        }
        else
        {
            Destroy(gameObject); // si la instancia se est[a intentando duplicar, la destruye
        }
    }

    private void OnEnable()
    {
        PlayerInput.IsMaskedManWalking += PlayWalkAudio;
        PlayerInput.PlayerStoppedWalking += StopWalkAudio;
    }

    private void OnDisable()
    {
        PlayerInput.IsMaskedManWalking -= PlayWalkAudio;
        PlayerInput.PlayerStoppedWalking -= StopWalkAudio;
    }
    private void PlayWalkAudio() => _audioSource.Play();
    private void StopWalkAudio() => _audioSource.Stop();
    
}
