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
        public TimeLog(CommandProcessor commandProcessor)
        {
            userControl = new UserControl(commandProcessor, new CommandlineParser());
        }

        public void Run()
        {
            while (true)
            {
                userControl.ControlPrompt();
            }
        }

        private readonly UserControl userControl;
    }
}
