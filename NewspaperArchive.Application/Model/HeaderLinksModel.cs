using System;
using System.Collections.Generic;
using System.Text;

namespace NewspaperArchive.Application.Model
{
    public class HeaderLinksModel
    {

        //public HeaderLinksModel()
        //{
        //    GedcomFileList = new List<SelectGFile>();
        //}
        public bool IsAuthenticated { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }

        public bool IsActiveAccount { get; set; }
        public int PlanID { get; set; }
        public int RoleID { get; set; }

        public string hdnUserID { get; set; }
        public string hdnOpenFBModal { get; set; }
        public string hdnFBConnectedNeed { get; set; }
        public string hdnIsClearCookie { get; set; }
        public string hdnFbMergeRu { get; set; }
        public string hdnFbMerge { get; set; }

        public string hdnclass_wrap { get; set; }
        public string headerScripts { get; set; }
        public string IsPublicViewerPlan { get; set; }

        public string Message { get; set; }
        public string startdate { get; set; }
        public string enddate { get; set; }

        public bool IsOldBrowser { get; set; }
        public bool IsShowCCPopup { get; set; }
        public string hdnuaid { get; set; }
        public Int32 hdnviewlimit { get; set; }
        public string hdnlimitstart { get; set; }
        public bool IsShowFreeMemberPopup { get; set; }
        public Int32 hdnClosableLimit { get; set; }
        public Int32 hdnClosableExpired { get; set; }

        public string RedirectUrl { get; set; }

        //public List<SelectGFile> GedcomFileList { get; set; }
        public string BreadCumb { get; set; }
        public string TreeName { get; set; }
        //FOR GEDCOM : PROCESSED GEDCOM COUNT
        public int NotificationCount { get; set; }


    }
}
