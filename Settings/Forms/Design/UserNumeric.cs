using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ShinraCo.Settings.Forms.Design
{
    public partial class UserNumeric : UserControl
    {
        public UserNumeric()
        {
            InitializeComponent();
        }

        [Category("Appearance")]
        [DefaultValue(typeof(decimal), "100")]
        public decimal Value
        {
            get => customNumeric1.Value;
            set => customNumeric1.Value = value;
        }

        [Category("Data")]
        [DefaultValue(typeof(decimal), "5")]
        public decimal Increment
        {
            get => customNumeric1.Increment;
            set => customNumeric1.Increment = value;
        }

        [Category("Data")]
        [DefaultValue(typeof(decimal), "100")]
        public decimal Maximum
        {
            get => customNumeric1.Maximum;
            set => customNumeric1.Maximum = value;
        }

        [Category("Data")]
        [DefaultValue(true)]
        public bool ShowSymbol
        {
            get => customNumeric1.ShowSymbol;
            set => customNumeric1.ShowSymbol = value;
        }

        public event EventHandler ValueChanged
        {
            add => customNumeric1.ValueChanged += value;
            remove => customNumeric1.ValueChanged -= value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Focus();
            if (customNumeric1.Value < customNumeric1.Maximum)
                customNumeric1.Value =
                    Math.Min(customNumeric1.Maximum, customNumeric1.Value + customNumeric1.Increment);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Focus();
            if (customNumeric1.Value > customNumeric1.Minimum)
                customNumeric1.Value =
                    Math.Max(customNumeric1.Minimum, customNumeric1.Value - customNumeric1.Increment);
        }

        private void customNumeric1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Return) label1.Focus();
        }
    }
}