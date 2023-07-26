using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundController : MonoBehaviour
{
    AudioClip[] BGMs = new AudioClip[(int)Define.BGM.MaxCount];
    AudioClip[] SFXs = new AudioClip[(int)Define.SFX.MaxCount];

    HashSet<string> SFXNames = new HashSet<string>();
    HashSet<string> BGMNames = new HashSet<string>();

    public AudioSource BGMSource;
    public AudioSource SFXSource;

    public void init()
    {
        SoundPooling(); // ���� ���ϵ��� Ǯ�� �ؿ´�
        BGMSource = gameObject.AddComponent<AudioSource>();
        SFXSource = gameObject.AddComponent<AudioSource>();
        BGMSource.volume = DataManager.Single.Data.optionData.volumeBGM;
        SFXSource.volume = DataManager.Single.Data.optionData.volumeSFX;
    }

    private void Update()
    {
        BGMSource.volume = DataManager.Single.Data.optionData.volumeBGM;
        SFXSource.volume = DataManager.Single.Data.optionData.volumeSFX;
    }

    void SoundPooling() // enum���� ���� �̸��� �о�ͼ� �ش��ϴ� ���� ������ �ε� ��Ų��
    {
        string[] BGMNames = System.Enum.GetNames(typeof(Define.BGM));
        string[] SFXNames = System.Enum.GetNames(typeof(Define.SFX));
        for (int i = 0; i < BGMNames.Length - 1; i++)
        {
            BGMs[i] = Resources.Load<AudioClip>("Sound/BGM/" + BGMNames[i]);
            this.BGMNames.Add(BGMNames[i]);
        }
        for (int i = 0; i < SFXNames.Length - 1; i++)
        {
            SFXs[i] = Resources.Load<AudioClip>("Sound/SFX/" + SFXNames[i]);
            this.SFXNames.Add(SFXNames[i]);
        }
    }
    public void Play(string soundName, float pitch = 1.0f) // ���޹��� soundName�� ã�Ƽ� �����Ų��
    {
        BGMSource.volume = DataManager.Single.Data.optionData.volumeBGM;
        SFXSource.volume = DataManager.Single.Data.optionData.volumeSFX;
        BGMSource.mute = DataManager.Single.Data.optionData.muteBGM;
        SFXSource.mute = DataManager.Single.Data.optionData.muteSFX;
        if (BGMNames.Contains(soundName))
        {
            if (BGMSource.isPlaying)
            {
                BGMSource.Stop();
            }
            BGMSource.pitch = pitch;
            BGMSource.clip = BGMs[(int)((Define.BGM)Enum.Parse(typeof(Define.BGM), soundName))];
            BGMSource.Play();
        }
        else if (SFXNames.Contains(soundName))
        {
            SFXSource.pitch = pitch;
            SFXSource.PlayOneShot(SFXs[(int)((Define.SFX)Enum.Parse(typeof(Define.SFX), soundName))]);
        }
        else
        {
            Debug.Log("�ش� ����� �������� �ʽ��ϴ�");
        }
    }
}