using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] clipsBonusRus;
    public AudioClip[] clipsBonusLiz;

    public AudioClip[] clipsHeroRus;
    public AudioClip[] clipsHeroLiz;

    public AudioClip Victory;
    public AudioClip Lose;

    public AudioSource audioSource;

    public void BonusSound(int audio, HeroType hero)
    {
        if(hero == HeroType.Rus)
        {
            audioSource.clip = clipsBonusRus[audio];
            audioSource.Play();
        }
        else
        {
            audioSource.clip = clipsBonusLiz[audio];
            audioSource.Play();
        }
    }

    public void HeroSound(int audio, HeroType hero)
    {
        if (hero == HeroType.Rus)
        {
            audioSource.clip = clipsHeroRus[audio];
            audioSource.Play();
        }
        else
        {
            audioSource.clip = clipsHeroLiz[audio];
            audioSource.Play();
        }
    }

    public void Finish(bool result)
    {
        if(result)
        {
            audioSource.clip = Victory;
            audioSource.Play();
        }
        else
        {
            audioSource.clip = Lose;
            audioSource.Play();
        }
    }
}
