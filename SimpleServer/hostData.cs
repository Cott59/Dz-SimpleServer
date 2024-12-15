using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SimpleServer
{
    internal class hostData
    {
        List<string> list = new List<string>();
        private void hostdisks()
        {
            list.Clear();
            var dataDisk = DriveInfo.GetDrives();
            foreach (var disk in dataDisk)
            {
                string tmp = $" disk: {disk.Name} - {disk.AvailableFreeSpace} byte";
                list.Add(tmp);
            }

        }
        
        public List<string> Getlist()
        {
            hostdisks();
            return list;
        }



    }
}
