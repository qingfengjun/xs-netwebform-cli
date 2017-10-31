//****************************************************************************************
//作者：轻狂书生
//博客地址：http://www.cnblogs.com/xiaoshuai1992
//create: 2014/5/5
//功能：分页控件的实现
//使用方法：正常控件使用方法
//*****************************************************************************************


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.ComponentModel;
[assembly: TagPrefix("XsFramework", "xs")]
namespace xsFramework.UserControl.Pager
{
    /// <summary>
    /// 传递当前页数
    /// </summary>
    public class PageChangedEventArgs : EventArgs
    {
        private int ICurrentPage = 1;
        public int CurrentPage
        {
            get { return ICurrentPage; }
            set
            {
                if (value <= 0) value = 1;
                ICurrentPage = value;
            }
        }
        public PageChangedEventArgs(int curPage)
        {
            CurrentPage = curPage;
        }
    }
    public delegate void PageChangedEvent(object sender, PageChangedEventArgs e);
    public class xsPageControl : Control, IPostBackEventHandler
    {
        #region 属性
        string _preText = "上一页";
        string _nextText = "下一页";
        string _totalText = "共{0}笔";
        bool _totalVisable = false;//由于存在尾页号，总页数不是必须，故这里我设置默认为不打开
        bool _preNextVisable = true;
        int _pageSize = 10;
        string _css = "xsPage";
        string _selectCss = "xsSelect";
        bool _cssEnable = true;
        int ITotalCount = 0;


        [Category("Text")]
        public string PreText
        {
            get { return _preText; }
            set { _preText = value; }
        }
        [Category("Text")]
        public string NextText
        {
            get { return _nextText; }
            set { _nextText = value; }
        }
        [Category("Text")]
        public string TotalText
        {
            get { return _totalText; }
            set { _totalText = value; }
        }
        [Category("Text")]
        public bool TotalVisable
        {
            get { return _totalVisable; }
            set { _totalVisable = value; }
        }
        [Category("Text")]
        public bool PreNextVisable
        {
            get { return _preNextVisable; }
            set { _preNextVisable = value; }
        }

        [Category("Size")]
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }
        [Category("CSS")]
        public string Css
        {
            get { return _css; }
            set { _css = value; }
        }
        [Category("CSS")]
        public string SelectCss
        {
            get { return _selectCss; }
            set { _selectCss = value; }
        }
        [Category("CSS")]
        /// <summary>
        /// 是否使用默认CSS,自定义CSS无效
        /// </summary>
        public bool CssEnable
        {
            get { return _cssEnable; }
            set { _cssEnable = value; }
        }
        [Browsable(false)]
        public int CurrentPage
        {
            get { return Convert.ToInt32(ViewState[UniqueID + "xsCurrentPage"] == null ? 1 : ViewState[UniqueID + "xsCurrentPage"]); }
            set { ViewState[UniqueID + "xsCurrentPage"] = value; }
        }
        [Browsable(false)]
        public int TotalPage
        {
            get
            {
                int tpage = 0;
                if (PageSize > 0)
                {
                    tpage = (TotalCount % PageSize == 0 ? TotalCount / PageSize : TotalCount / PageSize + 1);
                }
                return tpage;

            }
        }
        [Browsable(false)]
        public int TotalCount
        {
            get { return ITotalCount; }
            set { ITotalCount = value; }
        }
        #endregion

        public event PageChangedEvent PageChanged;

        #region 效果呈现
        public override void RenderControl(HtmlTextWriter writer)
        {
            Render(writer);
        }

        protected override void Render(HtmlTextWriter writer)
        {
            if (DesignMode)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Id, this.ClientID);
                writer.AddAttribute(HtmlTextWriterAttribute.Name, this.UniqueID);
                writer.AddAttribute(HtmlTextWriterAttribute.Class, Css);
                writer.RenderBeginTag(HtmlTextWriterTag.Div);

