using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class Default : System.Web.UI.Page
    {
        private EmployeeRepository _repository;

        public EmployeeRepository Repository
        {
            get { return _repository ?? (_repository = new EmployeeRepository()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string employeeId = RouteData.Values["Id"] as string;
                if (string.IsNullOrEmpty(employeeId) || employeeId == "*")
                {
                    GridViewEmployees.DataSource = Repository.GetEmployees();
                    GridViewEmployees.DataBind();

                }
                else
                {
                    DetailsViewEmployee.DataSource = Repository.GetEmployees(employeeId);
                    DetailsViewEmployee.DataBind();
                }
            }
        }
    }
}