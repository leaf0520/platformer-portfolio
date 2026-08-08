using UnityEngine;

public class LevelMusicTrigger : MonoBehaviour
{
    private void Start()
    {
        AudioManager.Instance.PlayLevelMusic();
    }
}