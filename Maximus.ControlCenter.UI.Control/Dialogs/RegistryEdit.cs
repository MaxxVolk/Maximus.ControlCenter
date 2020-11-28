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
    public string NewName { get => tbNewName.Text; set => tbNewName.Text = value; }

    public string Value
    {
      get
      {
        switch (ValueKind)
        {
          case RegistryValueKind.String:
          case RegistryValueKind.ExpandString:
            return tbStringValue.Text;
          case RegistryValueKind.DWord:
          case RegistryValueKind.QWord:
            return nudIntegerValue.Value.ToString();
          case RegistryValueKind.MultiString:
            return tbMultiStringValue.Text;
          case RegistryValueKind.Binary:
            return tbBinaryValue.Text;
        }

        return null;
      }
      set
      {
        switch (ValueKind)
        {
          case RegistryValueKind.String:
          case RegistryValueKind.ExpandString:
            tbStringValue.Text = value; break;
          case RegistryValueKind.DWord:
            nudIntegerValue.Value = uint.Parse(value); break;
          case RegistryValueKind.QWord:
            nudIntegerValue.Value = ulong.Parse(value); break;
          case RegistryValueKind.MultiString:
            tbMultiStringValue.Text = value; break;
          case RegistryValueKind.Binary:
            tbBinaryValue.Text = value;
            break;
        }
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
        case RegistryValueKind.ExpandString:
        case RegistryValueKind.String:       tcPages.SelectedTab = tpStringValue; break;
        case RegistryValueKind.DWord:
          nudIntegerValue.Minimum = 0;
          nudIntegerValue.Maximum = uint.MaxValue;
          tcPages.SelectedTab = tpNumeric; 
          break;
        case RegistryValueKind.QWord:
          nudIntegerValue.Minimum = 0;
          nudIntegerValue.Maximum = ulong.MaxValue;
          tcPages.SelectedTab = tpNumeric;
          break;
        case RegistryValueKind.MultiString:  tcPages.SelectedTab = tpMultiString; break;
        case RegistryValueKind.Binary:       tcPages.SelectedTab = tpBinary; break;
      }
    }
  }
}
