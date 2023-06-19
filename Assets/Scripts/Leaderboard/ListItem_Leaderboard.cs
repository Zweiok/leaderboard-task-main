using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ListItem_Leaderboard : MonoBehaviour
{
    [SerializeField] private RawImage _avatarIco;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _score;
    [SerializeField] private TMP_Text _rank;

    public RawImage AvatarIco { get => _avatarIco; }

    public void SetupData(PlayerData_Leaderboard data, LeaderboardRankTextSettings rankTextSettings)
    {
        _name.text = data.name;
        _score.text = data.score.ToString();
        _rank.text = data.type.ToString();

        _rank.fontSize = rankTextSettings.fontSize;
        _rank.color = rankTextSettings.color;
    }

    public void SetImageTexture(Texture2D texture)
    {
        if(_avatarIco != null)
            _avatarIco.texture = texture;
    }

    private void OnDestroy()
    {
        DestroyImmediate(_avatarIco.texture, false);
    }
}
