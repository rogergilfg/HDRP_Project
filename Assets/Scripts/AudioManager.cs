using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private GameObject prefabSFX;

    [SerializeField] private AudioClip footSteps;
    [SerializeField] private AudioClip palomas;
    private AudioSource steps;
    private AudioSource music;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayMusic(0.1f);
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        music = gameObject.AddComponent<AudioSource>();
        steps = gameObject.AddComponent<AudioSource>();
        steps.playOnAwake = false;
    }


    public void PlayMusic(float _volume)
    {
        music.clip = palomas;
        music.volume = _volume;
        music.loop = true;
        music.Play();
    }

    public void StopMusic()
    {
        music.Stop();
    }

    public void PlaySFX(AudioClip _sfx, float _volumeLevel, bool _loop, Vector3 _position)
    {
        GameObject sfxClone = Instantiate(prefabSFX, _position, Quaternion.identity);
        sfxClone.GetComponent<AudioSource>().clip = _sfx;
        sfxClone.GetComponent<AudioSource>().volume = _volumeLevel;
        sfxClone.GetComponent<AudioSource>().Play();
        sfxClone.GetComponent<AudioSource>().loop = _loop;
        
        if(_loop == false)
        {
            Destroy(sfxClone, _sfx.length);
        }
        else
        {
            Destroy(sfxClone, 5f);
        }    
    }

    public void StopSFX()
    {
        Destroy(GameObject.FindGameObjectWithTag("SFX"));
    }

    public void PlaySteps(float _volume)
    {
        //Debug.Log("Reproduciendo pasos");
        steps.clip = footSteps;
        steps.loop = true;
        steps.volume = _volume;
        steps.Play();
    }

    public void StopSteps()
    {
        steps.Stop();
    }
}
