
/*****版权***************************************************************

版权：  唧唧复唧唧木兰当户织
作者：  唧唧复唧唧木兰当户织
日期：  2020-10-28
描述：  禁止删除下面的木兰诗,
        博客 https://www.cnblogs.com/tlmbem/ ,
        源码地址 https://gitee.com/tlmbem/hml ,
        授权使用在 https://gitee.com/tlmbem/hml 上有介绍。
	
              	木兰诗
              	
        唧唧复唧唧，木兰当户织。
        不闻机杼声，唯闻女叹息。 
        问女何所思，问女何所忆。
        女亦无所思，女亦无所忆。
        昨夜见军帖，可汗大点兵，
        军书十二卷，卷卷有爷名。
        阿爷无大儿，木兰无长兄，
        愿为市鞍马，从此替爷征。 
        东市买骏马，西市买鞍鞯，
        南市买辔头，北市买长鞭。
        旦辞爷娘去，暮宿黄河边，
        不闻爷娘唤女声，但闻黄河流水鸣溅溅。
        旦辞黄河去，暮至黑山头，
        不闻爷娘唤女声，但闻燕山胡骑鸣啾啾。 
        万里赴戎机，关山度若飞。
        朔气传金柝，寒光照铁衣。
        将军百战死，壮士十年归。 
        归来见天子，天子坐明堂。
        策勋十二转，赏赐百千强。
        可汗问所欲，木兰不用尚书郎，
        愿驰千里足，送儿还故乡。
        爷娘闻女来，出郭相扶将；
        阿姊闻妹来，当户理红妆；
        小弟闻姊来，磨刀霍霍向猪羊。
        开我东阁门，坐我西阁床，
        脱我战时袍，著我旧时裳。
        当窗理云鬓，对镜帖花黄。
        出门看火伴，火伴皆惊忙，
        同行十二年，不知木兰是女郎。 
        
*********************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using WcleAnimationLibrary;
using WinformControlLibraryExtension.Design;

namespace WinformControlLibraryExtension
{
    /// <summary>
    /// 文本跑马灯特效控件
    /// </summary>
    [ToolboxItem(true)]
    [Description("文本跑马灯特效控件")]
    [DefaultProperty("Items")]
    [DefaultEvent("IndexChanged")]
    [Designer(typeof(TextCarouselExtDesigner))]
    public class TextCarouselExt : Control
    {
        #region 新增事件

        public delegate void IndexChangedEventHandler(object sender, IndexChangedEventArgs e);

        private event IndexChangedEventHandler indexChanged;
        /// <summary>
        /// 当前正在播放文本选项索引更改事件
        /// </summary>
        [Description("当前正在播放文本选项索引更改事件")]
        public event IndexChangedEventHandler IndexChanged
        {
            add { this.indexChanged += value; }
            remove { this.indexChanged -= value; }
        }

        #endregion

        #region 停用事件

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler TabIndexChanged
        {
            add { base.TabIndexChanged += value; }
            remove { base.TabIndexChanged -= value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler TabStopChanged
        {
            add { base.TabStopChanged += value; }
            remove { base.TabStopChanged -= value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler TextChanged
        {
            add { base.TextChanged += value; }
            remove { base.TextChanged -= value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler FontChanged
        {
            add { base.FontChanged += value; }
            remove { base.FontChanged -= value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler ForeColorChanged
        {
            add { base.ForeColorChanged += value; }
            remove { base.ForeColorChanged -= value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler RightToLeftChanged
        {
            add { base.RightToLeftChanged += value; }
            remove { base.RightToLeftChanged -= value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler ImeModeChanged
        {
            add { base.ImeModeChanged += value; }
            remove { base.ImeModeChanged -= value; }
        }

        #endregion

        #region 新增属性

        private bool borderShow = false;
        /// <summary>
        ///是否显示边框
        /// </summary>
        [DefaultValue(false)]
        [Description("是否显示边框")]
        public bool BorderShow
        {
            get { return this.borderShow; }
            set
            {
                if (this.borderShow == value)
                    return;
                this.borderShow = value;
                this.Invalidate();
            }
        }

        private Color borderColor = Color.FromArgb(192, 192, 192);
        /// <summary>
        /// 边框颜色
        /// </summary>
        [DefaultValue(typeof(Color), "192, 192, 192")]
        [Description("边框颜色")]
        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public Color BorderColor
        {
            get { return this.borderColor; }
            set
            {
                if (this.borderColor == value)
                    return;
                this.borderColor = value;
                this.Invalidate();
            }
        }

        private int intervalTime = 100;
        /// <summary>
        /// 文本选项轮播的时间间隔
        /// </summary>
        [DefaultValue(100)]
        [Description("文本选项轮播的时间间隔(默认100毫秒)")]
        public int IntervalTime
        {
            get { return this.intervalTime; }
            set
            {
                if (this.intervalTime == value)
                    return;
                this.intervalTime = value;
            }
        }

        int currentIndex = -1;
        /// <summary>
        ///当前正在播放文本选项索引 
        /// </summary>
        [Browsable(false)]
        [DefaultValue(-1)]
        [Description("当前正在播放文本选项索引")]
        public int CurrentIndex
        {
            get { return this.currentIndex; }
            set
            {
                if (this.currentIndex == value || value < 0 || value >= this.enableTextList.Count)
                    return;
                this.currentIndex = value;

                if (!this.DesignMode)
                {
                    this.OnIndexChanged(new IndexChangedEventArgs() { Index = this.currentIndex, Item = this.Items[this.GetEnableTextRealityIndex(this.currentIndex)] });
                }
            }
        }

        private TextItemCollection textItemCollection;
        /// <summary>
        /// 文本选项集合
        /// </summary>
        [DefaultValue(null)]
        [Description("文本选项集合")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TextItemCollection Items
        {
            get
            {
                if (this.textItemCollection == null)
                    this.textItemCollection = new TextItemCollection(this);
                return this.textItemCollection;
            }
        }

        #endregion

        #region 重写属性

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected new bool DesignMode
        {
            get
            {
                if (this.GetService(typeof(IDesignerHost)) != null || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                {
                    return true;   //界面设计模式
                }
                else
                {
                    return false;//运行时模式
                }
            }
        }

        [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
            }
        }

        protected override Padding DefaultPadding
        {
            get
            {
                return new Padding(20, 10, 20, 10);
            }
        }

        protected override Size DefaultSize
        {
            get
            {
                return new Size(300, 60);
            }
        }

        protected override ImeMode DefaultImeMode
        {
            get
            {
                return System.Windows.Forms.ImeMode.Disable;
            }
        }

        #endregion

        #region 停用属性

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new int TabIndex
        {
            get { return 0; }
            set { base.TabIndex = 0; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new bool TabStop
        {
            get { return false; }
            set { base.TabStop = false; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
            }
        }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override RightToLeft RightToLeft
        {
            get
            {
                return base.RightToLeft;
            }
            set
            {
                base.RightToLeft = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ImeMode ImeMode
        {
            get
            {
                return base.ImeMode;
            }
            set
            {
                base.ImeMode = value;
            }
        }

        #endregion

        #region 字段

        /// <summary>
        /// 文本选项轮播的时间间隔累计(-1为动画正在切换中)(-2出现后停留中)
        /// </summary>
        private int intervalTimeValue = 0;
        /// <summary>
        /// 文本选项播放时间间隔定时器
        /// </summary>
        private Timer intervalTimer;
        /// <summary>
        /// 文本选项出现后停留时间累计
        /// </summary>
        private int remainTimeValue = 0;
        /// <summary>
        /// 动画播放定时器
        /// </summary>
        private AnimationTimer animation;

        /// <summary>
        /// 已启用文本索引集合
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private List<int> enableTextList = new List<int>();

        /// <summary>
        /// 控件是否开始播放功能
        /// </summary>
        private bool allowPlay = false;

        #endregion

        public TextCarouselExt()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            this.LoadEnableTextIndex();
            this.InitializeTextRectangles();

            if (!this.DesignMode)
            {
                this.intervalTimer = new Timer();
                this.intervalTimer.Interval = 50;
                this.intervalTimer.Tick += new EventHandler(this.intervalTimer_Tick);

                this.animation = new AnimationTimer(this, new AnimationOptions() { EveryNewTimer = false });
                this.animation.Animationing += new AnimationTimer.AnimationEventHandler(this.animationTimer_Animationing);
                this.animation.AnimationEnding += new AnimationTimer.AnimationEventHandler(this.animationTimer_AnimationEnding);
            }
        }

        #region 重写

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            if (this.enableTextList.Count < 0 || this.CurrentIndex < 0)
            {
                goto border;
            }

            TextItem textItem = this.Items[this.GetEnableTextRealityIndex(this.CurrentIndex)];

            #region Scroll
            if (textItem.Style == AnimationStyle.Scroll)
            {
                if (textItem.TextColorItems.Count < 1)
                {
                    SolidBrush text_sb = new SolidBrush(textItem.TextColor);
                    g.DrawString(textItem.Text, textItem.TextFont, text_sb, textItem.current_rectf);
                    text_sb.Dispose();
                }
                else
                {
                    int len = Math.Max(textItem.TextColorItems.Count, 2);
                    Color[] colors = new Color[len];
                    float[] interval = new float[len];

                    for (int i = 0; i < textItem.TextColorItems.Count; i++)
                    {
                        colors[i] = textItem.TextColorItems[i].Color;
                        interval[i] = textItem.TextColorItems[i].Position;
                    }
                    if (textItem.TextColorItems.Count == 1)
                    {
                        colors[1] = textItem.TextColorItems[0].Color;
                        interval[1] = textItem.TextColorItems[0].Position;
                    }
                    //Positions开始值必须为0,结束值必须为1
                    interval[0] = 0.0f;
                    interval[textItem.TextColorItems.Count - 1] = 1.0f;

                    LinearGradientBrush text_lgb = new LinearGradientBrush(textItem.current_rectf, Color.Transparent, Color.Transparent, textItem.ShadeAngle);
                    text_lgb.InterpolationColors = new ColorBlend() { Colors = colors, Positions = interval };
                    g.DrawString(textItem.Text, textItem.TextFont, text_lgb, textItem.current_rectf);
                    text_lgb.Dispose();
                }
            }
            #endregion
            #region Speed、SpeedSpringback
            else if (textItem.Style == AnimationStyle.Speed || textItem.Style == AnimationStyle.SpeedSpringback)
            {
                if (textItem.TextColorItems.Count < 1)
                {
                    SolidBrush text_sb = new SolidBrush(textItem.TextColor);
                    for (int i = 0; i < textItem.TextChar.Length; i++)
                    {
                        g.DrawString(textItem.TextChar[i], textItem.TextFont, text_sb, textItem.current_char_rectf[i]);
                    }
                    text_sb.Dispose();
                }
                else
                {
                    int len = Math.Max(textItem.TextColorItems.Count, 2);
                    Color[] colors = new Color[len];
                    float[] interval = new float[len];
                    RectangleF text_lgb_rectf = new RectangleF(textItem.current_char_rectf[0].X, textItem.current_char_rectf[0].Y, textItem.current_char_rectf[textItem.TextChar.Length - 1].Right, textItem.current_char_rectf[0].Height);
                    LinearGradientBrush text_lgb = new LinearGradientBrush(text_lgb_rectf, Color.Transparent, Color.Transparent, textItem.ShadeAngle);

                    for (int k = 0; k < textItem.TextChar.Length; k++)
                    {
                        for (int i = 0; i < textItem.TextColorItems.Count; i++)
                        {
                            colors[i] = textItem.TextColorItems[i].Color;
                            interval[i] = textItem.TextColorItems[i].Position;
                        }
                        if (textItem.TextColorItems.Count == 1)
                        {
                            colors[1] = textItem.TextColorItems[0].Color;
                            interval[1] = textItem.TextColorItems[0].Position;
                        }
                        //Positions开始值必须为0,结束值必须为1
                        interval[0] = 0.0f;
                        interval[textItem.TextColorItems.Count - 1] = 1.0f;
                        text_lgb.InterpolationColors = new ColorBlend() { Colors = colors, Positions = interval };

                        g.DrawString(textItem.TextChar[k], textItem.TextFont, text_lgb, textItem.current_char_rectf[k]);
                    }
                    text_lgb.Dispose();
                }
            }
        #endregion

        border:
            #region 边框
            if (this.BorderShow)
            {
                Pen border_pen = new Pen(this.BorderColor, 1);
                g.DrawRectangle(border_pen, this.ClientRectangle.X, this.ClientRectangle.Y, this.ClientRectangle.Width - 1, this.ClientRectangle.Height - 1);

                if (border_pen != null)
                    border_pen.Dispose();
            }

            #endregion
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            this.InitializeTextRectangles();
        }

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.intervalTimer != null)
                    this.intervalTimer.Dispose();
                if (this.animation != null)
                    this.animation.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion

        #region 虚方法

        protected virtual void OnIndexChanged(IndexChangedEventArgs e)
        {
            if (this.indexChanged != null)
            {
                this.indexChanged(this, e);
            }
        }

        #endregion

        #region 公共方法

        /// <summary>
        /// 开始播放
        /// </summary>
        public void Play()
        {
            if (!this.Enabled)
                return;

            if (this.CurrentIndex == -1)
                this.CurrentIndex = 0;

            this.StartIntervalTimer();
        }

        /// <summary>
        /// 指定索引开始播放
        /// </summary>
        /// <param name="index"></param>
        public void Play(int index)
        {
            if (!this.Enabled)
                return;

            this.allowPlay = true;
            this.intervalTimer.Enabled = true;
            this.CurrentIndex = index;
        }

        /// <summary>
        /// 停止播放
        /// </summary>
        public void Stop()
        {
            this.StopIntervalTimer();
        }

        /// <summary>
        /// 获取启用的文本列表中文本真实索引值
        /// </summary>
        /// <param name="index">在启用的文本列表中的索引</param>
        /// <returns></returns>
        public int GetEnableTextRealityIndex(int index)
        {
            if (index < 0 || index >= this.enableTextList.Count)
                return -1;
            return this.enableTextList[index];
        }

        /// <summary>
        /// 获取所有已启用的文本列表索引
        /// </summary>
        public List<int> GetEnableTextsIndex()
        {
            List<int> resultList = new List<int>();
            this.enableTextList.ForEach(a => resultList.Add(a));
            return resultList;
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 动画开始事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void intervalTimer_Tick(object sender, EventArgs e)
        {
            if (this.CurrentIndex < 0)
                return;

            #region 第一步检查动画是否为进行中
            if (this.intervalTimeValue == -1)//动画进行中
                return;
            #endregion

            int index = this.GetEnableTextRealityIndex(this.CurrentIndex);

            #region 第二步检查文本是否为动画完成后停留中
            if (this.intervalTimeValue == -2)//停留中
            {
                this.remainTimeValue += this.intervalTimer.Interval;
                if (this.remainTimeValue < this.Items[index].RemainTime * 1000)
                {
                    return;
                }
                this.remainTimeValue = 0;
                this.intervalTimeValue = 0;
            }
            #endregion

            #region 第三步检查是否要进行重复播放
            if (this.Items[index].CurrentRepetition < this.Items[index].Repetition)
            {
                this.Items[index].CurrentRepetition += 1;
                goto DH;
            }
            else
            {
                this.Items[index].CurrentRepetition = 0;
                this.CurrentIndex = this.ValidTextEnableIndex(this.CurrentIndex + 1);
            }
            #endregion

            #region  第四步检查是否是时间进入下一个文本选项动画播放
            this.intervalTimeValue += this.intervalTimer.Interval;
            if (this.intervalTimeValue < this.IntervalTime)
            {
                return;
            }
            else
            {
                this.Items[this.GetEnableTextRealityIndex(this.CurrentIndex)].CurrentRepetition += 1;
            }
        #endregion

        #region 播放动画
        DH:
            this.intervalTimeValue = -1;
            TextItem textItem = this.Items[this.GetEnableTextRealityIndex(this.CurrentIndex)];
            this.animation.Options.Data = textItem;

            if (textItem.Style == AnimationStyle.Scroll)
            {
                this.animation.AnimationType = AnimationTypes.UniformMotion;
                this.animation.Options.Power = 3;
                this.animation.Options.AllTransformTime = 100f * (textItem.Orientation == AnimationOrientation.Right ? (float)textItem.prev_rectf.Width : (float)textItem.prev_rectf.Height);//动画时间由文字长度决定，速度为每个像素使用50毫秒
            }
            else if (textItem.Style == AnimationStyle.Speed)
            {
                this.animation.AnimationType = AnimationTypes.EaseOut;
                this.animation.Options.AllTransformTime = textItem.TextChar.Length * 100;
                this.animation.Options.AllTransformTime = 1000d;
            }
            else if (textItem.Style == AnimationStyle.SpeedSpringback)
            {
                this.animation.AnimationType = AnimationTypes.BackOut;
                this.animation.Options.Power = 1;
                this.animation.Options.AllTransformTime = 1000d;
            }

            this.animation.Start(AnimationIntervalTypes.Add, 0);
            #endregion
        }

        /// <summary>
        /// 动画进行中事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void animationTimer_Animationing(object sender, AnimationEventArgs e)
        {
            TextItem textItem = (TextItem)e.Data;

            if (textItem.Style == AnimationStyle.Scroll)
            {
                float x = textItem.prev_rectf.X;
                float y = textItem.prev_rectf.Y;
                if (textItem.Orientation == AnimationOrientation.Top || textItem.Orientation == AnimationOrientation.Bottom)
                {
                    y = textItem.prev_rectf.Y + (float)((textItem.target_rectf.Y - textItem.prev_rectf.Y) * e.ProgressValue);
                }
                else if (textItem.Orientation == AnimationOrientation.Right)
                {
                    x = textItem.prev_rectf.X + (float)((textItem.target_rectf.X - textItem.prev_rectf.X) * e.ProgressValue);
                }
                textItem.current_rectf = new RectangleF(x, y, textItem.prev_rectf.Width, textItem.prev_rectf.Height);
            }
            else if (textItem.Style == AnimationStyle.Speed)
            {
                for (int i = 0; i < textItem.TextChar.Length; i++)
                {
                    float x = textItem.prev_char_rectf[i].X;
                    float y = textItem.prev_char_rectf[i].Y;
                    if (textItem.Orientation == AnimationOrientation.Top || textItem.Orientation == AnimationOrientation.Bottom)
                    {
                        y = textItem.prev_char_rectf[i].Y + (float)((textItem.target_char_rectf[i].Y - textItem.prev_char_rectf[i].Y) * e.ProgressValue);
                    }
                    else if (textItem.Orientation == AnimationOrientation.Right)
                    {
                        x = textItem.prev_char_rectf[i].X + (float)((textItem.target_char_rectf[i].X - textItem.prev_char_rectf[i].X) * e.ProgressValue);
                    }
                    textItem.current_char_rectf[i] = new RectangleF(x, y, textItem.prev_char_rectf[i].Width, textItem.prev_char_rectf[i].Height);
                }
            }
            else if (textItem.Style == AnimationStyle.SpeedSpringback)
            {
                for (int i = 0; i < textItem.TextChar.Length; i++)
                {
                    float x = textItem.prev_char_rectf[i].X;
                    float y = textItem.prev_char_rectf[i].Y;
                    if (textItem.Orientation == AnimationOrientation.Top || textItem.Orientation == AnimationOrientation.Bottom)
                    {
                        y = textItem.prev_char_rectf[i].Y + (float)((textItem.target_char_rectf[i].Y - textItem.prev_char_rectf[i].Y) * e.ProgressValue);
                    }
                    else if (textItem.Orientation == AnimationOrientation.Right)
                    {
                        x = textItem.prev_char_rectf[i].X + (float)((textItem.target_char_rectf[i].X - textItem.prev_char_rectf[i].X) * e.ProgressValue);
                    }
                    textItem.current_char_rectf[i] = new RectangleF(x, y, textItem.prev_char_rectf[i].Width, textItem.prev_char_rectf[i].Height);
                }
            }

            this.Invalidate();
        }

        /// <summary>
        /// 动画结束时事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void animationTimer_AnimationEnding(object sender, AnimationEventArgs e)
        {
            this.intervalTimeValue = -2;
        }

        /// <summary>
        /// 加载已启用文本索引集合
        /// </summary>
        internal void LoadEnableTextIndex()
        {
            List<int> old_enableImageList = this.enableTextList;
            List<int> new_enableImageList = new List<int>();
            for (int i = 0; i < this.Items.Count; i++)
            {
                if (this.Items[i].Enable)
                {
                    new_enableImageList.Add(i);
                }
            }
            this.enableTextList = new_enableImageList;
            old_enableImageList.Clear();
        }

        /// <summary>
        /// 初始化播放前每一段文本rect
        /// </summary>
        private void InitializeTextRectangles()
        {
            for (int i = 0; i < this.enableTextList.Count; i++)
            {
                this.InitializeTextRectangle(this.Items[this.enableTextList[i]]);
            }
        }

        /// <summary>
        /// 初始化文本rect
        /// </summary>
        /// <param name="textItem"></param>
        private void InitializeTextRectangle(TextItem textItem)
        {
            Rectangle rect = this.ClientRectangle;
            Size text_size = TextRenderer.MeasureText(textItem.Text, textItem.TextFont, new Size(), TextFormatFlags.ExternalLeading);
            int len = textItem.Text.Length;
            int avg_w = len == 0 ? 0 : text_size.Width / len;

            #region  Scroll
            if (textItem.Style == AnimationStyle.Scroll)
            {
                float x = 0;
                float y = 0;
                float target_x = 0;
                float target_y = 0;
                if (textItem.Orientation == AnimationOrientation.Top)
                {
                    x = rect.X;
                    if (textItem.TextCenter)
                    {
                        x = rect.X + (rect.Width - text_size.Width) / 2;
                        if (x < rect.X)
                            x = rect.X;
                    }
                    y = rect.Y - text_size.Height;

                    target_x = x;
                    target_y = rect.Bottom + text_size.Height;
                }
                else if (textItem.Orientation == AnimationOrientation.Bottom)
                {
                    x = rect.X;
                    if (textItem.TextCenter)
                    {
                        x = rect.X + (rect.Width - text_size.Width) / 2;
                        if (x < rect.X)
                            x = rect.X;
                    }
                    y = rect.Bottom;

                    target_x = x;
                    target_y = rect.Y - text_size.Height;
                }
                else if (textItem.Orientation == AnimationOrientation.Right)
                {
                    x = rect.Right;
                    y = (rect.Height - text_size.Height) / 2;

                    target_x = rect.X - text_size.Width;
                    target_y = y;
                }

                textItem.prev_rectf = new RectangleF(x, y, text_size.Width, text_size.Height);
                textItem.current_rectf = textItem.prev_rectf;
                textItem.target_rectf = new RectangleF(target_x, target_y, text_size.Width, text_size.Height);
            }
            #endregion
            #region Speed
            else if (textItem.Style == AnimationStyle.Speed)
            {
                textItem.TextCharAvgWidth = text_size.Width / len;

                textItem.TextChar = new string[len];
                textItem.prev_char_rectf = new RectangleF[len];
                textItem.current_char_rectf = new RectangleF[len];
                textItem.target_char_rectf = new RectangleF[len];
                for (int i = 0; i < len; i++)
                {
                    float x = 0;
                    float y = 0;
                    float target_x = 0;
                    float target_y = 0;
                    if (textItem.Orientation == AnimationOrientation.Top)
                    {
                        float tmp_x = rect.X + i * avg_w;
                        x = tmp_x;
                        if (textItem.TextCenter)
                        {
                            x = tmp_x + (rect.Width - text_size.Width) / 2;
                            if (x < tmp_x)
                                x = tmp_x;
                        }
                        y = rect.Y - i * text_size.Height;

                        target_x = x;
                        target_y = (rect.Height - text_size.Height) / 2;
                    }
                    else if (textItem.Orientation == AnimationOrientation.Bottom)
                    {
                        float tmp_x = rect.X + i * avg_w;
                        x = tmp_x;
                        if (textItem.TextCenter)
                        {
                            x = tmp_x + (rect.Width - text_size.Width) / 2;
                            if (x < tmp_x)
                                x = tmp_x;
                        }
                        y = rect.Bottom + i * text_size.Height;

                        target_x = x;
                        target_y = (rect.Height - text_size.Height) / 2;
                    }
                    else if (textItem.Orientation == AnimationOrientation.Right)
                    {
                        x = rect.Right + i * rect.Width;
                        y = (rect.Height - text_size.Height) / 2;

                        target_x = rect.X + i * avg_w;
                        target_y = y;
                    }

                    textItem.TextChar[i] = textItem.Text.Substring(i, 1);
                    textItem.prev_char_rectf[i] = new RectangleF(x, y, avg_w, text_size.Height);
                    textItem.current_char_rectf[i] = textItem.prev_char_rectf[i];
                    textItem.target_char_rectf[i] = new RectangleF(target_x, target_y, avg_w, text_size.Height);
                }
            }
            #endregion
            #region SpeedSpringback
            else if (textItem.Style == AnimationStyle.SpeedSpringback)
            {
                textItem.TextCharAvgWidth = text_size.Width / len;

                textItem.TextChar = new string[len];
                textItem.prev_char_rectf = new RectangleF[len];
                textItem.current_char_rectf = new RectangleF[len];
                textItem.target_char_rectf = new RectangleF[len];
                for (int i = 0; i < len; i++)
                {
                    float x = 0;
                    float y = 0;
                    float target_x = 0;
                    float target_y = 0;
                    if (textItem.Orientation == AnimationOrientation.Top)
                    {
                        float tmp_x = rect.X + i * avg_w;
                        x = tmp_x;
                        if (textItem.TextCenter)
                        {
                            x = tmp_x + (rect.Width - text_size.Width) / 2;
                            if (x < tmp_x)
                                x = tmp_x;
                        }
                        y = rect.Y - text_size.Height - text_size.Height - text_size.Height / 2;

                        target_x = x;
                        target_y = (rect.Height - text_size.Height) / 2;
                    }
                    else if (textItem.Orientation == AnimationOrientation.Bottom)
                    {
                        float tmp_x = rect.X + i * avg_w;
                        x = tmp_x;
                        if (textItem.TextCenter)
                        {
                            x = tmp_x + (rect.Width - text_size.Width) / 2;
                            if (x < tmp_x)
                                x = tmp_x;
                        }
                        y = rect.Bottom + text_size.Height + text_size.Height / 2;

                        target_x = x;
                        target_y = (rect.Height - text_size.Height) / 2;
                    }
                    else if (textItem.Orientation == AnimationOrientation.Right)
                    {
                        x = rect.Right + i * avg_w * 3;
                        y = (rect.Height - text_size.Height) / 2;

                        target_x = rect.X + i * avg_w;
                        target_y = y;
                    }

                    textItem.TextChar[i] = textItem.Text.Substring(i, 1);
                    textItem.prev_char_rectf[i] = new RectangleF(x, y, avg_w, text_size.Height);
                    textItem.current_char_rectf[i] = textItem.prev_char_rectf[i];
                    textItem.target_char_rectf[i] = new RectangleF(target_x, target_y, avg_w, text_size.Height);
                }
            }
            #endregion

        }

        /// <summary>
        /// 获取验证后文本在已启用文本列表的索引
        /// </summary>
        /// <param name="index">已启用图片列表的索引</param>
        /// <returns></returns>
        private int ValidTextEnableIndex(int index)
        {
            while (index >= this.enableTextList.Count)
                index -= this.enableTextList.Count;
            while (index < 0)
                index += this.enableTextList.Count;
            return index;
        }

        /// <summary>
        /// 开始动画间隔定时器
        /// </summary>
        private void StartIntervalTimer()
        {
            if (!this.allowPlay)
            {
                this.allowPlay = true;
                this.intervalTimer.Enabled = true;
                this.intervalTimeValue = -2;
            }
        }

        /// <summary>
        /// 停止动画间隔定时器
        /// </summary>
        private void StopIntervalTimer()
        {
            if (this.allowPlay)
            {
                this.allowPlay = false;
                this.intervalTimer.Enabled = false;
                this.intervalTimeValue = -2;
            }
        }

        #endregion

        #region 类

        /// <summary>
        /// 文本选项集合
        /// </summary>
        [Description("文本选项集合")]
        [Editor(typeof(CollectionEditorExt), typeof(UITypeEditor))]
        public class TextItemCollection : IList, ICollection, IEnumerable
        {
            private ArrayList textItemList = new ArrayList();
            private TextCarouselExt owner;

            public TextItemCollection(TextCarouselExt owner)
            {
                this.owner = owner;
            }

            #region IEnumerable

            public IEnumerator GetEnumerator()
            {
                TextItem[] listArray = new TextItem[this.textItemList.Count];
                for (int index = 0; index < listArray.Length; ++index)
                {
                    listArray[index] = (TextItem)this.textItemList[index];
                }
                return listArray.GetEnumerator();
            }

            #endregion

            #region ICollection

            public void CopyTo(Array array, int index)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    array.SetValue(this.textItemList[i], i + index);
                }
            }

            public int Count
            {
                get
                {
                    return this.textItemList.Count;
                }
            }

            public bool IsSynchronized
            {
                get
                {
                    return false;
                }
            }

            public object SyncRoot
            {
                get
                {
                    return (object)this;
                }
            }

            #endregion

            #region IList

            public int Add(object value)
            {
                if (!(value is TextItem))
                {
                    throw new ArgumentException("TextItem");
                }
                return this.Add((TextItem)value);
            }

            public int Add(TextItem item)
            {
                if (item == null)
                {
                    throw new ArgumentNullException("item");
                }
                item.owner = owner;
                this.textItemList.Add(item);
                if (item.Enable)
                {
                    this.owner.LoadEnableTextIndex();
                }
                this.owner.InitializeTextRectangle(item);
                this.owner.Invalidate();
                return this.Count - 1;
            }

            public void Clear()
            {
                this.textItemList.Clear();
                this.owner.LoadEnableTextIndex();
                this.owner.Invalidate();
            }

            public bool Contains(object value)
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                return this.IndexOf(value) != -1;
            }

            bool IList.Contains(object item)
            {
                if (item is TextItem)
                {
                    return this.Contains((TextItem)item);
                }
                return false;
            }

            public int IndexOf(object item)
            {
                if (item is TextItem)
                {
                    return this.textItemList.IndexOf(item);
                }
                return -1;
            }

            public void Insert(int index, object value)
            {
                throw new NotImplementedException();
            }

            public bool IsFixedSize
            {
                get { return false; }
            }

            public bool IsReadOnly
            {
                get { return false; }
            }

            public void Remove(object value)
            {
                if (!(value is TextItem))
                {
                    throw new ArgumentException("TextItem");
                }
                this.Remove((TextItem)value);
            }

            public void Remove(TextItem item)
            {
                this.textItemList.Remove((TextItem)item);
                this.owner.LoadEnableTextIndex();
                this.owner.Invalidate();
            }

            public void RemoveAt(int index)
            {
                this.textItemList.RemoveAt(index);
                this.owner.LoadEnableTextIndex();
                this.owner.Invalidate();
            }

            public TextItem this[int index]
            {
                get
                {
                    return (TextItem)this.textItemList[index];
                }
                set
                {
                    this.textItemList[index] = (TextItem)value;
                }
            }

            object IList.this[int index]
            {
                get
                {
                    return (object)this.textItemList[index];
                }
                set
                {
                    this.textItemList[index] = (TextItem)value;
                }
            }

            #endregion

        }

        /// <summary>
        /// 渐变颜色选项集合
        /// </summary>
        [Description("渐变颜色选项集合")]
        [Editor(typeof(CollectionEditorExt), typeof(UITypeEditor))]
        public class ColorItemCollection : IList, ICollection, IEnumerable
        {
            private ArrayList colorItemList = new ArrayList();

            public ColorItemCollection()
            {

            }

            #region IEnumerable

            public IEnumerator GetEnumerator()
            {
                ColorItem[] listArray = new ColorItem[this.colorItemList.Count];
                for (int index = 0; index < listArray.Length; ++index)
                {
                    listArray[index] = (ColorItem)this.colorItemList[index];
                }
                return listArray.GetEnumerator();
            }

            #endregion

            #region ICollection

            public void CopyTo(Array array, int index)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    array.SetValue(this.colorItemList[i], i + index);
                }
            }

            public int Count
            {
                get
                {
                    return this.colorItemList.Count;
                }
            }

            public bool IsSynchronized
            {
                get
                {
                    return false;
                }
            }

            public object SyncRoot
            {
                get
                {
                    return (object)this;
                }
            }

            #endregion

            #region IList

            public int Add(object value)
            {
                if (!(value is ColorItem))
                {
                    throw new ArgumentException("ColorItem");
                }
                return this.Add((ColorItem)value);
            }

            public int Add(ColorItem item)
            {
                if (item == null)
                {
                    throw new ArgumentNullException("item");
                }
                this.colorItemList.Add(item);
                return this.Count - 1;
            }

            public void Clear()
            {
                this.colorItemList.Clear();
            }

            public bool Contains(object value)
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                return this.IndexOf(value) != -1;
            }

            bool IList.Contains(object item)
            {
                if (item is ColorItem)
                {
                    return this.Contains((ColorItem)item);
                }
                return false;
            }

            public int IndexOf(object item)
            {
                if (item is ColorItem)
                {
                    return this.colorItemList.IndexOf(item);
                }
                return -1;
            }

            public void Insert(int index, object value)
            {
                throw new NotImplementedException();
            }

            public bool IsFixedSize
            {
                get { return false; }
            }

            public bool IsReadOnly
            {
                get { return false; }
            }

            public void Remove(object value)
            {
                if (!(value is ColorItem))
                {
                    throw new ArgumentException("ColorItem");
                }
                this.Remove((ColorItem)value);
            }

            public void Remove(ColorItem item)
            {
                this.colorItemList.Remove((ColorItem)item);
            }

            public void RemoveAt(int index)
            {
                this.colorItemList.RemoveAt(index);
            }

            public ColorItem this[int index]
            {
                get
                {
                    return (ColorItem)this.colorItemList[index];
                }
                set
                {
                    this.colorItemList[index] = (ColorItem)value;
                }
            }

            object IList.this[int index]
            {
                get
                {
                    return (object)this.colorItemList[index];
                }
                set
                {
                    this.colorItemList[index] = (ColorItem)value;
                }
            }

            #endregion

        }

        /// <summary>
        /// 文本选项
        /// </summary>
        [Description("文本选项")]
        public class TextItem
        {
            internal TextCarouselExt owner;

            private bool enable = true;
            /// <summary>
            /// 文本选项是否参与轮播
            /// </summary>
            [DefaultValue(true)]
            [Description("文本选项是否参与轮播")]
            public bool Enable
            {
                get { return this.enable; }
                set
                {
                    if (this.enable == value)
                        return;
                    this.enable = value;
                    if (this.owner != null)
                    {
                        this.owner.LoadEnableTextIndex();
                    }
                }
            }

            private AnimationStyle style = AnimationStyle.Scroll;
            /// <summary>
            /// 动画方式
            /// </summary>
            [DefaultValue(AnimationStyle.Scroll)]
            [Description("动画方式")]
            public AnimationStyle Style
            {
                get { return this.style; }
                set
                {
                    if (this.style == value)
                        return;
                    this.style = value;
                }
            }

            private AnimationOrientation orientation = AnimationOrientation.Right;
            /// <summary>
            /// 动画出现方向
            /// </summary>
            [DefaultValue(AnimationOrientation.Right)]
            [Description("动画出现方向")]
            public AnimationOrientation Orientation
            {
                get { return this.orientation; }
                set
                {
                    if (this.orientation == value)
                        return;
                    this.orientation = value;
                }
            }

            private int remainTime = 0;
            /// <summary>
            /// 文本选项出现后停留时间(默认0秒)
            /// </summary>
            [DefaultValue(0)]
            [Description("文本选项出现后停留时间(默认0秒)")]
            public int RemainTime
            {
                get { return this.remainTime; }
                set
                {
                    if (this.remainTime == value || value < 0)
                        return;
                    this.remainTime = value;
                }
            }

            private int repetition = 1;
            /// <summary>
            /// 文本选项在单次循环轮播中重复次数(默认1次)
            /// </summary>
            [DefaultValue(1)]
            [Description("文本选项在单次循环轮播中重复次数(默认1次)")]
            public int Repetition
            {
                get { return this.repetition; }
                set
                {
                    if (this.repetition == value || value < 1)
                        return;
                    this.repetition = value;
                }
            }

            private string text = "";
            /// <summary>
            /// 文本
            /// </summary>
            [DefaultValue("")]
            [Description("文本字体")]
            public string Text
            {
                get { return this.text; }
                set
                {
                    if (this.text == value)
                        return;
                    this.text = value;
                }
            }

            private string[] textChar = null;
            /// <summary>
            /// 文本每个字符集合
            [Browsable(false)]
            [DefaultValue(null)]
            [Description("文本每个字符集合")]
            public string[] TextChar
            {
                get { return this.textChar; }
                set
                {
                    this.textChar = value;
                }
            }

            private float textCharAvgWidth = 0f;
            /// <summary>
            /// 文本每个字符平均宽度
            [Browsable(false)]
            [DefaultValue(0f)]
            [Description("文本每个字符平均宽度")]
            public float TextCharAvgWidth
            {
                get { return this.textCharAvgWidth; }
                set
                {
                    this.textCharAvgWidth = value;
                }
            }

            private bool textCenter = false;

            /// <summary>
            /// 文本是否水平居中(仅限垂直动画)
            /// </summary>
            [DefaultValue(false)]
            [Description("文本是否水平居中(仅限垂直动画)")]
            public bool TextCenter
            {
                get { return this.textCenter; }
                set
                {
                    this.textCenter = value;
                }
            }

            private Font textFont = new Font("宋体", 20);
            /// <summary>
            /// 文本字体
            /// </summary>
            [DefaultValue(typeof(Font), "宋体, 20pt")]
            [Description("文本字体")]
            public Font TextFont
            {
                get { return this.textFont; }
                set
                {
                    if (this.textFont == value)
                        return;
                    this.textFont = value;
                }
            }

            private Color textColor = Color.FromArgb(154, 205, 50);
            /// <summary>
            /// 文本颜色
            /// </summary>
            [DefaultValue(typeof(Color), "154, 205, 50")]
            [Description("文本颜色")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            public Color TextColor
            {
                get { return this.textColor; }
                set
                {
                    if (this.textColor == value)
                        return;
                    this.textColor = value;
                }
            }

            private ColorItemCollection shadeColorItemCollection;
            /// <summary>
            /// 渐变颜色选项集合
            /// </summary>
            [DefaultValue(null)]
            [Description("渐变颜色选项集合")]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
            public ColorItemCollection TextColorItems
            {
                get
                {
                    if (this.shadeColorItemCollection == null)
                        this.shadeColorItemCollection = new ColorItemCollection();
                    return this.shadeColorItemCollection;
                }
            }

            private float shadeAngle = 0f;
            /// <summary>
            /// 渐变方向线的角度（从 X 轴以顺时针角度计算）
            /// </summary>
            [DefaultValue(0f)]
            [Description("渐变方向线的角度（从 X 轴以顺时针角度计算）")]
            public float ShadeAngle
            {
                get { return this.shadeAngle; }
                set
                {
                    if (this.shadeAngle == value || value < 0f || value > 360f)
                        return;
                    this.shadeAngle = value;
                }
            }

            private int currentRepetition = 0;
            /// <summary>
            /// 文本选项在单次循环轮播中当前的重复次数
            /// </summary>
            [Browsable(false)]
            [DefaultValue(0)]
            [Description("文本选项在单次循环轮播中当前的重复次数")]
            public int CurrentRepetition
            {
                get { return this.currentRepetition; }
                set
                {
                    if (this.currentRepetition == value)
                        return;
                    this.currentRepetition = value;
                }
            }

            /// <summary>
            /// 运动前rectf
            /// </summary>
            [Browsable(false)]
            [Description("运动前rectf")]
            public RectangleF prev_rectf { get; set; }

            /// <summary>
            /// 目标rectf
            /// </summary>
            [Browsable(false)]
            [Description("目标rectf")]
            public RectangleF target_rectf { get; set; }

            /// <summary>
            /// 当前rectf
            /// </summary>
            [Browsable(false)]
            [Description("当前rectf")]
            public RectangleF current_rectf { get; set; }

            /// <summary>
            /// 运动前每个字的rectf
            /// </summary>
            [Browsable(false)]
            [Description("运动前rectf")]
            public RectangleF[] prev_char_rectf { get; set; }

            /// <summary>
            /// 目标每个字rectf
            /// </summary>
            [Browsable(false)]
            [Description("目标每个字rectf")]
            public RectangleF[] target_char_rectf { get; set; }

            /// <summary>
            /// 当前每个字的rectf
            /// </summary>
            [Browsable(false)]
            [Description("当前rectf")]
            public RectangleF[] current_char_rectf { get; set; }

        }

        /// <summary>
        /// 渐变颜色选项
        /// </summary>
        [Description("渐变颜色选项")]
        public class ColorItem
        {

            private float position = 0f;
            /// <summary>
            /// 渐变值0-1
            /// </summary>
            [DefaultValue(0f)]
            [Description("渐变值0-1")]
            public float Position
            {
                get { return this.position; }
                set
                {
                    if (this.position == value || value < 0 || value > 1)
                        return;
                    this.position = value;
                }
            }

            private Color color = Color.Empty;
            /// <summary>
            /// 渐变值对应渐变颜色
            /// </summary>
            [DefaultValue(typeof(Color), "Empty")]
            [Description("渐变值对应渐变颜色")]
            [Editor(typeof(ColorEditorExt), typeof(UITypeEditor))]
            public Color Color
            {
                get { return this.color; }
                set
                {
                    if (this.color == value)
                        return;
                    this.color = value;
                }
            }

        }

        /// <summary>
        /// 当前正在播放文本选项索引更改事件参数
        /// </summary>
        [Description("当前正在播放文本选项索引更改事件参数")]
        public class IndexChangedEventArgs : EventArgs
        {
            /// <summary>
            /// 当前正在播放文本选项索引
            /// </summary>
            [Description("当前正在播放文本选项索引")]
            public float Index { get; set; }

            /// <summary>
            /// 当前正在播放文本选项
            /// </summary>
            [Description("当前正在播放文本选项")]
            public TextItem Item { get; set; }
        }

        #endregion

        #region 枚举

        /// <summary>
        /// 动画方式
        /// </summary>
        [Description("动画方式")]
        public enum AnimationStyle
        {
            /// <summary>
            /// 普通滚动
            /// </summary>
            Scroll,
            /// <summary>
            /// 减速
            /// </summary>
            Speed,
            /// <summary>
            /// 减速回弹
            /// </summary>
            SpeedSpringback
        }

        /// <summary>
        /// 动画出现方向
        /// </summary>
        [Description("动画出现方向")]
        public enum AnimationOrientation
        {
            /// <summary>
            ///从上边出现
            /// </summary>
            Top,
            /// <summary>
            /// 从下边出现
            /// </summary>
            Bottom,
            /// <summary>
            /// 从右边出现
            /// </summary>
            Right
        }

        #endregion
    }
}
