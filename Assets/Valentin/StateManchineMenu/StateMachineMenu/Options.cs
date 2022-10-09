using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Options : MonoBehaviour
{
    public TMPro.TMP_Dropdown Resolution;

    public AudioSource BackgroundAudioSource;
    public Slider VolumeSlider;
    public TextMeshProUGUI TxtVolume;

    // Start is called before the first frame update
    void Start()
    {
        SliderChange();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetResolution()
    {
        switch (Resolution.value)
        {

            case 0:
                Screen.SetResolution(1920, 1080, true);
                break;

            case 1:
                Screen.SetResolution(1920, 1080, false);
                break;
        }
    }

    public void SliderChange()
    {
        BackgroundAudioSource.volume = VolumeSlider.value;
        TxtVolume.text = "Volume " + (BackgroundAudioSource.volume * 100).ToString("00")+ "%";
    }
}
