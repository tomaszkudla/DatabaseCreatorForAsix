using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCreatorForAsix
{
    /// <summary>
    /// Args for NewTagAdded event.
    /// </summary>
    public class NewTagAddedArgs:EventArgs
    {
        public Tag tag;

        public NewTagAddedArgs(Tag tag)
        {
            this.tag = tag;
        }
    }

    /// <summary>
    /// Args for ProgressChanged event.
    /// </summary>
    public class ProgressChangedArgs:EventArgs
    {
        public int Percent;

        public ProgressChangedArgs(int Percent)
        {
            this.Percent = Percent;
        }
    }

    /// <summary>
    /// Args for LogEvent event.
    /// </summary>
    public class LogEventArgs : EventArgs
    {
        public string Info;

        public LogEventArgs(string Info)
        {
            this.Info = Info;
        }
    }
}
