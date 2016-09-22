using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public interface IReadWritable
    {
        void CreateFromDataFile(string[] dataProperties);

        string FormatDataForSave();
    }
}
