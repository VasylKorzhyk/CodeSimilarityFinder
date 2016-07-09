using System;
using Ninject;
using Ninject.Modules;

namespace CodeSimilarityFinder
{
    class NinjectRegistrationModule : INinjectModule
    {
        public IKernel Kernel { get; }
        public void OnLoad(IKernel kernel)
        {
            throw new NotImplementedException();
        }

        public void OnUnload(IKernel kernel)
        {
            throw new NotImplementedException();
        }

        public void OnVerifyRequiredModules()
        {
            throw new NotImplementedException();
        }

        public string Name { get; }
    }
}
