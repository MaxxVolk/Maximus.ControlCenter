using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            string result = "";
            for (int i = 0; i < tbMultiStringValue.Lines.Length; i++)
              result += tbMultiStringValue.Lines[i] + ((i == tbMultiStringValue.Lines.Length - 1) ? "" : "\r\n");
            return result;
          case RegistryValueKind.Binary:
            string bresult = "";
            foreach (string line in tbBinaryValue.Lines)
              bresult += line;
            return bresult;
        }

        return null;
      }
      set
      {
        switch (ValueKind)
        {
          case RegistryValueKind.String:
            tbStringValue.Text = value; break;
          case RegistryValueKind.ExpandString:
            tbStringValue.Text = value; break;
          case RegistryValueKind.DWord:
            nudIntegerValue.Minimum = 0;
            nudIntegerValue.Maximum = uint.MaxValue;
            nudIntegerValue.Value = uint.Parse(value); break;
          case RegistryValueKind.QWord:
            nudIntegerValue.Minimum = 0;
            nudIntegerValue.Maximum = ulong.MaxValue;
            nudIntegerValue.Value = ulong.Parse(value); break;
          case RegistryValueKind.MultiString:
            tbMultiStringValue.Lines = value.Split(new string[] { "\r\n", "\r", "\n", "\n\r" }, StringSplitOptions.RemoveEmptyEntries);
            Dbg.Log(value);
            break;
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
        case RegistryValueKind.String:      
          tcPages.SelectedTab = tpStringValue; 
          break;
        case RegistryValueKind.DWord:
          tcPages.SelectedTab = tpNumeric; 
          break;
        case RegistryValueKind.QWord:
          tcPages.SelectedTab = tpNumeric;
          break;
        case RegistryValueKind.MultiString:  
          tcPages.SelectedTab = tpMultiString; 
          break;
        case RegistryValueKind.Binary:       
          tcPages.SelectedTab = tpBinary; 
          break;
      }
    }

    private void tbBinaryValue_Validating(object sender, CancelEventArgs e)
    {
      foreach(string line in tbBinaryValue.Lines)
      {
        if (!Regex.IsMatch(line, "^(?:[0123456789ABCDEFabcdef][0123456789ABCDEFabcdef]\\s*)*$"))
        {
          e.Cancel = true;
          break;
        }
      }
    }

    private void tbBinaryValue_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)ConsoleKey.Backspace || e.KeyChar == (char)ConsoleKey.Delete)
        return;
      if ("0123456789ABCDEFabcdef \r\n".IndexOf(e.KeyChar) < 0)
        e.Handled = true;
    }

    private void RegistryEditForm_FormClosing(object sender, FormClosingEventArgs e)
    {
    }
  }
}
