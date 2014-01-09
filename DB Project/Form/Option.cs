using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Project
{
    public partial class Option : Form
    {
        public Option()
        {
            InitializeComponent();

            OptionKeyDown.Checked = CGlobalVariable.Instance.HookKeyDown;
            OptionKeyPress.Checked = CGlobalVariable.Instance.HookKeyPress;
            OptionKeyUp.Checked = CGlobalVariable.Instance.HookKeyUp;

            OptionMouseMove.Checked = CGlobalVariable.Instance.HookMouseMove;
            OptionMouseLClick.Checked = CGlobalVariable.Instance.HookMouseLClick;
            OptionMouseRClick.Checked = CGlobalVariable.Instance.HookMouseRClick;
            OptionMouseWheel.Checked = CGlobalVariable.Instance.HookMouseWheel;

            OptionInterval.Text = CGlobalVariable.Instance.interval.ToString();
        }
        
        private void OptionCancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void OptionOKButton_Click(object sender, EventArgs e)
        {
            CGlobalVariable.Instance.HookKeyDown = OptionKeyDown.Checked;
            CGlobalVariable.Instance.HookKeyPress = OptionKeyPress.Checked;
            CGlobalVariable.Instance.HookKeyUp = OptionKeyUp.Checked;

            CGlobalVariable.Instance.HookMouseMove = OptionMouseMove.Checked;
            CGlobalVariable.Instance.HookMouseLClick = OptionMouseLClick.Checked;
            CGlobalVariable.Instance.HookMouseRClick = OptionMouseRClick.Checked;
            CGlobalVariable.Instance.HookMouseWheel = OptionMouseWheel.Checked;

            CGlobalVariable.Instance.interval = Convert.ToInt32(OptionInterval.Text);
            this.Dispose();
        }
    }
}
