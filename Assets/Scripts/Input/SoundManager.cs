using UnityEngine;

public class SoundManager : MonoBehaviour
{
    
    public static SoundManager instance; // instancia static, global
    
    private AudioSource _audioSource; // componente de audio
    private void Awake()
    {
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


    public void WalkSound()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play();
    }

    public void StopSound()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Stop();
    }
}
