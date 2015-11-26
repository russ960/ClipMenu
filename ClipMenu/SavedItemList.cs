using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SQLite;

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
            //if (!File.Exists(filename)) File.Open(filename, FileMode.CreateNew, FileAccess.Write).Close(); //To be removed
            /* Establish connection to database and will create db file if it does not exist. */
            var dbfilename = filename + ".db";
            var constring = "Data Source=" + dbfilename + ";Version=3;";
            SQLiteConnection dbconn;
            dbconn = new SQLiteConnection(constring);
            dbconn.Open();
            var tableCreateSql = "CREATE TABLE IF NOT EXISTS 'ClipLists' ('ClipListId' INTEGER PRIMARY KEY AUTOINCREMENT, 'ClipListName' TEXT NOT NULL);";
            tableCreateSql = tableCreateSql + "CREATE TABLE IF NOT EXISTS 'Clips' ('ClipId' INTEGER PRIMARY KEY AUTOINCREMENT, 'ClipName' TEXT NOT NULL, 'ClipText' TEXT, 'ClipListId' INTEGER NOT NULL);";
            tableCreateSql = tableCreateSql + "INSERT INTO ClipLists (ClipListName) SELECT 'default' WHERE NOT EXISTS (SELECT * FROM ClipLists);";
            SQLiteCommand cmd = new SQLiteCommand(tableCreateSql,dbconn);
            cmd.ExecuteNonQuery();
            /* End database connection opening replacement. */

            /* Load items in to list type item */
            var getItems = "SELECT ClipName, ClipText FROM Clips";
            cmd.CommandText = getItems;
            SQLiteDataReader clipText = cmd.ExecuteReader();

            while (clipText.Read())
            {
                items.Add(clipText["ClipText"].ToString());
            }
            dbconn.Close();
            /* End Load items in to list type item */


            /* Code to be removed:
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
             */
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

            if (item != null && !item.Equals(""))
            {
                var dbfilename = filename + ".db";
                var constring = "Data Source=" + dbfilename + ";Version=3;";
                SQLiteConnection dbconn;
                dbconn = new SQLiteConnection(constring);
                dbconn.Open();
                var tableCreateSql = "INSERT INTO Clips (ClipName, ClipText, ClipListId) SELECT @item, @item, 1 WHERE NOT EXISTS (SELECT * FROM ClipLists WHERE ClipName = @item);";
                SQLiteCommand cmd = new SQLiteCommand(tableCreateSql, dbconn);
                cmd.Parameters.Add(new SQLiteParameter("@item", item));
                cmd.ExecuteNonQuery();
                

            }

            /* Code to be removed Start
            if (item != null && !item.Equals("")) {
                if (!Contains(item)) {
                    items.Add(item);
                    Save();
                }
            }
            Code to be removed End */
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
