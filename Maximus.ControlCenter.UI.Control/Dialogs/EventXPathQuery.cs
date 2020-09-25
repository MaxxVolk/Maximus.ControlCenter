using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Maximus.ControlCenter.UI.Control.Properties;

namespace Maximus.ControlCenter.UI.Control.Dialogs
{
  public partial class EventXPathQueryForm : Form
  {
    private const string resourcePrefix = "EventXPath_";

    public string Query { get; set; }

    public EventXPathQueryForm()
    {
      InitializeComponent();
    }

    private void EventXPathQueryForm_Load(object sender, EventArgs e)
    {
      cbPreDefQueryPicker.Items.Clear();
      // using (System.Resources.ResourceSet rs = Resources.ResourceManager.GetResourceSet(CultureInfo.InvariantCulture, true, false))
        foreach (DictionaryEntry res in Resources.ResourceManager.GetResourceSet(CultureInfo.InvariantCulture, true, false))
        {
          string resourceName = (string)res.Key;
          if (resourceName.IndexOf(resourcePrefix) == 0)
            cbPreDefQueryPicker.Items.Add(resourceName.Substring(resourcePrefix.Length));
        }
    }

    private void cbPreDefQueryPicker_SelectionChangeCommitted(object sender, EventArgs e)
    {
      if (cbPreDefQueryPicker.SelectedIndex >= 0)
      {
        tbQueryText.Text = Resources.ResourceManager.GetString(resourcePrefix + (string)cbPreDefQueryPicker.SelectedItem, CultureInfo.InvariantCulture);
      }
    }

    private void EventXPathQueryForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      Query = tbQueryText.Text;
    }

    private void EventXPathQueryForm_Shown(object sender, EventArgs e)
    {
      tbQueryText.Text = Query;
    }

    private void rbManual_CheckedChanged(object sender, EventArgs e)
    {
      UpdateElements();
    }

    private void UpdateElements()
    {
      tbQueryText.ReadOnly = !rbManual.Checked;
      cbPreDefQueryPicker.Enabled = rbPreDefined.Checked;
    }

    private void rbPreDefined_CheckedChanged(object sender, EventArgs e)
    {
      UpdateElements();
    }

    private void rbFilter_CheckedChanged(object sender, EventArgs e)
    {
      UpdateElements();
    }
  }
}
