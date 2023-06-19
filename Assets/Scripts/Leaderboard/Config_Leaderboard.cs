using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName = "Configs/LeaderboardConfig", fileName = "Config_Leaderboard")]
public class Config_Leaderboard : ScriptableObject
{
    public string popupAddressableName;
    public string jsonAddressableName;
    public LeaderboardRankTextSettings[] rankTexts;
    
    public LeaderboardRankTextSettings GetRankTextSettings(PlayerRankType type)
    {
        return rankTexts.FirstOrDefault(x => x.type == type);
    }
}

