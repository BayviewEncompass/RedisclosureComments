using EllieMae.Encompass.Automation;
using EllieMae.Encompass.BusinessObjects.Loans;
using EllieMae.Encompass.BusinessObjects.Users;
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
		Loan loan = EncompassApplication.CurrentLoan;
        User user = EncompassApplication.CurrentUser;
        
        
        List<string> alertList = new List<string> { "CX.RD.ALERT1", "CX.RD.ALERT2", "CX.RD.ALERT3", "CX.RD.ALERT4", "CX.RD.ALERT5", "CX.RD.ALERT6", "CX.RD.ALERT7", "CX.RD.ALERT8", "CX.RD.ALERT9", "CX.RD.ALERT10", "CX.RD.ALERT11", "CX.RD.ALERT12" };
        List<string> resolveList = new List<string> { "CX.RD.RESOLVE1", "CX.RD.RESOLVE2", "CX.RD.RESOLVE3", "CX.RD.RESOLVE4", "CX.RD.RESOLVE5", "CX.RD.RESOLVE6", "CX.RD.RESOLVE7", "CX.RD.RESOLVE8", "CX.RD.RESOLVE9", "CX.RD.RESOLVE10", "CX.RD.RESOLVE11", "CX.RD.RESOLVE12" };
        List<string> whoList = new List<string> { "CX.RD.WHO1", "CX.RD.WHO2", "CX.RD.WHO3", "CX.RD.WHO4", "CX.RD.WHO5", "CX.RD.WHO6", "CX.RD.WHO7", "CX.RD.WHO8", "CX.RD.WHO9", "CX.RD.WHO10", "CX.RD.WHO11", "CX.RD.WHO12" };
        List<string> cocList = new List<string> { "CX.RD.COC1", "CX.RD.COC2", "CX.RD.COC3", "CX.RD.COC4", "CX.RD.COC5", "CX.RD.COC6", "CX.RD.COC7", "CX.RD.COC8", "CX.RD.COC9", "CX.RD.COC10", "CX.RD.COC11", "CX.RD.COC12" };
        List<string> docList = new List<string> { "CX.RD.COC.DOC1", "CX.RD.COC.DOC2", "CX.RD.COC.DOC3", "CX.RD.COC.DOC4", "CX.RD.COC.DOC5", "CX.RD.COC.DOC6", "CX.RD.COC.DOC7", "CX.RD.COC.DOC8", "CX.RD.COC.DOC9", "CX.RD.COC.DOC10", "CX.RD.COC.DOC11", "CX.RD.COC.DOC12" };
        List<string> procList = new List<string> { "CX.RD.COC.PROCESSOR1", "CX.RD.COC.PROCESSOR2", "CX.RD.COC.PROCESSOR3", "CX.RD.COC.PROCESSOR4", "CX.RD.COC.PROCESSOR5", "CX.RD.COC.PROCESSOR6", "CX.RD.COC.PROCESSOR7", "CX.RD.COC.PROCESSOR8", "CX.RD.COC.PROCESSOR9", "CX.RD.COC.PROCESSOR10", "CX.RD.COC.PROCESSOR11", "CX.RD.COC.PROCESSOR12" };
        List<string> closerList = new List<string> { "CX.RD.COC.CLOSER1", "CX.RD.COC.CLOSER2", "CX.RD.COC.CLOSER3", "CX.RD.COC.CLOSER4", "CX.RD.COC.CLOSER5", "CX.RD.COC.CLOSER6", "CX.RD.COC.CLOSER7", "CX.RD.COC.CLOSER8", "CX.RD.COC.CLOSER9", "CX.RD.COC.CLOSER10", "CX.RD.COC.CLOSER11", "CX.RD.COC.CLOSER12" };
        List<string> commentBoxList = new List<string> { "CX.REDISC.NOT.COMPLETED.COMM", "CX.CD.COMMENTS2", "CX.REDISC.NOCOMP1", "CX.CD.COMMENTS3", "CX.REDISC.NOCOMP2", "CX.REDISC.COMMENTS.HIST", "CX.REDISC.NOCOMP3", "CX.REDISC.HIST2", "CX.REDISC.NOCOMP4", "CX.REDISC.HIST3", "CX.CD.COMMENTS1", "CX.REDISC.HIST4" };
        List<string> dSpeciaList = new List<string> { "CX.REDISC.SPECIALIST", "CX.REDISC.SPECIALIST.2", "CX.REDISC.SPECIALIST.3", "CX.REDISC.SPECIALIST.4", "CX.REDISC.SPECIALIST.5", "CX.REDISC.SPECIALIST.6", "CX.REDISC.SPECIALIST.7", "CX.REDISC.SPECIALIST.8", "CX.REDISC.SPECIALIST.9", "CX.REDISC.SPECIALIST.10", "CX.REDISC.SPECIALIST.11", "CX.REDISC.SPECIALIST.12" };
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
            User user = EncompassApplication.CurrentUser;




            if (e.FieldID == "CX.REDISC.SENT.DATETIME")
            {
                var sentLE = loan.Fields["CX.REDISC.LE"].Value;
                var sentCD = loan.Fields["CX.REDISC.CD"].Value;
                var sentApproval = loan.Fields["CX.REDISC.APPROVAL"].Value;

                if (sentLE.ToString() == "X")
                {
                    LE_Sent();
                }

                if (sentCD.ToString() == "X")
                {
                    CD_sent();
                }
                if (sentApproval.ToString() == "X")
                {
                    Approval_Package();
                }

            }
            
        }
        private void LE_Sent()
        {
            string hist = "";
            Loan loan = EncompassApplication.CurrentLoan;
            User user = EncompassApplication.CurrentUser;
            for (int i = 0; i < commentBoxList.Count; i++)
            {
                if (loan.Fields[commentBoxList[i]].FormattedValue == "")
                {

                    loan.Fields[commentBoxList[i]].Value = loan.Fields["CX.REDISC.COMMENTS.VAR"].FormattedValue;
                    loan.Fields[dSpeciaList[i]].Value = loan.Fields["CX.REDISC.ASSIGNED"].Value;
                    if (loan.Fields["CX.LN.HISTORY"].FormattedValue == "")
                    {
                        hist = (user + " " + DateTime.Now + " - " + "\n" + Macro.GetField("CX.REDISC.ASSIGNED") + "\n" + loan.Fields["CX.REDISC.COMMENTS.VAR"].Value);
                        Macro.SetField("CX.LN.HISTORY", hist);
                    }
                    if (loan.Fields["CX.LN.HISTORY"].FormattedValue != "")
                    {
                        hist = (user + " " + DateTime.Now + " - " + "\n" + Macro.GetField("CX.REDISC.ASSIGNED") + "\n" + loan.Fields["CX.REDISC.COMMENTS.VAR"].Value + " " + "\n" + "\n" + Macro.GetField("CX.LN.HISTORY"));
                        Macro.SetField("CX.LN.HISTORY", hist);
                        loan.Fields[commentBoxList[i]].Value = loan.Fields["CX.REDISC.COMMENTS.VAR"].Value;
                        loan.Fields["CX.REDISC.COMMENTS.VAR"].Value = "";
                        
                    }
                    break;
                }
            }
            Macro.SetField("CX.REDISC.DATA", "Data");
            Macro.SetField("CX.REDISC.COMPLETED.DATE", DateTime.Today.ToString());
            Macro.CopyField("CX.REDISC.ASSIGNED", "CX.REDISC.COMPLETED.USER");
            Macro.SetField("CX.HELOC", "N");
            Macro.CopyField("1041", "CX.REDISC.1041");
            Macro.CopyField("1172", "CX.REDISC.1172");
            Macro.CopyField("1109", "CX.REDISC.1109");
            Macro.CopyField("1550", "CX.REDISC.1550");
            Macro.CopyField("19", "CX.REDISC.19");
            Macro.CopyField("1811", "CX.REDISC.1811");
            Macro.CopyField("337", "CX.REDISC.337");
            Macro.CopyField("353", "CX.REDISC.353");
            Macro.CopyField("4", "CX.REDISC.4");
            Macro.CopyField("640", "CX.REDISC.640");
            Macro.CopyField("428", "CX.REDISC.428");
            Macro.CopyField("688", "CX.REDISC.688");
            Macro.CopyField("NEWHUD.X686", "CX.REDISC.NEWHUD.X686");
            Macro.CopyField("NEWHUD.X687", "CX.REDISC.NEWHUD.X687");
            Macro.CopyField("VASUMM.X23", "CX.REDISC.VASUMM.X23");
            Macro.CopyField("1050", "CX.REDISC.1050");
            Macro.CopyField("2", "CX.REDISC.2");
            Macro.CopyField("3", "CX.REDISC.3");
            Macro.CopyField("762", "CX.REDISC.762");
            Macro.CopyField("1199", "CX.REDISC.1199");
            Macro.CopyField("1198", "CX.REDISC.1198");
            Macro.CopyField("14", "CX.REDISC.14");
            Macro.CopyField("16", "CX.REDISC.16");
            Macro.CopyField("356", "CX.REDISC.356");
            Macro.CopyField("NEWHUD.X1165", "CX.REDISC.NEWHUD.X1165");
            Macro.CopyField("NEWHUD.X1149", "CX.REDISC.NEWHUD.X1149");
            Macro.CopyField("976", "CX.REDISC.976");
            Macro.CopyField("CASASRN.x168", "CX.REDISC.CASASRN.X168");
            Macro.CopyField("1766", "CX.REDISC.1766");
            // Macro.CopyField("799", "3121")
            Macro.CopyField("454", "CX.REDISC.454");
            Macro.CopyField("439", "CX.REDISC.439");
            Macro.CopyField("3533", "CX.REDISC.3533");
            Macro.CopyField("NEWHUD.X1144", "CX.REDISC.NEWHUD.X1144");
            Macro.CopyField("CX.SSP.DIDSHOP.PROC", "CX.RD.SSP.DIDSHOP.PROC");
            Macro.CopyField("CX.SSP.DIDSHOP", "CX.RD.SSP.DIDSHOP");
            Macro.SetField("CX.3154.REDISC", DateTime.Now.ToString());

            Macro.SetField("CX.3154.REDISC", DateTime.Now.ToString());

            Macro.SetFieldNoRules("CX.RD.CK.1041", "");
            Macro.SetFieldNoRules("CX.RD.CK.1172", "");
            Macro.SetFieldNoRules("CX.RD.CK.19", "");
            Macro.SetFieldNoRules("CX.RD.CK.1811", "");
            Macro.SetFieldNoRules("CX.RD.CK.16", "");
            Macro.SetFieldNoRules("CX.RD.CK.1109", "");
            Macro.SetFieldNoRules("CX.RD.CK.2", "");
            Macro.SetFieldNoRules("CX.RD.CK.353", "");
            Macro.SetFieldNoRules("CX.RD.CK.976", "");
            Macro.SetFieldNoRules("CX.RD.CK.VASUMM.X23", "");
            Macro.SetFieldNoRules("CX.RD.CK.4", "");
            Macro.SetFieldNoRules("CX.RD.CK.3", "");
            Macro.SetFieldNoRules("CX.RD.CK.428", "");
            Macro.SetFieldNoRules("CX.RD.CK.CASASRN.X168", "");
            Macro.SetFieldNoRules("CX.RD.CK.356", "");
            Macro.SetFieldNoRules("CX.RD.CK.NEWHUD.X1165", "");
            Macro.SetFieldNoRules("CX.RD.CK.NEWHUD.X1149", "");
            Macro.SetFieldNoRules("CX.RD.CK.NEWHUD.X1144", "");
            Macro.SetFieldNoRules("CX.RD.CK.NEWHUD.X686", "");
            Macro.SetFieldNoRules("CX.RD.CK.454", "");
            Macro.SetFieldNoRules("CX.RD.CK.439", "");
            Macro.SetFieldNoRules("CX.RD.CK.640", "");
            Macro.SetFieldNoRules("CX.RD.CK.762", "");
            Macro.SetFieldNoRules("CX.RD.CK.337", "");
            Macro.SetFieldNoRules("CX.RD.CK.1199", "");
            Macro.SetFieldNoRules("CX.RD.CK.1766", "");
            Macro.SetFieldNoRules("CX.RD.CK.1198", "");
            Macro.SetFieldNoRules("CX.RD.CK.1050", "");
            Macro.SetFieldNoRules("CX.RD.CK.1550", "");
            Macro.SetFieldNoRules("CX.RD.CK.688", "");
            Macro.SetFieldNoRules("CX.RD.CK.3533", "");
            Macro.SetFieldNoRules("CX.RD.CK.14", "");
            Macro.SetFieldNoRules("CX.RD.CK.799", "");
            Macro.SetFieldNoRules("CX.RD.CK.136", "");
            Macro.SetFieldNoRules("CX.RD.CK.SSP.DIDSHOP", "");
            Macro.SetFieldNoRules("CX.RD.COC.COMMENTS", "");
            Macro.SetFieldNoRules("CX.RD.COC.REASONS", "");
            Macro.SetFieldNoRules("CX.COC.REASON.1", "");
            Macro.SetFieldNoRules("CX.COC.REASON.2", "");
            Macro.SetFieldNoRules("CX.COC.REASON.3", "");
            Macro.SetFieldNoRules("CX.COC.REASON.4", "");
            Macro.SetFieldNoRules("CX.COC.REASON.5", "");
            Macro.SetFieldNoRules("CX.COC.REASON.6", "");
            Macro.SetFieldNoRules("CX.COC.REASON.7", "");
            Macro.SetFieldNoRules("CX.COC.REASON.8", "");
            Macro.SetFieldNoRules("CX.RD.CURRENT.DATA", "");
            Macro.SetFieldNoRules("CX.COC.RUSH.REQUEST", "");
            Macro.SetFieldNoRules("CX.COC.RUSH.REQUEST.DATE", "");
            Macro.SetFieldNoRules("CX.COC.RUSH.REQUEST.USER", "");
            Macro.SetField("CX.RD.FLOAT.TO.LOCK.IND", "");
            //MessageBox.Show(loan.Fields["CX.REDISC.LE.HIST.COMM"].Value.ToString());
            if (loan.Fields["CX.REDISC.ALERT"].FormattedValue == "Y")
            {
                for (int x = 0; x < alertList.Count; x++)
                {
                    if (loan.Fields[alertList[x]].Value.ToString() == "")
                    {
                        Macro.CopyField("Log.ALERT.DateActivated.Redisclosure Needed - Loan Data has changed", alertList[x]);
                        Macro.CopyField("CX.REDISC.COMPLETED.DATE", resolveList[x]);
                        Macro.CopyField("CX.REDISC.ASSIGNED", whoList[x]);
                        loan.Fields[cocList[x]].Value = loan.Fields["CX.REDISC.LE.HIST.COMM"].Value;
                        Macro.SetField(docList[x], "LE");
                        Macro.CopyField("LoanTeamMember.Name.Loan Processor", procList[x]);
                        Macro.CopyField("LoanTeamMember.Name.Closer", closerList[x]);
                        break;
                    }
                }
            }

            if (loan.Fields["CX.REDISC.ALERT"].FormattedValue != "Y")
            {
                for (int y = 0; y < alertList.Count; y++)
                {
                    if (loan.Fields[alertList[y]].Value.ToString() == "")
                    {
                        Macro.SetField(alertList[y], DateTime.Now.ToString("yyyy-MM-dd H:mm:ss"));
                        Macro.CopyField("CX.REDISC.COMPLETED.DATE", resolveList[y]);
                        Macro.CopyField("CX.REDISC.ASSIGNED", whoList[y]);
                        loan.Fields[cocList[y]].Value = loan.Fields["CX.REDISC.LE.HIST.COMM"].Value;
                        Macro.SetField(docList[y], "LE");
                        Macro.CopyField("LoanTeamMember.Name.Loan Processor", procList[y]);
                        Macro.CopyField("LoanTeamMember.Name.Closer", closerList[y]);
                        break;
                    }
                }
            }
            Macro.SetField("CX.REDISC.ALERT", "N");
            Macro.SetField("CX.REDISC.ALERT2", "N");
            Macro.SetField("CX.REDISC.ALERT.DATE", null);
            Macro.SetField("CX.REDISC.ASSIGNED", "");
            Macro.SetField("CX.REDISC.NOTES", "");
            Macro.SetField("CX.REDISC.NOTES.YN", "");
            Macro.SetField("CX.REDISC.COMMENTS", "");
            Macro.SetField("CX.REDISC.BORR.ADD.REM", "");
            Macro.SetField("CX.REDISC.FEE.OVER.TOL", "");
            Macro.SetField("CX.REDISC.LOCK.EVENT", "");
            Macro.SetField("CX.REDISC.MTG.INS", "");
            Macro.SetField("CX.REDISC.LOAN.PROGRAM", "");
            Macro.SetField("CX.REDISC.DISC.PTS", "");
            Macro.SetField("CX.REDISC.LOAN.TERM", "");
            Macro.SetField("CX.REDISC.PMI.MIP.CHANGE", "");
            Macro.SetField("CX.REDISC.LA.CHANGE", "");
            Macro.SetField("CX.REDISC.APR.CHANGE", "");
            Macro.SetField("CX.REDISC.PERSON.TITLE", "");
            Macro.SetField("CX.REDISC.STATE.FORMS", "");
            Macro.SetField("CX.REDISC.ESCROW.ADD.REM", "");
            Macro.SetField("CX.REDISC.TITLE.ISSUE", "");
            Macro.SetField("CX.REDISC.OTHER", "");
            Macro.SetField("CX.REDISC.OTHER.COMMENT", "");
            Macro.SetField("CX.REDISC.FULL", "");
            Macro.SetField("CX.REDISC.BORROWER", "");
            Macro.SetField("CX.REDISC.BORR.REQ", "");
            Macro.SetField("CX.REDISC.MEET.BEAT", "");
            Macro.SetField("CX.REDISC.LOAN.PARAMETERS", "");
            Macro.SetField("CX.REDISC.NO.COC", "");
            Macro.SetField("CX.REDISC.NOT.COMPLETED", "");
            Macro.SetField("CX.REDISC.NOT.COMPLETED.DATE", "");
            Macro.SetField("CX.RD.BORR", "");
            Macro.SetField("CX.RD.FEE", "");
            Macro.SetField("CX.RD.LOCK", "");
            Macro.SetField("CX.RD.LOANPROG", "");
            Macro.SetField("CX.RD.DISCPTS", "");
            Macro.SetField("CX.RD.LOANTERM", "");
            Macro.SetField("CX.RD.LOANAMT", "");
            Macro.SetField("CX.RD.APR", "");
            Macro.SetField("CX.RD.STATE", "");
            Macro.SetField("CX.RD.OTHER", "");
            Macro.SetField("CX.REDISC.PROC.REQ.USER", "");
            Macro.SetField("CX.REDISC.PROC.REQ.DATE", "");
            loan.Fields["CX.REDISC.LE"].Value = "";

            if (loan.Fields["CX.REDISC.COMPLETED"].Value.ToString() == "X")
            {
                Macro.SetField("CX.REDISC.COMPLETED", "");
                Macro.SetField("CX.REDISC.COMPLETED.DATE", "");
                Macro.SetField("CX.REDISC.COMPLETED.USER", "");

            }
            loan.Fields["CX.REDISC.ALERT.ACTIVATED.BY"].Value = "";
            loan.Fields["CX.REDISC.FIRST.ALERT.DATE"].Value = "";
            loan.Fields["CX.REDISC.DUE.BY"].Value = "";


        }




        private void CD_sent()
        {
            string hist = "";
            Loan loan = EncompassApplication.CurrentLoan;
            User user = EncompassApplication.CurrentUser;
            for (int i = 0; i < commentBoxList.Count; i++)
            {
                if (loan.Fields[commentBoxList[i]].FormattedValue == "")
                {

                    loan.Fields[commentBoxList[i]].Value = loan.Fields["CX.REDISC.COMMENTS.VAR"].FormattedValue;
                    loan.Fields[dSpeciaList[i]].Value = loan.Fields["CX.REDISC.ASSIGNED"].Value;
                    if (loan.Fields["CX.LN.HISTORY"].FormattedValue == "") 
                    {
                        hist = (user + " " + DateTime.Now + " - " + "\n" + Macro.GetField("CX.REDISC.ASSIGNED") + "\n" + loan.Fields["CX.REDISC.COMMENTS.VAR"].Value);
                        Macro.SetField("CX.LN.HISTORY", hist);
                    }
                    if (loan.Fields["CX.LN.HISTORY"].FormattedValue != "")
                    {
                        hist = (user + " " + DateTime.Now + " - " + "\n" + Macro.GetField("CX.REDISC.ASSIGNED") + "\n" + loan.Fields["CX.REDISC.COMMENTS.VAR"].Value + " " + "\n" + "\n" + Macro.GetField("CX.LN.HISTORY"));
                        Macro.SetField("CX.LN.HISTORY", hist);
                        loan.Fields[commentBoxList[i]].Value = loan.Fields["CX.REDISC.COMMENTS.VAR"].Value;
                        loan.Fields["CX.REDISC.COMMENTS.VAR"].Value = "";
                        
                    }
                    break;
                }
            }
            Macro.SetField("CX.CD.COC.SENT.DATE.TIME", DateTime.Now.ToString());
            Macro.SetField("CX.REDISC.COPY", "Y");
            Macro.SetField("cx.redisc.data", "Data");
            Macro.SetField("CX.redisc.completed.date", DateTime.Today.ToString());
            Macro.CopyField("CX.REDISC.ASSIGNED", "CX.REDISC.COMPLETED.USER");
            Macro.SetField("CX.HELOC", "N");
            Macro.CopyField("1041", "cx.redisc.1041");
            Macro.CopyField("1172", "cx.redisc.1172");
            Macro.CopyField("1109", "cx.redisc.1109");
            Macro.CopyField("1550", "cx.redisc.1550");
            Macro.CopyField("19", "cx.redisc.19");
            Macro.CopyField("1811", "cx.redisc.1811");
            Macro.CopyField("337", "cx.redisc.337");
            Macro.CopyField("353", "cx.redisc.353");
            Macro.CopyField("4", "cx.redisc.4");
            Macro.CopyField("428", "cx.redisc.428");
            Macro.CopyField("688", "cx.redisc.688");
            Macro.CopyField("NEWHUD.X686", "cx.redisc.NEWHUD.X686");
            Macro.CopyField("NEWHUD.X687", "cx.redisc.NEWHUD.X687");
            Macro.CopyField("VASUMM.X23", "cx.redisc.VASUMM.X23");
            Macro.CopyField("1050", "cx.redisc.1050");
            Macro.CopyField("2", "cx.redisc.2");
            Macro.CopyField("3", "cx.redisc.3");
            Macro.CopyField("640", "cx.redisc.640");
            Macro.CopyField("762", "cx.redisc.762");
            Macro.CopyField("1199", "cx.redisc.1199");
            Macro.CopyField("1198", "cx.redisc.1198");
            Macro.CopyField("14", "cx.redisc.14");
            Macro.CopyField("16", "cx.redisc.16");
            Macro.CopyField("356", "cx.redisc.356");
            Macro.CopyField("NEWHUD.X1165", "cx.redisc.newhud.x1165");
            Macro.CopyField("NEWHUD.X1149", "cx.redisc.newhud.x1149");
            Macro.CopyField("976", "cx.redisc.976");
            Macro.CopyField("casasrn.x168", "cx.redisc.casasrn.x168");
            Macro.CopyField("1766", "cx.redisc.1766");
            Macro.CopyField("1072", "cx.redisc.1072");
            Macro.CopyField("454", "cx.redisc.454");
            Macro.CopyField("439", "cx.redisc.439");
            Macro.CopyField("3533", "cx.redisc.3533");
            Macro.CopyField("NEWHUD.X1144", "CX.REDISC.NEWHUD.X1144");
            Macro.CopyField("CX.SSP.DIDSHOP.PROC", "CX.RD.SSP.DIDSHOP.PROC");
            Macro.CopyField("CX.SSP.DIDSHOP", "CX.RD.SSP.DIDSHOP");

            Macro.SetFieldNoRules("CX.RD.CK.1041", "");
            Macro.SetFieldNoRules("CX.RD.CK.1172", "");
            Macro.SetFieldNoRules("CX.RD.CK.19", "");
            Macro.SetFieldNoRules("CX.RD.CK.1811", "");
            Macro.SetFieldNoRules("CX.RD.CK.16", "");
            Macro.SetFieldNoRules("CX.RD.CK.1109", "");
            Macro.SetFieldNoRules("CX.RD.CK.2", "");
            Macro.SetFieldNoRules("CX.RD.CK.353", "");
            Macro.SetFieldNoRules("CX.RD.CK.976", "");
            Macro.SetFieldNoRules("CX.RD.CK.VASUMM.X23", "");
            Macro.SetFieldNoRules("CX.RD.CK.4", "");
            Macro.SetFieldNoRules("CX.RD.CK.3", "");
            Macro.SetFieldNoRules("CX.RD.CK.428", "");
            Macro.SetFieldNoRules("CX.RD.CK.CASASRN.X168", "");
            Macro.SetFieldNoRules("CX.RD.CK.356", "");
            Macro.SetFieldNoRules("CX.RD.CK.NEWHUD.X1165", "");
            Macro.SetFieldNoRules("CX.RD.CK.NEWHUD.X1149", "");
            Macro.SetFieldNoRules("CX.RD.CK.NEWHUD.X1144", "");
            Macro.SetFieldNoRules("CX.RD.CK.NEWHUD.X686", "");
            Macro.SetFieldNoRules("CX.RD.CK.454", "");
            Macro.SetFieldNoRules("CX.RD.CK.439", "");
            Macro.SetFieldNoRules("CX.RD.CK.640", "");
            Macro.SetFieldNoRules("CX.RD.CK.762", "");
            Macro.SetFieldNoRules("CX.RD.CK.337", "");
            Macro.SetFieldNoRules("CX.RD.CK.1199", "");
            Macro.SetFieldNoRules("CX.RD.CK.1766", "");
            Macro.SetFieldNoRules("CX.RD.CK.1198", "");
            Macro.SetFieldNoRules("CX.RD.CK.1050", "");
            Macro.SetFieldNoRules("CX.RD.CK.1550", "");
            Macro.SetFieldNoRules("CX.RD.CK.688", "");
            Macro.SetFieldNoRules("CX.RD.CK.3533", "");
            Macro.SetFieldNoRules("CX.RD.CK.14", "");
            Macro.SetFieldNoRules("CX.RD.CK.799", "");
            Macro.SetFieldNoRules("CX.RD.CK.136", "");
            Macro.SetFieldNoRules("CX.RD.CK.SSP.DIDSHOP", "");
            Macro.SetFieldNoRules("CX.RD.COC.COMMENTS", "");
            Macro.SetFieldNoRules("CX.RD.COC.REASONS", "");
            Macro.SetFieldNoRules("CX.COC.REASON.1", "");
            Macro.SetFieldNoRules("CX.COC.REASON.2", "");
            Macro.SetFieldNoRules("CX.COC.REASON.3", "");
            Macro.SetFieldNoRules("CX.COC.REASON.4", "");
            Macro.SetFieldNoRules("CX.COC.REASON.5", "");
            Macro.SetFieldNoRules("CX.COC.REASON.6", "");
            Macro.SetFieldNoRules("CX.COC.REASON.7", "");
            Macro.SetFieldNoRules("CX.COC.REASON.8", "");
            Macro.SetFieldNoRules("CX.RD.CURRENT.DATA", "");
            Macro.SetFieldNoRules("CX.COC.RUSH.REQUEST", "");
            Macro.SetFieldNoRules("CX.COC.RUSH.REQUEST.DATE", "");
            Macro.SetFieldNoRules("CX.COC.RUSH.REQUEST.USER", "");
            Macro.SetField("CX.RD.FLOAT.TO.LOCK.IND", "");


            Macro.SetField("CX.3154.REDISC", DateTime.Now.ToString());
            if (loan.Fields["CX.REDISC.ALERT"].FormattedValue == "Y")
            {
                for (int x = 0; x < alertList.Count; x++)
                {
                    if (loan.Fields[alertList[x]].Value.ToString() == "")
                    {
                        Macro.CopyField("Log.ALERT.DateActivated.Redisclosure Needed - Loan Data has changed", alertList[x]);
                        Macro.CopyField("CX.REDISC.COMPLETED.DATE", resolveList[x]);
                        Macro.CopyField("CX.REDISC.ASSIGNED", whoList[x]);
                        loan.Fields[cocList[x]].Value = loan.Fields["CX.CD.COC.ALL.REASONS"].Value;
                        Macro.SetField(docList[x], "CD");
                        Macro.CopyField("LoanTeamMember.Name.Loan Processor", procList[x]);
                        Macro.CopyField("LoanTeamMember.Name.Closer", closerList[x]);
                        break;
                    }
                }
            }

            if ((loan.Fields["CX.REDISC.ALERT"].FormattedValue != "Y" & loan.Fields["CD1.X61"].FormattedValue == "Y") || loan.Fields["Cx.redisc.alert2"].FormattedValue == "Y")
            {
                for (int y = 0; y < alertList.Count; y++)
                {
                    if (loan.Fields[alertList[y]].Value.ToString() == "")
                    {
                        Macro.SetField(alertList[y], DateTime.Now.ToString("yyyy-MM-dd H:mm:ss"));
                        Macro.CopyField("CX.REDISC.COMPLETED.DATE", resolveList[y]);
                        Macro.CopyField("CX.REDISC.ASSIGNED", whoList[y]);
                        loan.Fields[cocList[y]].Value = loan.Fields["CX.CD.COC.ALL.REASONS"].Value;
                        Macro.SetField(docList[y], "CD");
                        Macro.CopyField("LoanTeamMember.Name.Loan Processor", procList[y]);
                        Macro.CopyField("LoanTeamMember.Name.Closer", closerList[y]);
                        break;
                    }
                }
            }
            Macro.SetField("CX.REDISC.Alert", "N");
            Macro.SetField("CX.REDISC.Alert2", "N");
            Macro.SetField("CX.REDISC.ALERT.DATE", "");
            Macro.SetField("CX.redisc.closer.req.user", "");
            Macro.SetField("CX.redisc.closer.req.date", "");
            Macro.SetField("CX.CD.REDISC.COMMENTS", "");
            Macro.SetField("CX.redisc.assigned", "");
            Macro.SetField("CX.redisc.notes", "");
            Macro.SetField("CX.redisc.notes.yn", "");
            Macro.SetFieldNoRules("CX.COC.RUSH.REQUEST", "");
            Macro.SetFieldNoRules("CX.COC.RUSH.REQUEST.DATE", "");
            Macro.SetFieldNoRules("CX.COC.RUSH.REQUEST.USER", "");
            //Added for STRY0237058
            
            if(loan.Fields["CX.REDISC.COMPLETED"].Value.ToString() == "X")
            {
                Macro.SetFieldNoRules("CX.REDISC.COMPLETED", "");
                Macro.SetFieldNoRules("CX.REDISC.COMPLETED.DATE", "");
                Macro.SetFieldNoRules("CX.REDISC.COMPLETED.USER", "");
            }
            
            Macro.SetFieldNoRules("CX.REDISC.ALERT.ACTIVATED.BY", "");
            Macro.SetFieldNoRules("CX.REDISC.FIRST.ALERT.DATE", "");
            Macro.SetFieldNoRules("CX.REDISC.DUE.BY", "");
            loan.Fields["CX.REDISC.CD"].Value = "";
        }


