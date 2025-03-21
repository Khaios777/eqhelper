using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EQHelperCore
{
    public class PlayerClientKeybind
    {
        public string KeyValue { get; set; }
        public string CommandToSend { get; set; }
        public PlayerClient PlayerClientRef { get; set; }
        public bool SendToAllClients  { get; set; }
        public bool IsSpell { get; set; }
        public bool IsTimedKeybinding { get; set; }
        public bool IsTimedTurnedOn { get; set; }
        public string TimedLabelName { get; set; }
        public int TimedWaitTime { get; set; }
        public CheckBox TimedCheckbox {get; set;}
        public string ButtonLabelText { get; set; }


        public PlayerClientKeybind()
        {
            SendToAllClients = false;
            IsTimedKeybinding = false;
            IsSpell = false;
        }

        public void ToggleTimedKeybind()
        {
            if (IsTimedTurnedOn)
            {
                IsTimedTurnedOn = false;
                TimedCheckbox.Checked = false;
                PlayerClientRef.StopTimedCommand();
            }
            else
            {
                IsTimedTurnedOn = true;
                TimedCheckbox.Checked = true;
                PlayerClientRef.StartTimedCommand(this);
            }
        }

        //public void SendCommand() {
        //    int i = 0;
        //    // code to send bytes
        //}
    }
}
