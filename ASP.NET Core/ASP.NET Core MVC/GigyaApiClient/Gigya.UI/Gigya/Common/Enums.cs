using System.ComponentModel;

namespace Gigya.Common
{
    public class Enums
    {
        /// <summary>
        /// Enum containing all the Permissions
        /// </summary>
        public enum Permissions
        {
            Dashboard = 1,
            CreateOrUpdateEnrolment = 2,
            Profile = 3,
            AssociatedRanchers = 4,
            SearchAllEnrolments = 5,
            SearchOwnEnrolments = 6,
            CanSetHealthHerdAdvisor = 7,
            CanRejectOrApproveEnrolments = 8,
            MustUploadProofOfPurchase = 9,
            VetUserMustAssociateItselfToEnrolments = 10,
            CanSelectWhoShouldReceiveTheBarnCard = 11,
            CanViewRanchersAssociatedToAllVetsWithinOrganisation = 12,
            MustSendBarnCardToRancherIfSelected = 13,
            CanPrintBarnCards = 14,
            CanPrintCommissionReports = 15,
            VetSpecialistUserMustAssociateItselfToEnrolments = 16,
            CanDeleteOwnEnrolments = 17,
            RancherUserMustAssociateItselfToEnrolments = 18,
            CanSetCattleOwner = 19,
            CanUpdateOthersEnrolment = 20,
            CanViewAllAssociations = 21,
            HasAliasPermission = 22
        }

        /// <summary>
        /// Enum containing the User Roles
        /// </summary>
        public enum Roles
        {
            [Description("Consulting Vet")]
            Vet = 8,
            [Description("SelectVAC Specialist")]
            VetSpecialist = 9,
            [Description("Rancher")]
            Rancher = 10,
            [Description("Admin Asst/Recep.")]
            SelectVACAdmin = 11,
            [Description("SelectVACSystem")]
            SelectVACSystem = 12
        }
    }
}
