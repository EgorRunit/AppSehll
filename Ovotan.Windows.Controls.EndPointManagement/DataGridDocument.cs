using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Linq;
using System.Reflection;
using Ovotan.EndPointManagement;
using System.Net.Http.Headers;
using System.Windows.Data;

namespace Ovotan.Windows.Controls.EndPointManagement
{
    public class DataGridDocument : DataGrid
    {
        bool _columnCreated;

        public new IEnumerable ItemsSource
        {
            get
            {
                return GetValue(DataGrid.ItemsSourceProperty) as IEnumerable;
            }
            set
            {
                _createColumns(value);
                SetValue(DataGrid.ItemsSourceProperty, value);
            }
        }

        void _createColumns(IEnumerable list)
        {
            if (Columns.Count == 0)
            {
                var properties = list.GetType().GenericTypeArguments[0].GetProperties();
                foreach(var property in properties)
                {
                    var column = new DataGridTextColumn() { Header = property.Name };
                    column.Binding = new Binding(property.Name);
                    var attribute = property.GetCustomAttribute<DataGridDocumentAttribute>();
                    if (attribute != null)
                    {
                        if(attribute.Ignorable)
                        {
                            continue;
                        }
                    }
                    else
                    {
                        Columns.Add(column);
                    }
                }
            }
        }

        public DataGridDocument() 
        {
            AutoGenerateColumns = false;
            AutoGeneratingColumn += DataGridDocument_AutoGeneratingColumn;
        }

        private void DataGridDocument_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyDescriptor is PropertyDescriptor descriptor)
            {
                e.Column.Header = descriptor.DisplayName ?? descriptor.Name;
            }
        }
    }
}
