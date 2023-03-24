using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    AudioSource audio;

    // Start is called before the first frame update
    public List<AudioClip> goalAudioList = new List<AudioClip>();
    public List<AudioClip> jubilianceAudioList = new List<AudioClip>();
    public List<AudioClip> boundaryAudioList = new List<AudioClip>();
    public List<AudioClip> kickAudioList = new List<AudioClip>();
    public List<AudioClip> openingAudioList = new List<AudioClip>();

    // shapes catcher
    public List<AudioClip> catchShapeList = new List<AudioClip>();
    public List<AudioClip> catchSpecialShapeList = new List<AudioClip>();
    public List<AudioClip> shapeWinnerList = new List<AudioClip>();

    private enum AudioCondition
    {
        GOAL = 0,
        JUBILIANCE = 1,
        BOUNDARY = 2,
        KICK = 3,
        OPENING = 4,

        CATCHSHAPE = 5,
        CATCHSPECIAL = 6,
        SHAPEWIN = 7,
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
    }

    public void PlayGoalAudio(Vector3 pos)
    {
        PlayAudio(AudioCondition.GOAL, pos);
    }

    public void PlayBoundaryAudio(Vector3 pos)
    {
        PlayAudio(AudioCondition.BOUNDARY, pos);
    }

    public void PlayKickAudio(Vector3 pos)
    {
        PlayAudio(AudioCondition.KICK, pos);
    }

    public void PlayJubilianceAudio(Vector3 pos)
    {
        PlayAudio(AudioCondition.JUBILIANCE, pos);
    }

    public void PlayOpeningAudio(Vector3 pos)
    {
        PlayAudio(AudioCondition.OPENING, pos);
    }

    public void PlayCatchShapeAudio(Vector3 pos)
    {
        PlayAudio(AudioCondition.CATCHSHAPE, pos);
    }
    public void PlayCatchSpecialShapeAudio(Vector3 pos)
    {
        PlayAudio(AudioCondition.CATCHSPECIAL, pos);
    }
    public void PlayShapeWinAudio(Vector3 pos)
    {
        PlayAudio(AudioCondition.SHAPEWIN, pos);
    }

    private void PlayAudio(AudioCondition condition, Vector3 position)
    {
        List<AudioClip> playList;
        switch (condition)
        {
            case AudioCondition.BOUNDARY:
            default:
                playList = boundaryAudioList;
                break;
            case AudioCondition.GOAL:
                playList = goalAudioList;
                break;
            case AudioCondition.JUBILIANCE:
                playList = jubilianceAudioList;
                break;
            case AudioCondition.KICK:
                playList = kickAudioList;
                break;
            case AudioCondition.OPENING:
                playList = openingAudioList;
                break;
            case AudioCondition.CATCHSHAPE:
                playList = catchShapeList;
                break;
            case AudioCondition.CATCHSPECIAL:
                playList = catchSpecialShapeList;
                break;
            case AudioCondition.SHAPEWIN:
                playList = shapeWinnerList;
                break;
        }

        if (playList == null || playList.Count == 0)
        {
            return;
        }

        int choice = Random.Range(0, playList.Count);
        audio.clip = playList[choice];
        audio.Play();
    }
}