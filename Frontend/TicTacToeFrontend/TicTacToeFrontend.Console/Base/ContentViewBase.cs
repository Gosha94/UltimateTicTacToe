using System;

namespace TicTacToeFrontend.ConsoleApp.Base
{
    internal abstract class ContentViewBase
    {

        public virtual void ViewContent() 
        {
            Console.WriteLine("Hello, this is Base Content Viewer Instance, try to override ViewContent() Method, dude!");
        }
        
        /// <summary>
        /// Не переопределяемый метод, очищаюшщий консоль неизменным образом, в потомках будет использован этот метод
        /// </summary>
        internal void ClearConsole()
        {
            Console.Clear();
        }

    }
}