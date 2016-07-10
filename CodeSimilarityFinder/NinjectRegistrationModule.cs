using CodeSimilarityFinder.Services;
using Ninject.Modules;

namespace CodeSimilarityFinder
{
    public class NinjectRegistrationModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<IProjectScanner>().To<ProjectScanner>();
            Kernel.Bind<ISolutionComponentsLoader>().To<SolutionComponentsLoader>();
        }
    }
}
