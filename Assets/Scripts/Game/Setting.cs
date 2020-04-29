using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class Setting : MonoBehaviour
{
    [Header("Post Processing")]
    [SerializeField] private Toggle _postProcessToggle;
    [SerializeField] private PostProcessVolume _postProcess;

    [Header("Volume")]
    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private Slider _music;
    [SerializeField] private Slider _sound;

    [Header("Sound")]
    [SerializeField] AudioSource _clickSound;

    [Header("Save")]
    [SerializeField] private SaveAndLoad _save;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameObject.activeSelf) gameObject.SetActive(false);
        }
    }

    public void SetPostProcess(bool enabled)
    {
        _clickSound.Play();

        _postProcess.enabled = enabled;
        _postProcessToggle.isOn = enabled;
    }

    public void SetMusicVolume(float volume)
    {
        _mixer.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80f, 0f, Mathf.Pow(volume, 0.25f)));
        _music.value = volume;
    }

    public void SetSoundVolume(float volume)
    {
        _mixer.audioMixer.SetFloat("SoundVolume", Mathf.Lerp(-80f, 0f, Mathf.Pow(volume, 0.25f)));
        _sound.value = volume;
    }

    public void DefaultSetting()
    {
        _clickSound.Play();

        SetPostProcess(true);
        SetMusicVolume(1f);
        SetSoundVolume(1f);

        _save.SaveAll();
    }

    public bool GetPostProcess() { return _postProcess.enabled; }
    public float GetMusicVolume() { return _music.value; }
    public float GetSoundVolume() { return _sound.value; }
}
