using EllieMae.Encompass.Automation;
using EllieMae.Encompass.BusinessObjects.Loans;
using EllieMae.Encompass.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RedisclosureComments
{
    [Plugin]
    public class RediscComment
    {
        public RediscComment()
        {

            EncompassApplication.LoanOpened += EncompassApplication_LoanOpened;





        }
    private void EncompassApplication_LoanOpened(object sender, EventArgs e)
    {
        EncompassApplication.CurrentLoan.FieldChange += CurrentLoan_FieldChange;
        EncompassApplication.CurrentLoan.Committed += CurrentLoan_Committed;
            var disSent = EncompassApplication.CurrentLoan.Log.Disclosures2015;
            int sentDateLast = disSent.Count - 1;
            if (sentDateLast >= 0)
            {
                string sentDate = disSent[sentDateLast].DisclosedDate2015.ToString();

                EncompassApplication.CurrentLoan.Fields["CX.REDISC.SENT.DATETIME"].Value = sentDate;
            }

        }

        private void CurrentLoan_Committed(object sender, EllieMae.Encompass.BusinessObjects.PersistentObjectEventArgs e)
        {

            var disSent = EncompassApplication.CurrentLoan.Log.Disclosures2015;
            int sentDateLast = disSent.Count - 1;
            if (sentDateLast >= 0)
            {
                string sentDate = disSent[sentDateLast].DisclosedDate2015.ToString();

                EncompassApplication.CurrentLoan.Fields["CX.REDISC.SENT.DATETIME"].Value = sentDate;
            }


        }


        private void CurrentLoan_FieldChange(object source, EllieMae.Encompass.BusinessObjects.Loans.FieldChangeEventArgs e)
        {

            Loan loan = EncompassApplication.CurrentLoan;
            int disCount = EncompassApplication.CurrentLoan.Log.Disclosures2015.Count;
            var disSent = EncompassApplication.CurrentLoan.Log.Disclosures2015;
            //var entryType = disSent[0].EntryType;
            //var disDocCount = disSent[0].Documents.Count;
            //int encCountInt = Convert.ToInt32(encCount);
            
            int discNum = disCount - 1;
            var bPairs = EncompassApplication.CurrentLoan.BorrowerPairs.Count;
            int encCount = bPairs;
            int sysCount = Convert.ToInt32(loan.Fields["CX.REDISC.DISC.COUNT"].Value);
            string apprSent = loan.Fields["CX.REDISC.TYPE.TEXT"].Value.ToString();


            if (e.FieldID == "CX.REDISC.OPENED")
            {
                if (encCount < disCount)
                {
                    if (sysCount < encCount)
                    {
                        sysCount = encCount + 1;
                    }
                    if (sysCount < disCount)
                    {

                        if (apprSent == "Approval")
                        {
                            loan.Fields["CX.REDISC.APPROVAL"].Value = "X";
                            loan.Fields["CX.REDISC.TYPE.TEXT"].Value = "Approval";
                            sysCount = disCount;
                        }
                        else if (apprSent == "LE")
                        {
                            loan.Fields["CX.REDISC.LE"].Value = "X";
                            loan.Fields["CX.REDISC.TYPE.TEXT"].Value = "LE";
                            sysCount = disCount;
                        }
                        else
                        {
                            loan.Fields["CX.REDISC.CD"].Value = "X";
                            loan.Fields["CX.REDISC.TYPE.TEXT"].Value = "CD";
                            sysCount = disCount;
                        }
                    }
                    
                }
            }
            loan.Fields["CX.REDISC.DISC.COUNT"].Value = sysCount;
        }
    }
}
