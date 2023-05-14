using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider volumeSlider;

    public void SetVolumeValue()
    {
        float volume = volumeSlider.value;
        if (volume == 0)
        {
            Debug.Log(volume);
            myMixer.SetFloat("music", -80);
            myMixer.SetFloat("buttons", -80);
            return;
        }
        myMixer.SetFloat("music", Mathf.Log10(volume)*20);
        myMixer.SetFloat("buttons", Mathf.Log10(volume*0.8f)*20);
    }
}
