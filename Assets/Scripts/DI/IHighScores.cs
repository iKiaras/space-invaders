using PlayerScripts;

namespace DI
{
    public interface IHighScores
    {
       void LoadHighScores();

       HighScoreList GetHighScores();

       void CheckUpdateList(HighScoreDTO newScore);
    }
}