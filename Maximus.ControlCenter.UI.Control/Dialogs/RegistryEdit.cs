using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Win32;

namespace Maximus.ControlCenter.UI.Control.Dialogs
{
  public enum RegistryEditFormMode { NewName, NewValue, EditValue }

  public partial class RegistryEditForm : Form
  {
    // Input
    public RegistryEditFormMode FormMode { get; set; }
    public RegistryValueKind ValueKind { get; set; }

    // Output
    public string NewName => tbNewName.Text;

    public string Value
    {
      get
      {
        switch (ValueKind)
        {
          case RegistryValueKind.String: 
            return tbStringValue.Text;
          case RegistryValueKind.DWord:
          case RegistryValueKind.QWord:
            break;
        }

        return null;
      }
    }

    public RegistryEditForm()
    {
      InitializeComponent();
    }

    protected override void OnShown(EventArgs e)
    {
      base.OnShown(e);
      switch (FormMode)
      {
        case RegistryEditFormMode.NewName:
          tcPages.Visible = false;
          break;
        case RegistryEditFormMode.EditValue:
          tbNewName.Enabled = false;
          break;
        case RegistryEditFormMode.NewValue:
          break;
      }
      switch (ValueKind)
      {
        case RegistryValueKind.String: tcPages.SelectedTab = tpStringValue; break;
        case RegistryValueKind.DWord:
        case RegistryValueKind.QWord:
          tcPages.SelectedTab = tpNumeric;
          break;
      }
    }
  }
}
