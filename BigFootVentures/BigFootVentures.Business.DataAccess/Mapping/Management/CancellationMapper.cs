using BigFootVentures.Business.DataAccess.Utilities;
using BigFootVentures.Business.Objects.Management;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BigFootVentures.Business.DataAccess.Mapping.Management
{
    public sealed class CancellationMapper : IMapper
    {
        #region "Public Methods"

        public ICollection<object> ParseData(MySqlDataReader dataReader)
        {
            var entities = new List<object>();

            while (dataReader.Read())
            {
                var entity = new Cancellation
                {
                    ID = (int)dataReader["ID"],

                    OwnerName = dataReader["OwnerName"] as string,

                    ReferenceInternal = dataReader["ReferenceInternal"] as string,
                    ReferenceExternal = dataReader["ReferenceExternal"] as string,
                    SentOrigin = dataReader["SentOrigin"] as string,
                    ReceiptDate = dataReader["ReceiptDate"] as string,
                    PaymentDate = dataReader["PaymentDate"] as string,
                    FilingCost = dataReader["FilingCost"] as string,
                    Status = dataReader["Status"] as string,
                    InternalCaseNumber = dataReader["InternalCaseNumber"] as string,
                    SubmissionMethod = dataReader["SubmissionMethod"] as string,
                    PaymentReference = dataReader["PaymentReference"] as string,
                    ResearchPerformance = dataReader["ResearchPerformance"] as string,
                    Comments = dataReader["Comments"] as string,

                    AdmissibleDate = dataReader["AdmissibleDate"] as string,
                    OwnerResponseDeadline = dataReader["OwnerResponseDeadline"] as string,
                    ObservationDeadline = dataReader["ObservationDeadline"] as string,
                    OwnerResponseDeadlineExt = dataReader["OwnerResponseDeadlineExt"] as string,
                    ObservationDeadlineExt = dataReader["ObservationDeadlineExt"] as string,

                    AcquisitionLetterSentOrigin = dataReader["AcquisitionLetterSentOrigin"] as string,
                    AcquisitionLetterSentMethod = dataReader["AcquisitionLetterSentMethod"] as string,
                    AcquisitionLetterDateSent = dataReader["AcquisitionLetterDateSent"] as string,
                    OwnerResponseAcquisitionLetter = dataReader["OwnerResponseAcquisitionLetter"] as string,
                    DomainEnquiry = ((dataReader["DomainEnquiry"] as sbyte? ?? 0) == 1),
                    DomainEnquiryNotes = dataReader["DomainEnquiryNotes"] as string,
                    Outcome = dataReader["Outcome"] as string,
                    OutcomeDate = dataReader["OutcomeDate"] as string,
                    WithdrawalReason = dataReader["WithdrawalReason"] as string,
                    TrademarkAssignmentDate = dataReader["TrademarkAssignmentDate"] as string,
                    TrademarkAcquisitionCost = dataReader["TrademarkAcquisitionCost"] as string,
                    UDRPStrategy = dataReader["UDRPStrategy"] as string,
                    UDRPStrategyComment = dataReader["UDRPStrategyComment"] as string,
                    NegotiationComments = dataReader["NegotiationComments"] as string,
                    WithdrawalDate = dataReader["WithdrawalDate"] as string,
                    ExpenseClaimReceivedDate = dataReader["ExpenseClaimReceivedDate"] as string,
                    CostRefund = dataReader["CostRefund"] as string
                };

                if (int.TryParse((dataReader["TrademarkID"] as int?)?.ToString(), out int trademarkID))
                {
                    entity.Trademark = new Trademark
                    {
                        ID = trademarkID,
                        Name = dataReader["TrademarkName"] as string
                    };
                }

                if (int.TryParse((dataReader["ApplicantID"] as int?)?.ToString(), out int applicantID))
                {
                    entity.Applicant = new Company
                    {
                        ID = applicantID,
                        DisplayName = dataReader["ApplicantName"] as string
                    };
                }

                entities.Add(entity);
            }

            return entities;
        }

        public ICollection<object> ParseDataMin(MySqlDataReader dataReader)
        {
            var entities = new List<object>();

            while (dataReader.Read())
            {
                var entity = new Cancellation
                {
                    ID = (int)dataReader["ID"],

                    ReferenceInternal = dataReader["ReferenceInternal"] as string,
                    ReceiptDate = dataReader["ReceiptDate"] as string,
                    ReferenceExternal = dataReader["ReferenceExternal"] as string,
                    SubmissionMethod = dataReader["SubmissionMethod"] as string
                };

                if (int.TryParse((dataReader["TrademarkID"] as int?)?.ToString(), out int trademarkID))
                {
                    entity.Trademark = new Trademark
                    {
                        ID = trademarkID,
                        Name = dataReader["TrademarkName"] as string
                    };
                }

                if (int.TryParse((dataReader["ApplicantID"] as int?)?.ToString(), out int applicantID))
                {
                    entity.Applicant = new Company
                    {
                        ID = applicantID,
                        DisplayName = dataReader["ApplicantName"] as string
                    };
                }

                entities.Add(entity);
            }

            return entities;
        }

        public StringBuilder ExportData(MySqlDataReader dataReader)
        {
            var file = new StringBuilder();

            file.Append("Reference Internal,Reference External,Sent Origin,Receipt Date,Payment Date,Filing Cost,Status,Internal Case Number,Submission Method,Payment Reference,Research Performance,Comments,");
            file.Append("Admissible Date, Owner Response Deadline,Observation Deadline,Owner Response Deadline Ext,Observation Deadline Ext,Acquisition Letter Sent Origin,Acquisition Letter Sent Method,");
            file.Append("Acquisition Letter Date Sent,Owner Response Acquisition Letter,Domain Enquiry,Domain Enquiry Notes,Outcome,Outcome Date,Withdrawal Reason,Trademark Assignment Date,Trademark Acquisition Cost,");
            file.Append("UDRP Strategy,UDRP Strategy Comments,Negotiation Comments,Withdrawal Date,Expense Claim Received Date,Cost Refund,Trademark Name, Applicant Name,Owner Name");
            file.Append(Environment.NewLine);

            while (dataReader.Read())
            {
                file.Append(DataUtils.EscapeCSV($"{dataReader["ReferenceInternal"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["ReferenceExternal"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["SentOrigin"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["ReceiptDate"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["PaymentDate"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["FilingCost"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["Status"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["InternalCaseNumber"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["SubmissionMethod"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["PaymentReference"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["ResearchPerformance"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["Comments"] as string}") + ",");

                file.Append(DataUtils.EscapeCSV($"{dataReader["AdmissibleDate"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["OwnerResponseDeadline"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["ObservationDeadline"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["OwnerResponseDeadlineExt"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["ObservationDeadlineExt"] as string}") + ",");

                file.Append(DataUtils.EscapeCSV($"{dataReader["AcquisitionLetterSentOrigin"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["AcquisitionLetterSentMethod"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["AcquisitionLetterDateSent"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["OwnerResponseAcquisitionLetter"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{(dataReader["DomainEnquiry"] as sbyte? ?? 0) == 1}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["DomainEnquiryNotes"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["Outcome"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["OutcomeDate"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["WithdrawalReason"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["TrademarkAssignmentDate"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["TrademarkAcquisitionCost"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["UDRPStrategy"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["UDRPStrategyComment"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["NegotiationComments"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["WithdrawalDate"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["ExpenseClaimReceivedDate"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["CostRefund"] as string}") + ",");

                file.Append(DataUtils.EscapeCSV($"{dataReader["TrademarkName"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["ApplicantName"] as string}") + ",");
                file.Append(DataUtils.EscapeCSV($"{dataReader["OwnerName"] as string}") + ",");

                file.Append(Environment.NewLine);
            }

            return file;
        }

        public MySqlParameter[] CreateParameters(object model)
        {
            var entity = (Cancellation)model;
            var parameters = new List<MySqlParameter>();

            parameters.AddRange(new MySqlParameter[]
            {
                new MySqlParameter("pOwnerName", MySqlDbType.VarChar, 100) { Value = entity.OwnerName, Direction = ParameterDirection.Input },

                new MySqlParameter("pReferenceInternal", MySqlDbType.VarChar, 100) { Value = entity.ReferenceInternal, Direction = ParameterDirection.Input },
                new MySqlParameter("pReferenceExternal", MySqlDbType.VarChar, 100) { Value = entity.ReferenceExternal, Direction = ParameterDirection.Input },
                new MySqlParameter("pSentOrigin", MySqlDbType.VarChar, 100) { Value = entity.SentOrigin, Direction = ParameterDirection.Input },
                new MySqlParameter("pReceiptDate", MySqlDbType.VarChar, 45) { Value = entity.ReceiptDate, Direction = ParameterDirection.Input },
                new MySqlParameter("pPaymentDate", MySqlDbType.VarChar, 45) { Value = entity.PaymentDate, Direction = ParameterDirection.Input },
                new MySqlParameter("pFilingCost", MySqlDbType.VarChar, 45) { Value = entity.FilingCost, Direction = ParameterDirection.Input },
                new MySqlParameter("pTrademarkID", MySqlDbType.Int32) { Value = entity.Trademark?.ID, Direction = ParameterDirection.Input },
                new MySqlParameter("pStatus", MySqlDbType.VarChar, 45) { Value = entity.Status, Direction = ParameterDirection.Input },
                new MySqlParameter("pInternalCaseNumber", MySqlDbType.VarChar, 45) { Value = entity.InternalCaseNumber, Direction = ParameterDirection.Input },
                new MySqlParameter("pSubmissionMethod", MySqlDbType.VarChar, 45) { Value = entity.SubmissionMethod, Direction = ParameterDirection.Input },
                new MySqlParameter("pApplicantID", MySqlDbType.Int32) { Value = entity.Applicant?.ID, Direction = ParameterDirection.Input },
                new MySqlParameter("pPaymentReference", MySqlDbType.VarChar, 100) { Value = entity.PaymentReference, Direction = ParameterDirection.Input },
                new MySqlParameter("pResearchPerformance", MySqlDbType.VarChar, 45) { Value = entity.ResearchPerformance, Direction = ParameterDirection.Input },
                new MySqlParameter("pComments", MySqlDbType.VarChar, 255) { Value = entity.Comments, Direction = ParameterDirection.Input },

                new MySqlParameter("pAdmissibleDate", MySqlDbType.VarChar, 45) { Value = entity.AdmissibleDate, Direction = ParameterDirection.Input },
                new MySqlParameter("pOwnerResponseDeadline", MySqlDbType.VarChar, 45) { Value = entity.OwnerResponseDeadline, Direction = ParameterDirection.Input },
                new MySqlParameter("pObservationDeadline", MySqlDbType.VarChar, 45) { Value = entity.ObservationDeadline, Direction = ParameterDirection.Input },
                new MySqlParameter("pOwnerResponseDeadlineExt", MySqlDbType.VarChar, 45) { Value = entity.OwnerResponseDeadlineExt, Direction = ParameterDirection.Input },
                new MySqlParameter("pObservationDeadlineExt", MySqlDbType.VarChar, 45) { Value = entity.ObservationDeadlineExt, Direction = ParameterDirection.Input },

                new MySqlParameter("pAcquisitionLetterSentOrigin", MySqlDbType.VarChar, 45) { Value = entity.AcquisitionLetterSentOrigin, Direction = ParameterDirection.Input },
                new MySqlParameter("pAcquisitionLetterSentMethod", MySqlDbType.VarChar, 45) { Value = entity.AcquisitionLetterSentMethod, Direction = ParameterDirection.Input },
                new MySqlParameter("pAcquisitionLetterDateSent", MySqlDbType.VarChar, 45) { Value = entity.AcquisitionLetterDateSent, Direction = ParameterDirection.Input },
                new MySqlParameter("pOwnerResponseAcquisitionLetter", MySqlDbType.VarChar, 45) { Value = entity.OwnerResponseAcquisitionLetter, Direction = ParameterDirection.Input },
                new MySqlParameter("pDomainEnquiry", entity.DomainEnquiry ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pDomainEnquiryNotes", MySqlDbType.VarChar, 255) { Value = entity.DomainEnquiryNotes, Direction = ParameterDirection.Input },
                new MySqlParameter("pOutcome", MySqlDbType.VarChar, 45) { Value = entity.Outcome, Direction = ParameterDirection.Input },
                new MySqlParameter("pOutcomeDate", MySqlDbType.VarChar, 45) { Value = entity.OutcomeDate, Direction = ParameterDirection.Input },
                new MySqlParameter("pWithdrawalReason", MySqlDbType.VarChar, 255) { Value = entity.WithdrawalReason, Direction = ParameterDirection.Input },
                new MySqlParameter("pTrademarkAssignmentDate", MySqlDbType.VarChar, 45) { Value = entity.TrademarkAssignmentDate, Direction = ParameterDirection.Input },
                new MySqlParameter("pTrademarkAcquisitionCost", MySqlDbType.VarChar, 45) { Value = entity.TrademarkAcquisitionCost, Direction = ParameterDirection.Input },
                new MySqlParameter("pUDRPStrategy", MySqlDbType.VarChar, 45) { Value = entity.UDRPStrategy, Direction = ParameterDirection.Input },
                new MySqlParameter("pUDRPStrategyComment", MySqlDbType.VarChar, 255) { Value = entity.UDRPStrategyComment, Direction = ParameterDirection.Input },
                new MySqlParameter("pNegotiationComments", MySqlDbType.VarChar, 255) { Value = entity.NegotiationComments, Direction = ParameterDirection.Input },
                new MySqlParameter("pWithdrawalDate", MySqlDbType.VarChar, 45) { Value = entity.WithdrawalDate, Direction = ParameterDirection.Input },
                new MySqlParameter("pExpenseClaimReceivedDate", MySqlDbType.VarChar, 45) { Value = entity.ExpenseClaimReceivedDate, Direction = ParameterDirection.Input },
                new MySqlParameter("pCostRefund", MySqlDbType.VarChar, 45) { Value = entity.CostRefund, Direction = ParameterDirection.Input },
            });

            return parameters.ToArray();
        }

        #endregion
    }
}
