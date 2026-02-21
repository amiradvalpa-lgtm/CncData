using CncApp_Final.Data;
using CncApp_Final.Entities;
using CncApp_Final.Helper;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CncApp_Final.UserControl
{
    public partial class SheetSelector : XtraUserControl
    {
        #region Events

        public delegate void SheetIdHandler(object sender, EventArgs e);
        public event SheetIdHandler EditValueChanged;

        protected virtual void OnEditValueChanged()
        {
            EditValueChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion


        #region Public Properties

        [Browsable(true)]
        [Bindable(true)]
        [DefaultValue(null)]
        public object EditValue
        {
            get => lkpSheetId?.EditValue;
            set
            {
                if (DesignMode) return;
                SetSheetById(value);
            }
        }

        public Sheet SelectedSheet { get; private set; }

        #endregion


        #region Private Fields

        private AppDbContext _context;
        private List<Sheet> _sheets = new List<Sheet>();
        private bool _isLoading;

        #endregion


        #region Ctor

        public SheetSelector()
        {
            InitializeComponent();
        }

        #endregion


        #region Load / Init

        private void SheetSelector_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            _context = new AppDbContext();

            InitLookups();
            HookEvents();
            ApplyFocusColor();

            RefreshSheets();
        }

        private void InitLookups()
        {
            ControlExraInit.InitLookupEdit(lkpMaterial);
            ControlExraInit.InitLookupEdit(lkpThickness);
            ControlExraInit.InitLookupEdit(lkpSheetId);

            lkpSheetId.Properties.NullText = " ? ";
        }

        private void HookEvents()
        {
            lkpMaterial.EditValueChanged += (s, e) =>
            {
                if (_isLoading) return;
                FillThickness();
                FillSheetSizes();
            };

            lkpThickness.EditValueChanged += (s, e) =>
            {
                if (_isLoading) return;
                FillSheetSizes();
            };

            lkpSheetId.EditValueChanged += (s, e) =>
            {
                if (_isLoading) return;

                if (int.TryParse(lkpSheetId.EditValue?.ToString(), out int id))
                    SelectedSheet = _sheets.FirstOrDefault(x => x.Id == id);
                else
                    SelectedSheet = null;

                OnEditValueChanged();
            };
        }

        #endregion


        #region Public API

        public void RefreshSheets()
        {
            _isLoading = true;

            _context?.Dispose();
            _context = new AppDbContext();

            _sheets = _context.Sheets.ToList();

            FillMaterials();

            lkpThickness.Properties.DataSource = null;
            lkpSheetId.Properties.DataSource = null;

            lkpMaterial.EditValue = null;
            lkpThickness.EditValue = null;
            lkpSheetId.EditValue = null;

            SelectedSheet = null;

            _isLoading = false;
        }

        #endregion


        #region Core Sync Logic

        private void SetSheetById(object value)
        {
            if (value == null || _sheets == null || _sheets.Count == 0)
                return;

            if (!int.TryParse(value.ToString(), out int id))
                return;

            var sheet = _sheets.FirstOrDefault(x => x.Id == id);
            if (sheet == null)
                return;

            _isLoading = true;

            // Material
            lkpMaterial.EditValue = sheet.Material;

            // Thickness
            FillThickness();
            lkpThickness.EditValue = sheet.Thickness;

            var oldvalue = lkpSheetId.EditValue;
            // SheetSizes
            FillSheetSizes();
            lkpSheetId.EditValue = sheet.Id;

            SelectedSheet = sheet;

            if(!object.Equals(lkpSheetId.EditValue, oldvalue))
                OnEditValueChanged();

            _isLoading = false;
        }

        #endregion


        #region UI Helpers

        public void ApplyFocusColor()
        {
            foreach (Control control in this.Controls)
            {
                if (control is BaseEdit editor && editor.TabStop)
                {
                    editor.Properties.AppearanceFocused.BackColor = Color.FromArgb(255, 255, 192);
                    editor.Properties.AppearanceFocused.Options.UseBackColor = true;
                }
            }
        }

        #endregion


        #region Fill Lookups

        private void FillMaterials()
        {
            var materials = _sheets
                .Where(x => !string.IsNullOrEmpty(x.Material))
                .Select(x => x.Material)
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            lkpMaterial.Properties.DataSource = materials;
        }

        private void FillThickness()
        {
            if (lkpMaterial.EditValue == null)
            {
                lkpThickness.Properties.DataSource = null;
                return;
            }

            string material = lkpMaterial.EditValue.ToString();

            var thicknesses = _sheets
                .Where(x => x.Material == material)
                .Select(x => x.Thickness)
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            lkpThickness.Properties.DataSource = thicknesses;
            lkpThickness.EditValue = null;
        }

        private void FillSheetSizes()
        {
            if (lkpMaterial.EditValue == null || lkpThickness.EditValue == null)
            {
                lkpSheetId.Properties.DataSource = null;
                lkpSheetId.EditValue = null;  //  مقدار باید نال گردد تا ایونت فایر شود
                return;
            }

            string material = lkpMaterial.EditValue.ToString();
            int thickness = Convert.ToInt32(lkpThickness.EditValue);

            var sheets = _sheets
                .Where(x => x.Material == material && x.Thickness == thickness)
                .Select(x => new
                {
                    x.Id,
                    DisplayText = $"{x.Width} × {x.Length}"
                })
                .ToList();

            lkpSheetId.Properties.DataSource = sheets;
            lkpSheetId.Properties.DisplayMember = "DisplayText";
            lkpSheetId.Properties.ValueMember = "Id";
            lkpSheetId.EditValue = null;
        }

        #endregion
    }
}

