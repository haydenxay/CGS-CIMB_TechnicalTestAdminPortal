using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CGS_CIMB_TechnicalTestAdminPortal.Models
{
    public class ReportsDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int ReadershipStats { get; set; }
        public Guid ReportFilesId { get; set; }
    }
}
