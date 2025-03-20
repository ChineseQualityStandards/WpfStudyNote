using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfStudyNote.Core.ModelBases
{
    public class RegionViewModelBase : ViewModelBase, INavigationAware, IConfirmNavigationRequest
    {
        #region 属性

        /// <summary>
        /// 区域管理器
        /// </summary>
        protected IRegionManager RegionManager { get; private set; }

        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="regionManager">区域管理器</param>
        public RegionViewModelBase(IRegionManager regionManager)
        {
            RegionManager = regionManager;
        }

        #endregion

        #region 方法

        /// <summary>
        /// 确认导航请求
        /// </summary>
        /// <param name="navigationContext">Prism框架中用于表示导航操作的上下文信息的类，包含有关当前导航状态和目标的信息。</param>
        /// <param name="continuationCallback">接受布尔值并且没有返回值的回调函数</param>
        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            // 如果返回值为true，则继续导航
            continuationCallback?.Invoke(true);
        }

        /// <summary>
        /// 是否是导航目标
        /// </summary>
        /// <param name="navigationContext">Prism框架中用于表示导航操作的上下文信息的类，包含有关当前导航状态和目标的信息。</param>
        /// <returns>是</returns>
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        /// <summary>
        /// 处理导航离开时的逻辑
        /// </summary>
        /// <param name="navigationContext">Prism框架中用于表示导航操作的上下文信息的类，包含有关当前导航状态和目标的信息。</param>
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

        /// <summary>
        /// 处理导航到达时的逻辑
        /// </summary>
        /// <param name="navigationContext">Prism框架中用于表示导航操作的上下文信息的类，包含有关当前导航状态和目标的信息。</param>
        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {

        }

        

        #endregion
    }
}
