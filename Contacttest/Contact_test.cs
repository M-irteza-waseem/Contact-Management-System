using NUnit.Framework;
using System.Windows.Forms;

namespace Tests
{
    public class Contact_test
    {
        private CMSBU.Contacts _contacts;

        [SetUp]
        public void Setup()
        {
            // Initialize the Contacts form
            _contacts = new CMSBU.Contacts();

            // Set up ComboBoxes
            _contacts.Controls.Add(new ComboBox { Name = "comboBox2", Text = "Gander" });
            _contacts.Controls.Add(new ComboBox { Name = "comboBox3", Text = "City" });
            _contacts.Controls.Add(new ComboBox { Name = "comboBox4", Text = "Company" });
        }

        [Test]
        public void SortMethod_WhenComboBoxesAreSet_GeneratesCorrectSearchStatement()
        {
            // Arrange
            var comboBox2 = (ComboBox)_contacts.Controls["comboBox2"];
            var comboBox3 = (ComboBox)_contacts.Controls["comboBox3"];
            var comboBox4 = (ComboBox)_contacts.Controls["comboBox4"];

            comboBox2.Text = "Male";
            comboBox3.Text = "New York";
            comboBox4.Text = "TechCorp";

            // Act
            comboBox2.SelectedIndex = 0; // Trigger the event
            string expectedStatement = "select * from Contacts where gander='Male' AND city='New York' AND company='TechCorp'";

            // Assert
            Assert.AreEqual(expectedStatement, _contacts.GetSearchStatement());
        }
    }
}
