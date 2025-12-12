using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CncApp_Final.Helper
{
    public static class ControlExraInit
    {
        public static void InitGridView(GridView gridView, string formName)
        {

            gridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            gridView.Appearance.HeaderPanel.Options.UseFont = true;
            gridView.Appearance.HeaderPanel.Options.UseTextOptions = true;
            gridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            gridView.ColumnPanelRowHeight = 50;
            gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            //gridView.Name = "gridView";
            gridView.OptionsBehavior.Editable = false;
            gridView.OptionsBehavior.ReadOnly = true;
            //gridView.OptionsFind.AlwaysVisible = true;
            //gridView.OptionsFind.FindDelay = 500;
            gridView.OptionsFind.FindNullPrompt = $"برای جستجو در {formName}، کلمه مورد نظر را وارد کنید...";
            //gridView.OptionsView.ShowGroupPanel = false;
            gridView.RowHeight = 30;
        }

        public static void InitRibonControl(DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl, string ApplicationCaption)
        {
            ribbonControl.ApplicationCaption = ApplicationCaption;
            ribbonControl.OptionsPageCategories.ShowCaptions = false;
            ribbonControl.RibbonCaptionAlignment = DevExpress.XtraBars.Ribbon.RibbonCaptionAlignment.Right;
            ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            ribbonControl.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
            ribbonControl.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            ribbonControl.ShowMoreCommandsButton = DevExpress.Utils.DefaultBoolean.False;
            ribbonControl.ShowToolbarCustomizeItem = false;
            ribbonControl.Toolbar.ShowCustomizeItem = false;
            ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
        }

        public static void InitLookupEdit(LookUpEdit lookUpEdit)
        {
            lookUpEdit.Properties.DropDownItemHeight = 25;
            lookUpEdit.Properties.PopupSizeable = false;
            lookUpEdit.Properties.UseDropDownRowsAsMaxCount = true;
            lookUpEdit.Properties.PopupWidthMode = DevExpress.XtraEditors.PopupWidthMode.UseEditorWidth;
            lookUpEdit.Properties.ShowFooter = false;
            lookUpEdit.Properties.ShowHeader = false;
        }

    }
}
