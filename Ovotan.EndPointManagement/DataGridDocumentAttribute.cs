using System;

namespace Ovotan.EndPointManagement
{
    public class DataGridDocumentAttribute : Attribute
    {
        public string DisplayName { get; private set; }
        public bool Ignorable { get; private set; }

        public DataGridDocumentAttribute(string displayName) 
        { 
            DisplayName = displayName;
        }

        public DataGridDocumentAttribute(bool ignorable)
        {
            Ignorable = ignorable;
        }


        public DataGridDocumentAttribute(string displayName = null, bool ignorable = false)
        {
            DisplayName = displayName;
            Ignorable = ignorable;
        }
    }

}
