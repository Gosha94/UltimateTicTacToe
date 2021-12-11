using System;

namespace TicTacToeFrontend.ConsoleApp.Base
{
    internal abstract class ContentViewBase
    {

        public virtual void ViewContent() { }
        
        /// <summary>
        /// Не переопределяемый метод, очищаюшщий консоль неизменным образом, в потомках будет использован этот метод
        /// </summary>
        internal void ClearConsole()
        {
            Console.Clear();
        }

    }
}