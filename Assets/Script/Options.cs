using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Options : MonoBehaviour
{
    public GameObject inGameToggle1;
    public GameObject inGameToggle2;
    public GameObject inGameToggle3;
    public GameObject inGameSlider1;
    public GameObject inGameSlider2;

    public static bool ballTrailEffect = true;
    public static bool ballParticleEffect;
    public static bool muteSounds;
    public static float volumeSliderOptions = 1;
    public static float speedSliderOptions = 10;

    public AudioMixer audioMixer;

    void Start()
    {
        inGameToggle1.GetComponent<Toggle>().isOn = ballTrailEffect;
        inGameToggle2.GetComponent<Toggle>().isOn = ballParticleEffect;
        inGameToggle3.GetComponent<Toggle>().isOn = muteSounds;
        inGameSlider1.GetComponent<Slider>().value = volumeSliderOptions;
        inGameSlider2.GetComponent<Slider>().value = speedSliderOptions;
    }
    
    //function to enable or disable the ball's trailing effect
    public void TrailingEffect()
    {
        if (inGameToggle1.GetComponent<Toggle>().isOn)
        {
            ballTrailEffect = true;
        }
        else
        {
            ballTrailEffect = false;
        }
    }

    //function to enable or disable the ball's particle effect
    public void ParticleEffect()
    {
        if (inGameToggle2.GetComponent<Toggle>().isOn)
        {
            ballParticleEffect = true;
        }
        else
        {
            ballParticleEffect = false;
        }
    }

    //function to mute gameplay sounds
    public void ToggleMute()
    {
        if (inGameToggle3.GetComponent<Toggle>().isOn)
        {
            muteSounds = true;
        }
        else
        {
            muteSounds = false;
        }
    }

    //function to adjust music volume
    //set the slider value min=0.0001 and max=1
    public void VolumeSlider(float volume)
    {
        volumeSliderOptions = volume;
        audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);    //convert linear value to attenuation level
    }

    //function to adjust 2Players ballspeed
    //set the slider value min=0.0001 and max=1
    public void TwoPlayerBallSpeedSlider(float speed)
    {
        speedSliderOptions = speed;
        //Debug.Log(speedSliderOptions);
    }

    public void Back()
    {
        Time.timeScale = 1f;
        SceneChanger.PreviousScene();
    }

}
