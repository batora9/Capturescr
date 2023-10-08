using System;
using System.Windows;

namespace Capturescr2
{
    internal class PresentationSource
    {
        public object CompositionTarget { get; internal set; }

        internal static PresentationSource FromVisual(Window mainWindow)
        {
            throw new NotImplementedException();
        }
    }
}