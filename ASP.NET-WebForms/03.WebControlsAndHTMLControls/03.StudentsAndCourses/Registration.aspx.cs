using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace _03.StudentsAndCourses
{
    public partial class Registration : System.Web.UI.Page
    {
        private const string Error_Message = "cannot be null or empty!";

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            var firstName = this.tb_firstName.Text;
            var lastName = this.tb_lastName.Text;
            var facultyNumber = this.tb_facultyNumber.Text;
            var university = this.ddl_university.Text;
            var specialty = this.ddl_specialty.Text;
            var courses = this.lb_courses.Items;

            if (string.IsNullOrEmpty(firstName))
            {
                var errorLabel = new Label();
                errorLabel.Text = "First name " + Error_Message;
                this.Controls.Add(errorLabel);
            }

            else if (string.IsNullOrEmpty(lastName))
            {
                var errorLabel = new Label();
                errorLabel.Text = "Last name " + Error_Message;
                this.Controls.Add(errorLabel);
            }

            else if (string.IsNullOrEmpty(facultyNumber))
            {
                var errorLabel = new Label();
                errorLabel.Text = "Faculty number " + Error_Message;
                this.Controls.Add(errorLabel);
            }

            else
            {
                var br = new HtmlGenericControl("br");

                var heading = new HtmlGenericControl("h1");
                heading.InnerText = "Student information";

                var firstNameContainer = new HtmlGenericControl("div");
                var firstNameLabel = new HtmlGenericControl("strong");
                var firstNameValue = new HtmlGenericControl("span");
                firstNameLabel.InnerText = "First Name: ";
                firstNameValue.InnerText = firstName;
                firstNameContainer.Controls.Add(firstNameLabel);
                firstNameContainer.Controls.Add(firstNameValue);

                var lastNameContainer = new HtmlGenericControl("div");
                var lastNameLabel = new HtmlGenericControl("strong");
                var lastNameValue = new HtmlGenericControl("span");
                lastNameLabel.InnerText = "Last Name: ";
                lastNameValue.InnerText = lastName;
                lastNameContainer.Controls.Add(lastNameLabel);
                lastNameContainer.Controls.Add(lastNameValue);


                var facultyNumberContainer = new HtmlGenericControl("div");
                var facultyNumberLabel = new HtmlGenericControl("strong");
                var facultyNumberValue = new HtmlGenericControl("span");
                facultyNumberLabel.InnerText = "Faculty Number:";
                facultyNumberValue.InnerText = facultyNumber;
                facultyNumberContainer.Controls.Add(facultyNumberLabel);
                facultyNumberContainer.Controls.Add(facultyNumberValue);


                var universityContainer = new HtmlGenericControl("div");
                var universityLabel = new HtmlGenericControl("strong");
                var universityValue = new HtmlGenericControl("span");
                universityLabel.InnerText = "University: ";
                universityValue.InnerText = university;
                universityContainer.Controls.Add(universityLabel);
                universityContainer.Controls.Add(universityValue);


                var specialtyContainer = new HtmlGenericControl("div");
                var specialtyLabal = new HtmlGenericControl("strong");
                var specialtyValue = new HtmlGenericControl("sapn");
                specialtyLabal.InnerText = "Specialty: ";
                specialtyValue.InnerText = specialty;
                specialtyContainer.Controls.Add(specialtyLabal);
                specialtyContainer.Controls.Add(specialtyValue);

                var coursesContainer = new HtmlGenericControl("div");
                var coursesLabel = new HtmlGenericControl("strong");
                var coursesValue = new HtmlGenericControl("ul");
                coursesLabel.InnerText = "Courses: ";

                foreach (ListItem item in courses)
                {
                    if (item.Selected)
                    {
                        var li = new HtmlGenericControl("li");
                        li.InnerText = item.Text;
                        coursesValue.Controls.Add(li);
                    }
                }

                coursesContainer.Controls.Add(coursesLabel);
                coursesContainer.Controls.Add(coursesValue);

                this.Controls.Add(br);
                this.Controls.Add(br);
                this.Controls.Add(heading);
                this.Controls.Add(firstNameContainer);
                this.Controls.Add(lastNameContainer);
                this.Controls.Add(facultyNumberContainer);
                this.Controls.Add(specialtyContainer);
                this.Controls.Add(coursesContainer);
            }

        }
    }
}