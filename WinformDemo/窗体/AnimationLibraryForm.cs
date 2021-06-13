using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using WcleAnimationLibrary;

namespace WinformDemo
{
  public partial class AnimationLibraryForm : Form
  {
    public AnimationLibraryForm()
    {
      InitializeComponent();
      this._exponent = (double)this.exponent_nud.Value;
      this.exponent_nud.ValueChanged += new System.EventHandler(this._exponent_ValueChanged);
      this._power = (double)this.power_nud.Value;
      this.power_nud.ValueChanged += new System.EventHandler(this._power_ValueChanged);
      this._amplitude = (double)this.amplitude_nud.Value;
      this.amplitude_nud.ValueChanged += new System.EventHandler(this._amplitude_ValueChanged);
      this._oscillations = (int)this.oscillations_nud.Value;
      this.oscillations_nud.ValueChanged += new System.EventHandler(this._oscillations_ValueChanged);
      this._springiness = (double)this.springiness_nud.Value;
      this.springiness_nud.ValueChanged += new System.EventHandler(this._springiness_ValueChanged);
      this._bounces = (int)this.bounces_nud.Value;
      this.bounces_nud.ValueChanged += new System.EventHandler(this._bounces_ValueChanged);
      this._bounciness = (double)this.bounciness_nud.Value;
      this.bounciness_nud.ValueChanged += new System.EventHandler(this._bounciness_ValueChanged);
      this._x = (int)this.x_nud.Value;
      this.x_nud.ValueChanged += new System.EventHandler(this._x_ValueChanged);
      this._time = (double)this.time_nud.Value;
      this.time_nud.ValueChanged += new System.EventHandler(this._time_ValueChanged);

      this.animationType_cb.SelectedIndexChanged += new System.EventHandler(this.animationType_SelectedIndexChanged);
      this.animationType_cb.SelectedIndex = 0;

    }

    private void animationType_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Animation();
    }

    private void inout_CheckedChanged(object sender, EventArgs e)
    {
      this.Animation();
    }

    private double _x = 0;
    private void _x_ValueChanged(object sender, EventArgs e)
    {
      this._x = (double)this.x_nud.Value;
      this.Animation();
    }

    private double _amplitude = 0;
    private void _amplitude_ValueChanged(object sender, EventArgs e)
    {
      this._amplitude = (double)this.amplitude_nud.Value;
      this.Animation();
    }

    private double _exponent = 0;
    private void _exponent_ValueChanged(object sender, EventArgs e)
    {
      this._exponent = (double)this.exponent_nud.Value;
      this.Animation();
    }

    private double _power = 0;
    private void _power_ValueChanged(object sender, EventArgs e)
    {
      this._power = (double)this.power_nud.Value;
      this.Animation();
    }

    private double _time = 0.0;
    private void _time_ValueChanged(object sender, EventArgs e)
    {
      this._time = (double)this.time_nud.Value;
    }

    private int _oscillations = 0;
    private void _oscillations_ValueChanged(object sender, EventArgs e)
    {
      this._oscillations = (int)this.oscillations_nud.Value;
      this.Animation();
    }

    private double _springiness = 0.0;
    private void _springiness_ValueChanged(object sender, EventArgs e)
    {
      this._springiness = (double)this.springiness_nud.Value;
      this.Animation();
    }

    private int _bounces = 0;
    private void _bounces_ValueChanged(object sender, EventArgs e)
    {
      this._bounces = (int)this.bounces_nud.Value;
      this.Animation();
    }

    private double _bounciness = 0.0;
    private void _bounciness_ValueChanged(object sender, EventArgs e)
    {
      this._bounciness = (double)this.bounciness_nud.Value;
      this.Animation();
    }

    Point point = new Point(244, 481);
    private void resetbtn_Click(object sender, EventArgs e)
    {
      this.draw.Location = point;
    }

    private bool isrun = false;
    private void startbtn_Click(object sender, EventArgs e)
    {
      if (!this.isrun)
      {
        this.resetbtn_Click(null, null);
        System.Threading.Thread.Sleep(100);
        this.isrun = true;
        this.nowtime = 0;
        this.timer1.Start();
      }
    }

