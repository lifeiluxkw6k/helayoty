﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinformDemo
{
  public partial class NumberTimeExtForm : Form
  {
    public NumberTimeExtForm()
    {
      InitializeComponent();
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      this.timeExt1.Value = DateTime.Now;
      this.timeExt3.Value = DateTime.Now;
      this.timeExt4.Value = DateTime.Now;
    }
  }
}
