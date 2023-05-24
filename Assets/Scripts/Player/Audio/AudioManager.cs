using System;
using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private Player _player;
    private bool _playFirst;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    public void PlayTargetAudio(Sound targetAudio, AudioSource source)
    {
        source.clip = targetAudio.clip;
        source.volume = targetAudio.volume;
        source.pitch = targetAudio.pitch;
        source.loop = targetAudio.isLooping;
        source.Play();
    }

    public void StopTargetSource(AudioSource source)
    {
        source.Stop();
    }

    public IEnumerator PlayBreathing()
    {
        if (_player.playerModel.stamina.currentStamina < _player.playerModel.stamina.pantingLimit && !_player.playerModel.stamina.isPanting)
        {
            PlayTargetAudio(Array.Find(_player.playerModel.stamina.sounds, sound => sound.name == "After Run Breathing"), _player.playerModel.stamina.source);
            _player.playerModel.stamina.isPanting = true;
            yield return new WaitUntil(() => !_player.playerModel.stamina.source.isPlaying);
            _player.playerModel.stamina.isPanting = false;
        }
        if(!_player.playerModel.stamina.isPanting && !_player.playerModel.stamina.source.isPlaying) PlayTargetAudio(Array.Find(_player.playerModel.stamina.sounds, sound => sound.name == "Normal Breathing"), _player.playerModel.stamina.source);
        yield return null;
    }
}