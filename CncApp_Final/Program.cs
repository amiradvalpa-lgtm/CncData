using DevExpress.LookAndFeel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using CncApp_Final.Frm;
using CncApp_Final.TempFrm;

namespace CncApp_Final
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("fa-IR");
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentCulture;
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(System.Threading.Thread.CurrentThread.CurrentCulture);


            //DevExpress.UserSkins.BonusSkins.Register();
            //Assembly asm = typeof(DevExpress.UserSkins.MahakSkinPatch).Assembly;
            //DevExpress.XtraEditors.WindowsFormsSettings.RegisterUserSkins(asm);
            //DevExpress.XtraEditors.WindowsFormsSettings.AllowSkinEditorAttach = DevExpress.Utils.DefaultBoolean.True;
            ////DevExpress.XtraEditors.WindowsFormsSettings.DefaultLookAndFeel.SetSkinStyle("MahakSkinPatch");
            //UserLookAndFeel defaultLF = UserLookAndFeel.Default;
            //defaultLF.SkinName = "WXI MahakSkinPatch";

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmOrderDetails());
        }
    }
}
