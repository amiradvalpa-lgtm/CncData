using CncApp_Final.Frms.Base;
using System;

namespace CncApp_Final.Frms.Base
{
    public interface IEditForm
    {
        event EventHandler<RecordSavedEventArgs> ChangesSaved;
        System.Windows.Forms.DialogResult ShowDialog();
    }
}