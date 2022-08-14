using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Audio[] audios;
    public static AudioManager instance;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(instance);
    }
    public void playSound(string name)
    {
        foreach(var item in audios)
        {
            if (item.name.Equals(name))
            {
                if (item.source == null)
                    item.source = gameObject.AddComponent<AudioSource>();

                    item.source.clip = item.clip;
                    item.source.volume = item.volume;
                    item.source.loop = item.loop;

                item.source.Play();
                break;
            }
        }
    }
}
