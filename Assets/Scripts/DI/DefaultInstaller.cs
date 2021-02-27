using Zenject;

namespace DI
{
    public class DefaultInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IHighScores>().To<HighScoresImpl>().AsSingle();
            Container.Bind<ILoader>().To<LoaderImpl>().AsSingle();
        }
    }
}