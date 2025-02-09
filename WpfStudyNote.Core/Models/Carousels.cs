using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfStudyNote.Core.Models
{
    /// <summary>
    /// 轮播图片的相关属性
    /// </summary>
    public class Carousels : BindableBase
    {
        private string? context;
        /// <summary>
        /// 内容
        /// </summary>
        public string? Context
        {
            get => context;
            set => SetProperty(ref context, value);
        }

        private string? link;
        /// <summary>
        /// 导航链接
        /// </summary>
        public string? Link
        {
            get => link;
            set => SetProperty(ref link, value);
        }

        private string? interval;
        /// <summary>
        /// 播放间隔
        /// </summary>
        public string? Interval
        {
            get => interval;
            set => SetProperty(ref interval, value);
        }

        private string? isPlaying;
        /// <summary>
        /// 是否播放
        /// </summary>
        public string? IsPlaying
        {
            get => isPlaying;
            set => SetProperty(ref isPlaying, value);
        }

        private string? source;
        /// <summary>
        /// 图片链接
        /// </summary>
        public string? Source
        {
            get => source;
            set => SetProperty(ref source,value);
        }

        private string? toolTip;
        /// <summary>
        /// 提示
        /// </summary>
        public string? ToolTip
        {
            get => toolTip;
            set => SetProperty(ref toolTip,value);
        }
    }
}
