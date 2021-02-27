using PlayerScripts;

namespace DI
{
    public interface IHighScores
    {
        HighScoreList GetHighScores();

       void CheckUpdateList(HighScoreDTO newScore);
    }
}