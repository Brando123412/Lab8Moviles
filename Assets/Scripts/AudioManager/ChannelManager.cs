using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "ChannelManager", menuName = "ScriptableObjects/Audio/ChannelManager", order = 1)]
public class ChannelManager : ScriptableObject
{
    [SerializeField] string channelVolume;
    public float currentVolume;
    [SerializeField] private AudioMixer myMixer;
    public float valueVolume;
    public Sprite[] buttonMute;
    public bool isMuted;
    bool startconfirmation;
    public void UpdateVolume(Slider mySlider)
    {
        if (startconfirmation != true)
        {
            currentVolume = mySlider.value;
            myMixer.SetFloat(channelVolume, Mathf.Log10(currentVolume) * 20f);
            isMuted = false;
        }
        else
        {
            startconfirmation = false;
        }
    }
    public void UpdateVolumeText(TMP_Text myText)
    {
        Debug.Log(name);
        valueVolume = Mathf.Round(currentVolume * 100);
        myText.text = valueVolume.ToString();
    }
    public void muteAudio(Button botton)
    {
        if (isMuted)
        {
            myMixer.SetFloat(channelVolume, Mathf.Log10(currentVolume) * 20f);
            isMuted = false;
            botton.image.sprite = buttonMute[1];
        }
        else
        {
            myMixer.SetFloat(channelVolume, -80);
            isMuted = true;
            botton.image.sprite = buttonMute[0];
        }
    }
    public void Inicio(bool prueba)
    {
        startconfirmation = prueba;
    }
}