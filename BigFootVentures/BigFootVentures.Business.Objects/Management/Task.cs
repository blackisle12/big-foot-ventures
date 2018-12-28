using System;
using System.Collections.Generic;

namespace BigFootVentures.Business.Objects.Management
{
    public sealed class Task : BusinessBase
    {
        #region "Properties"

        public string Subject { get; set; }
        public string Comments { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string Priority { get; set; }
        public DateTime? CompletionDate { get; set; }
        public DateTime? CreationDate { get; set; }
        public string ReasonForClose { get; set; }
        public UserAccount AssignedTo { get; set; }
        public string Status { get; set; }
        public int? RelatedToObjectID { get; set; }
        public string RelatedToObjectName { get; set; }
        public string RelatedToObjectValue { get; set; }
        public bool CloseTask { get; set; }

        public List<Contact> RelatedToContacts { get; set; }
        public DateTime? MessageDate { get; set; }

        public bool CreateRecurringSeriesOfTasks { get; set; }

        public bool Reminder { get; set; }
        public string ReminderDate { get; set; }
        public string ReminderTime { get; set; }

        public string OwnerName { get; set; }

        #endregion
    }
}