    private double nowtime = 0;
    private void animationTime_Tick(object sender, EventArgs e)
    {
      this.nowtime += this.timer1.Interval;
      if (this.nowtime > (double)this.time_nud.Value)
      {
        this.timer1.Stop();
        this.isrun = false;
        return;
      }

     this.draw.Location = new Point((int)this.AnimationCode(this.point.X, this._x, this.nowtime, this._time), point.Y);
    }

    private void Animation()
    {
      List<PointXY> xylist = new List<PointXY>();
      for (double i = -0.0; i < 1; i += 0.1)
      {
        xylist.Add(new PointXY() { X = i, Y = this.AnimationCode(0, 1, i, 1) });
      }

      chart1.Series["Series1"].Points.Clear();
      this.chart1.ChartAreas["ChartArea1"].AxisX.Minimum = xylist.Min(a => a.X);
      this.chart1.ChartAreas["ChartArea1"].AxisX.Maximum = xylist.Max(a => a.X);
      this.chart1.ChartAreas["ChartArea1"].AxisX.Interval = 0.1;

      this.chart1.ChartAreas["ChartArea1"].AxisY.Minimum = xylist.Min(a => a.Y);
      this.chart1.ChartAreas["ChartArea1"].AxisY.Maximum = xylist.Max(a => a.Y);
      this.chart1.ChartAreas["ChartArea1"].AxisY.Interval = 0.1;

      foreach (PointXY xy in xylist)
      {
        chart1.Series["Series1"].Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(xy.X, xy.Y));
      }
    }

    private double AnimationCode(double origin, double transform, double usedTime, double allTime)
    {
      double result = 0.0;
      switch (animationType_cb.SelectedItem.ToString())
      {
        case "UniformMotion":
          {
            result = AnimationCore.UniformMotion(origin, transform, usedTime, allTime);
            break;
          }
        case "Ease":
          {
            if (in_rb.Checked)
            {
              result = AnimationCore.EaseIn(origin, transform, usedTime, allTime, this._power);
            }
            else if (out_rb.Checked)
            {
              result = AnimationCore.EaseOut(origin, transform, usedTime, allTime, this._power);
            }
            else
            {
              result = AnimationCore.EaseBoth(origin, transform, usedTime, allTime, this._power);
            }
            break;
          }
        case "Back":
          {
            if (in_rb.Checked)
            {
              result = AnimationCore.BackIn(origin, transform, usedTime, allTime, this._power, this._amplitude);
            }
            else if (out_rb.Checked)
            {
              result = AnimationCore.BackOut(origin, transform, usedTime, allTime, this._power, this._amplitude);
            }
            else
            {
              result = AnimationCore.BackBoth(origin, transform, usedTime, allTime, this._power, this._amplitude);
            }
            break;
          }
        case "Bounce":
          {
            if (in_rb.Checked)
            {
              result = AnimationCore.BounceIn(origin, transform, usedTime, allTime, this._bounces, this._bounciness);
            }
            else if (out_rb.Checked)
            {
              result = AnimationCore.BounceOut(origin, transform, usedTime, allTime, this._bounces, this._bounciness);
            }
            else
            {
              result = AnimationCore.BounceBoth(origin, transform, usedTime, allTime, this._bounces, this._bounciness);
            }
            break;
          }
        case "Elastic":
          {
            if (in_rb.Checked)
            {
              result = AnimationCore.ElasticIn(origin, transform, usedTime, allTime, this._oscillations, this._springiness);
            }
            else if (out_rb.Checked)
            {
              result = AnimationCore.ElasticOut(origin, transform, usedTime, allTime, this._oscillations, this._springiness);
            }
            else
            {
              result = AnimationCore.ElasticBoth(origin, transform, usedTime, allTime, this._oscillations, this._springiness);
            }
            break;
          }
        case "Quadratic":
          {
            if (in_rb.Checked)
            {
              result = AnimationCore.QuadraticIn(origin, transform, usedTime, allTime);
            }
            else if (out_rb.Checked)
            {
              result = AnimationCore.QuadraticOut(origin, transform, usedTime, allTime);
            }
            break;
          }
      }
      return result;
    }

    private struct PointXY
    {
      public double X;
      public double Y;
    }

    private void button1_Click(object sender, EventArgs e)
    {

    }

  }

}