private void Approval_Package()
        {
            string hist = "";
            Loan loan = EncompassApplication.CurrentLoan;
            User user = EncompassApplication.CurrentUser;
            for (int i = 0; i < commentBoxList.Count; i++)
            {
                if (loan.Fields[commentBoxList[i]].FormattedValue == "")
                {

                    loan.Fields[commentBoxList[i]].Value = loan.Fields["CX.REDISC.COMMENTS.VAR"].FormattedValue;
                    loan.Fields[dSpeciaList[i]].Value = loan.Fields["CX.APPROVAL.SEND.ASSIGNED"].Value;
                    if (loan.Fields["CX.LN.HISTORY"].FormattedValue == "")
                    {
                        hist = (user + " " + DateTime.Now + " - " + "\n" + Macro.GetField("CX.APPROVAL.SEND.ASSIGNED") + "\n" + loan.Fields["CX.REDISC.COMMENTS.VAR"].Value);
                        Macro.SetField("CX.LN.HISTORY", hist);
                        
                    }
                    if (loan.Fields["CX.LN.HISTORY"].FormattedValue != "")
                    {
                        hist = (user + " " + DateTime.Now + " - " + "\n" + Macro.GetField("CX.APPROVAL.SEND.ASSIGNED") + "\n" + loan.Fields["CX.REDISC.COMMENTS.VAR"].Value + " " + "\n" + "\n" + Macro.GetField("CX.LN.HISTORY"));
                        Macro.SetField("CX.LN.HISTORY", hist);
                        loan.Fields[commentBoxList[i]].Value = loan.Fields["CX.REDISC.COMMENTS.VAR"].Value;
                        loan.Fields["CX.REDISC.COMMENTS.VAR"].Value = "";
                        
                    }
                    break;
                }
            }
            Macro.SetFieldNoRules("CX.APP.SENT.TRIGGER", "X");

                for (int x = 0; x < alertList.Count; x++)
                {
                    if (loan.Fields[alertList[x]].Value.ToString() == "")
                    {

                    if (loan.Fields["CX.REDISC.TYPE.TEXT"].Value.ToString() == "Approval Package")
                    {
                        Macro.CopyField("Log.ALERT.DateActivated.Send Approval Package", alertList[x]);
                    }
                    else if (loan.Fields["CX.REDISC.TYPE.TEXT"].Value.ToString() == "Re-Approval Package")
                    {
                        Macro.CopyField("Log.ALERT.DateActivated.Re-Approval Required to be sent", alertList[x]);
                    }
                    
                        Macro.SetField(resolveList[x], DateTime.Today.ToString());
                        Macro.CopyField("CX.APPROVAL.SEND.ASSIGNED", whoList[x]);
                        loan.Fields[cocList[x]].Value = loan.Fields["CX.REDISC.TYPE.TEXT"].Value;
                        Macro.SetField(docList[x], "Approval");
                        Macro.CopyField("LoanTeamMember.Name.Loan Processor", procList[x]);
                        Macro.CopyField("LoanTeamMember.Name.Closer", closerList[x]);
                    break;
                }
                Macro.SetField("CX.APPROVAL.NOTES", "");
                Macro.SetField("CX.APPROVAL.SEND.ASSIGNED", "");
                loan.Fields["CX.REDISC.APPROVAL"].Value = "";
                loan.Fields["CX.APPROVAL.SENT.DATE"].Value = loan.Fields["CX.REDISC.SENT.DATETIME"].Value;
                loan.Fields["CX.REDISC.TYPE.TEXT"].Value = "";

            }
            }
        }
    
}
