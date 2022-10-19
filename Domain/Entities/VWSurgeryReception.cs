using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MiladHosSignalR.Domain.Entities
{
    [Table("VWSurgeryReception", Schema = "srg")]
    public class VWSurgeryReception
    {
        public int LastPositionId { get; set; }
        public string LastPositionName { get; set; }
        public int Id { get; set; }
        public int SurgeryReceptionId { get; set; }
        public int SurgicalStatusId { get; set; }
        public char SurgeryDate { get; set; }
        public string PatientName { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientFatherName { get; set; }
    }

}

