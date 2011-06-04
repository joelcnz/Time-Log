/*
 * This class is very like the Program class except the absence(sp) of static methods
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeLog
{
    class TimeLog
    {
        public TimeLog( string[] args )
        {
            m_userControl = new UserControl( new string[] {"Bible", "C#"} );
            Run();
        }

        private void Run()
        {
            var done = false;
            
            while (!done)
            {
                done = m_userControl.ControlPrompt();
            }
        }

        private UserControl m_userControl;
    }
}
