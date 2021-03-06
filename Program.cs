﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace keypad
{
    public class mdtclientForm : System.Windows.Forms.Form
    {
        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.Button FourButton;
        private CompletionComboBox CompletionComboBox;

        private string strLostFocus;

        public mdtclientForm()
        {

            InitializeComponent();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.FourButton = new System.Windows.Forms.Button();
            this.CompletionComboBox = new keypad.CompletionComboBox();
            this.SuspendLayout();

            this.FourButton.Location = new System.Drawing.Point(100, 150);
            this.FourButton.Name = "FourButton";
            this.FourButton.Size = new System.Drawing.Size(50, 45);
            this.FourButton.TabIndex = 29;
            this.FourButton.Text = "4";
            this.FourButton.Click += new
            System.EventHandler(this.NumericPad_Click);

            this.CompletionComboBox.Location = new System.Drawing.Point(32,
            88);
            this.CompletionComboBox.Name = "CompletionComboBox";
            this.CompletionComboBox.Size = new System.Drawing.Size(200, 21);
            this.CompletionComboBox.TabIndex = 3;
            this.CompletionComboBox.LostFocus += new
            System.EventHandler(this.COMBOBOX_LostFocus);
            this.CompletionComboBox.Text = "<Press Keys or Buttons>";
            this.CompletionComboBox.Items.AddRange(new object[] {
"440 - Line 0",
"441 - Line 1",
"442 - Line 2",
"443 - Line 3",
"444 - Line 4 ",
"445 - Line 5",
"446 - Line 5"});
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.FourButton);
            this.Controls.Add(this.CompletionComboBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
        }
        #endregion

        [STAThread]
        static void Main()
        {
            Application.Run(new mdtclientForm());
        }

        private void NumericPad_Click(object sender, System.EventArgs e)
        {
            foreach (Control controls in this.Controls)
            {
                if (controls.Name == strLostFocus)
                {
                    if (Object.ReferenceEquals(controls.GetType(),
                    typeof(CompletionComboBox)))
                    {
                        CompletionComboBox mycontrol = new CompletionComboBox();
                        Button button = (Button)sender;
                        if (controls.CanFocus)
                        {
                            controls.Focus();
                            SendKeys.SendWait(button.Text);
                        }
                    }
                }
            }
        }

        private void COMBOBOX_LostFocus(object sender, System.EventArgs e)
        {
            CompletionComboBox comboBox = (CompletionComboBox)sender;
            strLostFocus = comboBox.Name;
        }
    }

    public class CompletionComboBox : ComboBox
    {
        public event System.ComponentModel.CancelEventHandler NotInList;

        [Category("Behavior")]
        public bool LimitToList
        {
            get { return _limitToList_; }
            set { _limitToList_ = value; }
        }

        protected virtual void
        OnNotInList(System.ComponentModel.CancelEventArgs e)
        {
            if (NotInList != null)
                NotInList.Invoke(this, e);
        }

        protected override void
        OnValidating(System.ComponentModel.CancelEventArgs e)
        {
            if (_limitToList_)
            {
                int pos = FindStringExact(Text);
                if (pos == -1)
                    OnNotInList(e);
                else
                    this.SelectedIndex = pos;
            }
            base.OnValidating(e);
        }

        protected override void OnKeyDown(KeyEventArgs args)
        {
            _autoComplete_ = args.KeyCode != Keys.Delete && args.KeyCode !=
            Keys.Back;
            base.OnKeyDown(args);
        }

        protected override void OnTextChanged(EventArgs args)
        {
            if (_autoComplete_)
            {
                string textEntered = Text;
                int index = FindString(textEntered);
                if (index >= 0)
                {
                    _autoComplete_ = false;
                    SelectedIndex = index;
                    _autoComplete_ = true;
                    Select(textEntered.Length, Text.Length);
                }
            }
            base.OnTextChanged(args);
        }
        private bool _autoComplete_ = true;
        private bool _limitToList_ = true;
    }
}