using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClipMenu
{
    class SavedItemList : ICollection<string>
    {
        private List<string> items;
        private string filename;

        public SavedItemList(string filename)
        {
            items = new List<string>();
            this.filename = filename;
            Reload();
        }

        public void Reload()
        {
            items.Clear();
            if (!File.Exists(filename)) File.Open(filename, FileMode.CreateNew, FileAccess.Write).Close();
            FileStream fs = File.Open(filename, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8);

            bool eof = false;
            while (!eof) {
                try {
                    string item = sr.ReadLine();
                    if (item == null) {
                        eof = true;
                    } else if (!item.Equals("")) {
                        items.Add(item);
                    }
                } catch (EndOfStreamException) {
                    eof = true;
                }
            }

            fs.Close();
        }

        public void Save()
        {
            FileStream fs = File.Open(filename, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

            foreach (string s in items) {
                sw.WriteLine(s);
            }

            sw.Dispose();
            fs.Close();
        }

        public void Add(string item)
        {
            if (item != null && !item.Equals("")) {
                if (!Contains(item)) {
                    items.Add(item);
                    Save();
                }
            }
        }

        public void Clear()
        {
            items.Clear();
            Save();
        }

        public bool Contains(string item)
        {
            return items.Contains(item);
        }

        public void CopyTo(string[] array, int arrayIndex)
        {
            items.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return items.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(string item)
        {
            bool result = items.Remove(item);
            Save();
            return result;
        }

        public IEnumerator<string> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
