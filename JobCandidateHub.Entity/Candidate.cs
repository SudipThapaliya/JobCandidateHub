using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobCandidateHub.Entity
{
    public class Candidate : BaseEntity
    {
        /// <summary>
        /// Required
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Required
        /// </summary>
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Required
        /// unique identifier
        /// </summary>
        public string Email { get; set; }
        public DateTime? TimeIntervalStart { get; set; }
        public DateTime? TimeIntervalEnd { get; set; }
        public string LinkedIn { get; set; }
        public string GitHub { get; set; }
        /// <summary>
        /// Required
        /// </summary>
        public string Comment { get; set; }
    }
}
