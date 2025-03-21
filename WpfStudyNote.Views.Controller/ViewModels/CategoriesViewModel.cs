using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfStudyNote.Core.ModelBases;
using WpfStudyNote.Core.Models;
using WpfStudyNote.Interfaces;

namespace WpfStudyNote.Views.Controller.ViewModels
{
    public class CategoriesViewModel : RegionViewModelBase
    {
        #region 字段


        private readonly IRegionManager _regionManager;
        private readonly IWebApiService<ApiReponse<Categories>, Categories> _categoriesService;

        #endregion

        #region 属性

        private Categories? category;
        /// <summary>
        /// 分类
        /// </summary>
        public Categories? Category
        {
            get { return category; }
            set { SetProperty(ref category, value); }
        }

        private ObservableCollection<Categories>? categories;
        /// <summary>
        /// 分类
        /// </summary>
        public ObservableCollection<Categories>? Categories
        {
            get { return categories; }
            set { SetProperty(ref categories, value); }
        }

                                
        private bool isDialogOpen;
        /// <summary>
        /// 是否打开对话框
        /// </summary>
        public bool IsDialogOpen
        {
            get { return isDialogOpen; }
            set { SetProperty(ref isDialogOpen, value); }
        }


        #endregion

        #region 命令

        public DelegateCommand<object> DeleteCategoryCommand { get; private set; }

        #endregion

        #region 构造函数

        public CategoriesViewModel(IRegionManager regionManager, IWebApiService<ApiReponse<Categories>, Categories> categoriesService) : base(regionManager)
        {
            _regionManager = regionManager;
            _categoriesService = categoriesService;

            Category = new();

            Categories = new();

            Load();

            DeleteCategoryCommand = new DelegateCommand<object>(DeleteCategory);
        }



        #endregion

        #region 方法

        private void DeleteCategory(object switch_on)
        {
            try
            {
                switch (switch_on)
                {
                    case "AddCategory":
                        AddCategory();
                        break;
                    default:
                        Delete(int.Parse(switch_on.ToString()));
                        break;
                }
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
        }


        public async void AddCategory()
        {
            if(Category == null)
            {
                SetMessage("请填写分类信息");
                return;
            }
            if (string.IsNullOrEmpty(Category.CategoryName))
            {
                SetMessage("请填写分类信息");
                return;
            }
            var reponse = await _categoriesService.CreateAsync(Category);
            if(reponse.Code == StatusCode.Created)
            {
                SetMessage("添加成功");
                IsDialogOpen = false;
                Load();
            }
            else
            {
                SetMessage(reponse.Message);
            }
            Category = new();
        }


        public async void Delete(int id)
        {
            try
            {
                var reponse = await _categoriesService.DeleteAsync(id);
                if(reponse.Code == StatusCode.Deleted)
                {
                    SetMessage("删除成功");
                    Load();
                }
                else
                {
                    SetMessage(reponse.Message);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async void Load()
        {
            try
            {
                Categories = await _categoriesService.GetAllAsync();
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
        }


        public void Clear()
        {

        }

        #endregion
    }
}
