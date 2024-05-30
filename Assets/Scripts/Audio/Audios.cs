using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Audios",menuName = "AudioConfig/Audios")]
public class Audios : ScriptableObject
{
    public List<Audio> config_for_all_audios;
}
[System.Serializable]
public class Audio
{
    public string name;
    public AudioClip clip;
}
