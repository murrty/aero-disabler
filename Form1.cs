using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AERODisabler {
    public partial class Form1 : Form {
        bool isDisabled = false;

        [DllImport("dwmapi.dll", EntryPoint = "DwmEnableComposition")]
        extern static uint DwmEnableComposition(uint compositionAction);
        [DllImport("dwmapi.dll", PreserveSig = false)]
        public static extern bool DwmIsCompositionEnabled();
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            DwmEnableComposition(0);
            isDisabled = true;
            button1.Enabled = false;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e) {
            DwmEnableComposition(1);
            isDisabled = false;
            button1.Enabled = true;
            button2.Enabled = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            if (isDisabled)
                DwmEnableComposition(1);
        }

        private void Form1_Load(object sender, EventArgs e) {
            if (DwmIsCompositionEnabled()) {
                button1.Enabled = true;
                button2.Enabled = false;
                return;
            }
            else {
                button1.Enabled = false;
                button2.Enabled = true;
            }
        }


    }
}
