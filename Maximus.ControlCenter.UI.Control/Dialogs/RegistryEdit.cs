using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maximus.ControlCenter.UI.Control.Dialogs
{
  public enum RegistryEditFormMode { NewName }

  public partial class RegistryEditForm : Form
  {
    // Input
    public RegistryEditFormMode FormMode { get; set; }

    // Output
    public string NewName => tbNewName.Text;

    public RegistryEditForm()
    {
      InitializeComponent();
    }

    protected override void OnShown(EventArgs e)
    {
      base.OnShown(e);
      switch (FormMode)
      {
        case RegistryEditFormMode.NewName: tcPages.SelectedTab = tpNewName; break;
      }
    }
  }
}
