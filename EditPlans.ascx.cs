﻿using DotNetNuke.Services.Exceptions;
using System;
using Ventrian.Modules.Subscriptions.Base;
using Ventrian.Modules.Subscriptions.Components.Entities;

namespace Ventrian.Modules.Subscriptions
{
    public partial class EditPlans : SubscriptionBase<SubscriptionSettings>
    {
        #region Private Methods

        private void BindPlans()
        {

            grdPlans.DataSource = Plans;
            grdPlans.DataBind();

            if( grdPlans.Items.Count == 0 )
            {
                grdPlans.Visible = false;
                phNoPlans.Visible = true;
            }
        }

        #endregion

        #region Protected Methods

        protected string GetEditUrl(int planID)
        {
            return EditUrl("pid", planID.ToString(), "EditPlan");
        }

        #endregion

        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                BindPlans();
                lnkAddEntry.NavigateUrl = EditUrl("EditPlan");
            }
            catch(Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }

        #endregion
    }
}