                if (TotalVisable)
                {
                    writer.RenderBeginTag(HtmlTextWriterTag.Span);
                    writer.Write(string.Format(TotalText, 0));
                    writer.RenderEndTag();
                    writer.Write("&nbsp;&nbsp;");
                }
                if (PreNextVisable)
                {
                    writer.AddAttribute(HtmlTextWriterAttribute.Href, "#");
                    writer.RenderBeginTag(HtmlTextWriterTag.A);
                    writer.Write(PreText);
                    writer.RenderEndTag();
                    writer.Write("&nbsp;&nbsp;");
                }
                for (int i = 1; i <= 5; i++)
                {
                    writer.AddAttribute(HtmlTextWriterAttribute.Href, "#");
                    writer.RenderBeginTag(HtmlTextWriterTag.A);
                    writer.Write(i.ToString());
                    writer.RenderEndTag();
                    writer.Write("&nbsp;&nbsp;");
                }
                if (PreNextVisable)
                {
                    writer.AddAttribute(HtmlTextWriterAttribute.Href, "#");
                    writer.RenderBeginTag(HtmlTextWriterTag.A);
                    writer.Write(NextText);
                    writer.RenderEndTag();
                    writer.Write("&nbsp;&nbsp;");
                }
                writer.RenderEndTag();
            }
            else
            {
                if (TotalPage > 1)
                {
                    writer.AddAttribute(HtmlTextWriterAttribute.Id, this.ClientID);
                    writer.AddAttribute(HtmlTextWriterAttribute.Name, this.UniqueID);
                    writer.AddAttribute(HtmlTextWriterAttribute.Class, Css);
                    writer.RenderBeginTag(HtmlTextWriterTag.Div);

                    if (TotalVisable)
                    {
                        writer.RenderBeginTag(HtmlTextWriterTag.Span);
                        writer.Write(string.Format(TotalText, ITotalCount));
                        writer.RenderEndTag();
                    }
                    if (PreNextVisable && CurrentPage != 1)
                    {
                        writer.AddAttribute(HtmlTextWriterAttribute.Href, "javascript:" + Page.ClientScript.GetPostBackEventReference(this, CurrentPage - 1 + ""));
                        writer.RenderBeginTag(HtmlTextWriterTag.A);
                        writer.Write(PreText);
                        writer.RenderEndTag();
                    }
                    if (TotalPage <= 10)
                    {
                        for (int i = 1; i <= TotalPage; i++)
                        {
                            if (i == CurrentPage)
                            {
                                //添加当前选择的样式
                                writer.AddAttribute(HtmlTextWriterAttribute.Class, SelectCss);
                            }
                            writer.AddAttribute(HtmlTextWriterAttribute.Href, "javascript:" + Page.ClientScript.GetPostBackEventReference(this, i + ""));
                            writer.RenderBeginTag(HtmlTextWriterTag.A);
                            writer.Write(i.ToString());
                            writer.RenderEndTag();
                        }
                    }
                    else
                    {
                        if (CurrentPage - 5 > 2 && CurrentPage + 7 < TotalPage)//前后都有的
                        {
                            //添加第一页
                            writer.AddAttribute(HtmlTextWriterAttribute.Href, "javascript:" + Page.ClientScript.GetPostBackEventReference(this, 1 + ""));
                            writer.RenderBeginTag(HtmlTextWriterTag.A);
                            writer.Write("1");
                            writer.RenderEndTag();

                            writer.RenderBeginTag(HtmlTextWriterTag.Span);
                            writer.Write("…");
                            writer.RenderEndTag();

                            for (int i = CurrentPage - 5; i <= CurrentPage + 5; i++)
                            {
                                if (i == CurrentPage)
                                {
                                    //添加当前选择的样式
                                    writer.AddAttribute(HtmlTextWriterAttribute.Class, SelectCss);
                                }
                                writer.AddAttribute(HtmlTextWriterAttribute.Href, "javascript:" + Page.ClientScript.GetPostBackEventReference(this, i + ""));
                                writer.RenderBeginTag(HtmlTextWriterTag.A);
                                writer.Write(i.ToString());
                                writer.RenderEndTag();
                            }
                            //添加最后一页
                            writer.RenderBeginTag(HtmlTextWriterTag.Span);
                            writer.Write("…");
                            writer.RenderEndTag();
                            writer.AddAttribute(HtmlTextWriterAttribute.Href, "javascript:" + Page.ClientScript.GetPostBackEventReference(this, TotalPage + ""));
                            writer.RenderBeginTag(HtmlTextWriterTag.A);
                            writer.Write(TotalPage.ToString());
                            writer.RenderEndTag();
                        }
                        else if (CurrentPage - 5 <= 2)//前面不够，后面有多余
                        {
                            for (int i = 1; i <= 10; i++)
                            {
                                if (i == CurrentPage)
                                {
                                    //添加当前选择的样式
                                    writer.AddAttribute(HtmlTextWriterAttribute.Class, SelectCss);
                                }
                                writer.AddAttribute(HtmlTextWriterAttribute.Href, "javascript:" + Page.ClientScript.GetPostBackEventReference(this, i + ""));
                                writer.RenderBeginTag(HtmlTextWriterTag.A);
                                writer.Write(i.ToString());
                                writer.RenderEndTag();
                            }
                            //添加最后一页
                            writer.RenderBeginTag(HtmlTextWriterTag.Span);
                            writer.Write("…");
                            writer.RenderEndTag();
                            writer.AddAttribute(HtmlTextWriterAttribute.Href, "javascript:" + Page.ClientScript.GetPostBackEventReference(this, TotalPage + ""));
                            writer.RenderBeginTag(HtmlTextWriterTag.A);
                            writer.Write(TotalPage.ToString());
                            writer.RenderEndTag();

                        }
                        else if (CurrentPage + 7 >= TotalPage)//前面多余，后面不足
                        {
                            //添加第一页
                            writer.AddAttribute(HtmlTextWriterAttribute.Href, "javascript:" + Page.ClientScript.GetPostBackEventReference(this, 1 + ""));
                            writer.RenderBeginTag(HtmlTextWriterTag.A);
                            writer.Write("1");
                            writer.RenderEndTag();
                            writer.RenderBeginTag(HtmlTextWriterTag.Span);
                            writer.Write("…");
                            writer.RenderEndTag();
                            for (int i = TotalPage - 10; i <= TotalPage; i++)
                            {
                                if (i == CurrentPage)
                                {
                                    //添加当前选择的样式
                                    writer.AddAttribute(HtmlTextWriterAttribute.Class, SelectCss);
                                }
                                writer.AddAttribute(HtmlTextWriterAttribute.Href, "javascript:" + Page.ClientScript.GetPostBackEventReference(this, i + ""));
                                writer.RenderBeginTag(HtmlTextWriterTag.A);
                                writer.Write(i.ToString());
                                writer.RenderEndTag();
                            }
                        }


                    }
                    if (PreNextVisable && CurrentPage != TotalPage && TotalPage > 1)
                    {
                        writer.AddAttribute(HtmlTextWriterAttribute.Href, "javascript:" + Page.ClientScript.GetPostBackEventReference(this, CurrentPage + 1 + ""));
                        writer.RenderBeginTag(HtmlTextWriterTag.A);
                        writer.Write(NextText);
                        writer.RenderEndTag();
                    }
                    writer.RenderEndTag();
                }
            }
        }

        #endregion

        /// <summary>
        /// 设置翻页
        /// </summary>
        /// <param name="gotoPage"></param>
        protected virtual void OnPageChanged(int gotoPage)
        {

            PageChangedEventArgs e = new PageChangedEventArgs(gotoPage);
            if (this.PageChanged != null)
            {
                PageChanged(this, e);

                CurrentPage = gotoPage;

                if (TotalPage < CurrentPage)
                { //删除的特殊情况
                    OnPageChanged(TotalPage);
                }
            }
        }
        public void RaisePostBackEvent(string eventArgument)
        {
            int gotopage = Convert.ToInt32(eventArgument);
            OnPageChanged(gotopage);
        }

        /// <summary>
        /// 第一次进入页面需要显示调用
        /// </summary>
        public void StartShowPage()
        {
            OnPageChanged(1);
        }
        /// <summary>
        /// 删除或更新后可以直接刷新
        /// </summary>
        public void RefreshPage()
        {
            OnPageChanged(CurrentPage);
        }
    }
}