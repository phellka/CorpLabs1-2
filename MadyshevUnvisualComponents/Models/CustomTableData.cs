using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadyshevUnvisualComponents.Models
{
    public class CustomTableData<T>
    {
        public String FileName { get; set; }
        public String Title { get; set; }
        public List<int> ColumnsWidth { get; set; }
        public int HeaderHeight { get; set; }
        public int RowsHeight { get; set; }
        public List<String> ColumnsHeaders { get; set; }
        public List<T> Data { get; set; }
        public List<string> ColumnsProperties { get; set; }
    }
}
