/*
 * This class isv very like the Program class except the absence(sp) of static methods
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeLog
{
    class TimeLog
    {
        public TimeLog( UserControl userContol )
        {
            m_userControl = userContol;
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
