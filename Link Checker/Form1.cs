using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Link_Checker
{
    public partial class Form1 : Form
    {
        private readonly String FileName = "LinksData.dat";

        private enum Actions
        {
            Copy,
            Paste,
            Delete,
            SelectAll,
            DeselectAll,
            Add
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadItems();
        }

        // ---------------------methods-------------------------------
        private void AddUniqueLink(String item = "")
        {
            var InputLink = String.Empty;
            if (item != "")
            {
                InputLink = item.StartsWith("+")
                    ? item.Remove(0, 1).Trim()
                    : item.Trim();
            }
            else
            {
                InputLink = InputTextbox.Text.StartsWith("+")
                    ? InputTextbox.Text.Remove(0, 1).Trim()
                    : InputTextbox.Text.Trim();
            }

            var LinkItems = GetListData();

            if (InputLink.Trim() != "" && !LinkItems.Contains(InputLink))
            {
                LinksList.Items.Add(InputLink.Replace("+ ", ""));

            }
        }

        private List<String> GetListData()
        {
            return LinksList.Items.Cast<String>().Select(item => item.StartsWith("+") ? item.Remove(0, 1) : item).ToList();
        }

        private void ConvertLink()
        {
            LinksList.Items[LinksList.SelectedIndex] = LinksList.SelectedItem.ToString().StartsWith("+")
                ? LinksList.SelectedItem.ToString().Replace("+", "").Trim()
                : LinksList.SelectedItem.ToString().Insert(0, "+ ");
        }

        private String GetSelectedLink()
        {
            var q = LinksList.SelectedItem.ToString();
            return q.StartsWith("+")
                ? LinksList.SelectedItem.ToString().Replace("+", "").Trim()
                : LinksList.SelectedItem.ToString();
        }

        private void LoadItems()
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fStream = new FileStream(FileName, FileMode.OpenOrCreate))
            {
                if (fStream.Length == 0) return;
                LinksList.Items.Clear();
                (binFormat.Deserialize(fStream) as List<String>).ForEach(item => LinksList.Items.Add(item));
            }

        }

        private void SaveItems()
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fStream = new FileStream(FileName, FileMode.Create))
            {
                binFormat.Serialize(fStream, LinksList.Items.Cast<String>().ToList());
            }
        }

        private void CopyItems()
        {
            if (LinksList.SelectedItem == null) return;
            String Data = "";
            LinksList.SelectedItems.Cast<String>().ToList().ForEach(item => Data += item.ToString() + Environment.NewLine);
            Clipboard.SetData(DataFormats.Text, Data);
        }

        private void PasteItems()
        {
            Clipboard.GetData(DataFormats.Text).ToString().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(item => AddUniqueLink(item));
        }

        private void DeleteItems()
        {
            if (MessageBox.Show("Delete items?", "Warning", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                LinksList.SelectedItems.Cast<String>().ToList().ForEach(item => LinksList.Items.Remove(item));
            }
        }

        private void SelectAll(Boolean selectAll)
        {
            var index = 0;
            LinksList.Items.Cast<String>().ToList().ForEach(item => LinksList.SetSelected(index++, selectAll));
            InfoHelper.Text = "All items selected";
        }

        private void AddNewLink()
        {
            if (InputTextbox.Text.Length == 0) return;
            AddUniqueLink();
            InputTextbox.Clear();
        }

        private void ItemsActions(Actions action)
        {
            switch (action)
            {
                case Actions.Copy:
                    {
                        CopyItems();
                        SelectAll(false);
                        break;
                    }
                case Actions.Paste:
                    {
                        PasteItems();
                        break;
                    }
                case Actions.Delete:
                    {
                        DeleteItems();
                        break;
                    }
                case Actions.SelectAll:
                    {
                        SelectAll(true);
                        break;
                    }
                case Actions.DeselectAll:
                    {
                        SelectAll(false);
                        return;
                    }
                case Actions.Add:
                    {
                        AddNewLink();
                        break;
                    }
                default:
                    {
                        return;
                    }
            }
            SaveItems();
        }

        // ------------------------keys events-------------------------------
        private void InputTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ItemsActions(Actions.Add);
            }
        }

        private void LinksList_DoubleClick(object sender, EventArgs e)
        {
            ConvertLink();
            SaveItems();
            Clipboard.SetData(DataFormats.Text, GetSelectedLink());
        }

        private void LinksList_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
            if (e.Control && e.KeyCode == Keys.A)
            {
                ItemsActions(Actions.SelectAll);
            }
            if (e.Control && e.KeyCode == Keys.C)
            {
                ItemsActions(Actions.Copy);
            }
            if (e.Control && e.KeyCode == Keys.V)
            {
                ItemsActions(Actions.Paste);
            }
            if (e.KeyCode == Keys.Delete)
            {
                ItemsActions(Actions.Delete);
            }
        }
    }
}
