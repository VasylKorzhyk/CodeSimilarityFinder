using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ninject;

namespace CodeSimilarityFinder
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var kernel = new StandardKernel(new NinjectRegistrationModule());
            var form = kernel.Get<Form1>();
            Application.Run(form);
            //Application.Run(new Form1());
        }
    }
}
