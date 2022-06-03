using System;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Security;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;
using System.Diagnostics;
// Copyright © Microsoft Corporation.  All Rights Reserved.
// This code released under the terms of the 
// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)
namespace Donation.DonationDeleting
{
    /// <summary>
    /// List Item Events
    /// </summary>
    public class DonationDeleting : SPItemEventReceiver
    {
       /// <summary>
        /// Sample EventHandler that prevents the user from deleting an imtem in the donations list which has an amount greater than 0
       /// </summary>
       public override void ItemDeleting(SPItemEventProperties properties)
       {
           try
           {
               double amount = (double)properties.ListItem["Amount"];
               if (amount > 0)
               {
                   properties.ErrorMessage = "You cannot delete donations with an amount greater than 0. We want to keep the money!";
                   properties.Cancel = true;
               }
           }
           catch (Exception ex)
           {
               EventLog.WriteEntry("SP Event Handler", ex.Message);
           }
       }


    }
}
